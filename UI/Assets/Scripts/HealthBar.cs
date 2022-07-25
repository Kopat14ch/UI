using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarFilling;
    [SerializeField] private Player _player;

    private int _delay;
    private int _to;
    
    private void Start()
    {
        _healthBarFilling.maxValue = _player.CurrentHealth;
        _healthBarFilling.value = _healthBarFilling.maxValue;
        _delay = 2;
        _to = (int)_healthBarFilling.value;
    }

    private void FixedUpdate()
    {
        if (_healthBarFilling.value != _to)
        {
            _healthBarFilling.value = Mathf.Lerp(_healthBarFilling.value, _to, _delay * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        _player.HealthChange += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChange -= OnHealthChanged;
    }

    private void OnHealthChanged(int from, int to)
    {
        _to = to;
    }

}
