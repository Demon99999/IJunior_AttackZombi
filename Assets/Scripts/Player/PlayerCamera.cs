using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _player.transform.position;
    }

    private void LateUpdate()
    {
        if (_player != null)
        {
            transform.position = _player.transform.position + _offset;
        }
    }
}
