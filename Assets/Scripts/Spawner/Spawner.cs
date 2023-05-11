using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _container;
    [SerializeField] private NextWaveButton _nextWaveButton;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    public void ResetSpawn()
    {
        _currentWaveNumber = 0;
        _spawned = 0;
        _timeAfterLastSpawn = 0;
        _nextWaveButton.HideButton();
        SetWave(_currentWaveNumber);

        foreach (Transform child in _container.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void InstantiateEnemy()
    {
        int indexPoint = Random.Range(0, _spawnPoints.Length);
        Enemy enemy = Instantiate(_currentWave.Template,_container.transform).GetComponent<Enemy>();
        enemy.transform.position = _spawnPoints[indexPoint].position;
        enemy.Init(_player);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
