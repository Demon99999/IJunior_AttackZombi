using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveState : State
{
    [SerializeField] private float _speed;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _animator=GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Target != null)
        {
            _navMeshAgent.SetDestination(Target.transform.position);
            transform.rotation = Quaternion.LookRotation(_navMeshAgent.velocity.normalized);
            _animator.Play("Run");
        }
    }
}
