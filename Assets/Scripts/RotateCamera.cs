using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float _sensevity;
    [Range(-90, 90)] [SerializeField] private float _maxAngelToDown;
    [Range(-90, 90)] [SerializeField] private float _maxAngelToUp;

    private Vector3 _rotateTo;

    private void OnValidate()
    {
        if (_maxAngelToUp > _maxAngelToDown)
            _maxAngelToUp = _maxAngelToDown - 1;
    }

    private void Start()
    {
        _rotateTo = transform.eulerAngles;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        _rotateTo.x -= Input.GetAxis("Mouse Y") * _sensevity;
        _rotateTo.y += Input.GetAxis("Mouse X") * _sensevity;

        _rotateTo.x = Mathf.Clamp(_rotateTo.x, _maxAngelToUp, _maxAngelToDown);

        transform.eulerAngles = _rotateTo;
    }
}
