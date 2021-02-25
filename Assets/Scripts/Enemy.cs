using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [Min(0)] [SerializeField] private float _minPauseTimeBetweenJump;
    [Min(1)] [SerializeField] private float _maxPauseTimeBetweenJump;
    [SerializeField] private float _forceJump;
    [SerializeField] private int _maxJumpCount;

    private Camera _camera;
    private Rigidbody _rigidbody;
    private int _countJump = 0;

    private void OnValidate()
    {
        int additionalNumberForCorrectMaxValue = 1;
        if (_maxPauseTimeBetweenJump <= _minPauseTimeBetweenJump)
            _maxPauseTimeBetweenJump = _minPauseTimeBetweenJump + additionalNumberForCorrectMaxValue;
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
            yield return new WaitForSeconds(Random.Range(_minPauseTimeBetweenJump, _maxPauseTimeBetweenJump));
            if (_countJump < _maxJumpCount)
                Jump();
            else
                Destroy(gameObject);
        }
    }
}
