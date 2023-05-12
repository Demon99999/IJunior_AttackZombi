using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private const string Attack = "Attack";

    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            AttackTarget(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void AttackTarget(Player target)
    {
        _animator.Play(Attack);
        target.ApplayDamage(_damage);
    }
}
