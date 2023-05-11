using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    
    private PlayerMove _playerMove;
    private int _currentHealth;
    private int _score;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int,int> HealthChanged;
    public event UnityAction GameOver;

    private void Start()
    {
        _currentHealth = _health;
        HealthChanged?.Invoke(_currentHealth, _health);
        _playerMove = GetComponent<PlayerMove>();
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _currentHealth = _health;
        HealthChanged?.Invoke(_currentHealth, _health);
        _playerMove.ResetPlater();
    }

    public void ApplayDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            GameOver?.Invoke();
            gameObject.SetActive(false);
        }
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}
