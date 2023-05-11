using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private AimCursor _cursor;
    [SerializeField] private Vector3 _startPosition;

    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
    }

    private void Update()
    {
        Vector3 dir=Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1.0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            dir.z = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir.z = -1.0f;
        }

        _navMeshAgent.velocity = dir.normalized * _moveSpeed;
        
        Vector3 forward = _cursor.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z));
    }

    public void ResetPlater()
    {
        transform.position = _startPosition;
    }
}
