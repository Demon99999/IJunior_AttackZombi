using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovementAnimator : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _animator.SetFloat("speed",_navMeshAgent.velocity.magnitude);
    }
}
