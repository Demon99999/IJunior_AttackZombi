using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CelebrationsState : State
{
    private const string Idle = "idle";

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _animator.Play(Idle);
        _navMeshAgent.isStopped = true;
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
