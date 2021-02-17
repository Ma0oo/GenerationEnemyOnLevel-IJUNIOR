using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float _sensevity;

    private Vector3 _rotateTo = new Vector3();

    private void Update()
    {
        _rotateTo.x -= Input.GetAxis("Mouse Y") * _sensevity;
        _rotateTo.y += Input.GetAxis("Mouse X") * _sensevity;

        if (_rotateTo.x < -45)
            _rotateTo.x = -45;
        if (_rotateTo.x > 45)
            _rotateTo.x = 45;

        transform.eulerAngles = _rotateTo;
    }
}
