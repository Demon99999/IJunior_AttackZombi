using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaButton;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaButton.onClick.AddListener(OnNextButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaButton.onClick.RemoveListener(OnNextButtonClick);
    }

    private void OnAllEnemySpawned()
    {
        _nextWaButton.gameObject.SetActive(true);
    }

    private void OnNextButtonClick()
    {
        _spawner.NextWave();
        _nextWaButton.gameObject.SetActive(false);
    }

    public void HideButton()
    {
        _nextWaButton.gameObject.SetActive(false);
    }
}
