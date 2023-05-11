using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int _health;

    private NavMeshAgent _navMeshAgent;
    private Player _target;
    private Animator _animator;
    private int _currentHealth;

    public bool IsDead { private get; set; }
    public Player Target => _target;
    
    public int Health => _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }

    public void ZombiDie()
    {
        if (!IsDead)
        {
            IsDead = true;
            _navMeshAgent.isStopped = true;
            _animator.Play("Die");
            _particleSystem.Play();
            _target.AddScore();
            StartCoroutine(DisableZombi());
        }
    }

    private IEnumerator DisableZombi()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
