using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner m_spawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _endScreen.RestartButtonClick += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _endScreen.RestartButtonClick -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _endScreen.Close();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        m_spawner.ResetSpawn();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }
}
