using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarFilling;
    [SerializeField] private Player _player;

    private bool _heal;
    private int _delay;
    private float _inaccuracy;
    
    private void Start()
    {
        _heal = false;
        _healthBarFilling.maxValue = _player.CurrentHealth;
        _healthBarFilling.value = _healthBarFilling.maxValue;
        _delay = 3;
        _inaccuracy = 0.00001f;
    }

    private void OnEnable()
    {
        _player.HealthChange += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChange -= OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth)
    {
        if (currentHealth >= _healthBarFilling.value)
        {
            _heal = true;
            StartCoroutine(AddHealth(currentHealth));
        }
        else if (currentHealth <= _healthBarFilling.value)
        {
            _heal = false;
            StartCoroutine(TakeHealth(currentHealth));
        }
    }

    private IEnumerator AddHealth(int currentHealth)
    {
        while (currentHealth >= _healthBarFilling.value + _inaccuracy && _heal)
        {
            _healthBarFilling.value = Mathf.MoveTowards(_healthBarFilling.value, currentHealth, _delay * Time.deltaTime);
            Debug.Log(2);
            yield return null;
        }
    }

    private IEnumerator TakeHealth(int currentHealth)
    {
        while (currentHealth <= _healthBarFilling.value - _inaccuracy && _heal == false)
        {
            _healthBarFilling.value = Mathf.MoveTowards(_healthBarFilling.value, currentHealth, _delay * Time.deltaTime);
            Debug.Log(3);
            yield return null;
        }
    }

}
