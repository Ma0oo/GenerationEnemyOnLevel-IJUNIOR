using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [Min(0)] [SerializeField] private float _minPauseTimebetweenJump;
    [Min(1)] [SerializeField] private float _maxPauseTimebetweenJump;
    [SerializeField] private float _forceJump;
    [SerializeField] private int _maxJumpCount;

    private Camera _camera;
    private Rigidbody _rigidbody;
    private int _countJump = 0;

    private void OnValidate()
    {
        if (_minPauseTimebetweenJump >= _maxPauseTimebetweenJump)
            _maxPauseTimebetweenJump = _minPauseTimebetweenJump+1;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
        StartCoroutine(JumpLogic());
    }

    private void Jump()
    {
        _rigidbody.AddForce((_camera.transform.position - transform.position).normalized * _forceJump, ForceMode.Impulse);
        _countJump++;
    }

    private IEnumerator JumpLogic()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minPauseTimebetweenJump, _maxPauseTimebetweenJump));
            if (_countJump < _maxJumpCount)
                Jump();
            else
                Destroy(gameObject);
        }
    }
}
