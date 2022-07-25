using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public event Action<int,int> HealthChange;
    private int _currentHealth;
    public int CurrentHealth => _currentHealth;
    
    public void SetHealth(int value)
    {
        int from = _currentHealth;
        _currentHealth += value;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        else
        {
            HealthChange?.Invoke(from,_currentHealth);
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
}
