using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public event Action<int> HealthChange;
    private int _currentHealth;
    public int CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Mathf.Clamp(_currentHealth, 0, _maxHealth);
        HealthChange?.Invoke(_currentHealth);
    }

    public void Heal(int heal)
    {
        _currentHealth += heal;
        Mathf.Clamp(_currentHealth, 0, _maxHealth);
        HealthChange?.Invoke(_currentHealth);
    }
}
