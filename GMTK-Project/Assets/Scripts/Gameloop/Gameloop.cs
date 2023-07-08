using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Gameloop : MonoBehaviour
{
    // fields

    [SerializeField] private UnityEvent _onLoopBegin;
    [SerializeField] private UnityEvent _onLoopEnd;
    [SerializeField] private List<GameRoutine> _taskList = new List<GameRoutine>();

    Queue<GameRoutine> _queuedRoutines = new Queue<GameRoutine>();


    // public methods

    private void Start()
    {
        ExecuteLoop();
    }

    public void ExecuteLoop()
    {
        // queue routines
        _taskList.ForEach(elem => _queuedRoutines.Enqueue(elem));
        // execute them
        StartCoroutine(loopExecutionHelper());
    }


    // private methods

    IEnumerator loopExecutionHelper()
    {
        _onLoopBegin?.Invoke();
        while (_queuedRoutines.Count > 0)
        {
            var routine = _queuedRoutines.Dequeue();
            yield return new WaitForSecondsRealtime(routine.delayBeforeThisRoutine);
            print($"Executing Routine : {routine.routineName}");
            routine.onRoutineExecute?.Invoke();
            yield return new WaitForSecondsRealtime(routine.delayBeforeNextRoutine);
        }
        yield return null;
        _onLoopEnd?.Invoke();
    }


    // nested types

    [System.Serializable]
    public struct GameRoutine
    {
        public string routineName;
        public float delayBeforeThisRoutine;
        public UnityEvent onRoutineExecute;
        public float delayBeforeNextRoutine;
    }
}
