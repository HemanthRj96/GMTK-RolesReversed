using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformController : MonoBehaviour
{
    // fields

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;

    Vector3 _axisValue;
    float _rotationValue;
    bool _state = true;


    // public methods

    public void SetControllerState(bool state)
    {
        _state = state;
    }


    // private methods

    private void Update()
    {
        if (_state == false)
        {
            _rotationValue = 0;
            _axisValue = Vector3.zero;
            return;
        }

        _rotationValue = Input.GetAxisRaw("Rotate");
        _axisValue = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal"));
    }

    private void FixedUpdate()
    {
        var oldAngle = transform.eulerAngles;
        var oldPos = transform.position;
        transform.eulerAngles = oldAngle + (Vector3.up * _rotationSpeed * Time.deltaTime * _rotationValue);
        transform.position = oldPos + (_axisValue * _moveSpeed * Time.deltaTime);
    }
}
