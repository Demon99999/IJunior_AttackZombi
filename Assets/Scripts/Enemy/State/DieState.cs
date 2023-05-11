using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DieState : State
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemy.ZombiDie();
    }
}
