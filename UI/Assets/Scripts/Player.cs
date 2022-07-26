using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public event Action<int> HealthChanged;
    private int _currentHealth;
    public int MaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth);
    }

    public void Heal(int heal)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + heal, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth);
    }
}
