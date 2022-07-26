using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarFilling;
    [SerializeField] private Player _player;

    private Coroutine _changeHealthWork;
    private int _maxDelta;

    private void Start()
    {
        _healthBarFilling.maxValue = _player.MaxHealth;
        _healthBarFilling.value = _healthBarFilling.maxValue;
        _maxDelta = 3;
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
        if (_changeHealthWork != null)
        {
            StopCoroutine(_changeHealthWork);
            _changeHealthWork = StartCoroutine(ChangeHealth(currentHealth));
        }
        else
        {
            _changeHealthWork = StartCoroutine(ChangeHealth(currentHealth));
        }
    }

    private IEnumerator ChangeHealth(int currentHealth)
    {
        while (_healthBarFilling.value != currentHealth)
        {
            _healthBarFilling.value = Mathf.MoveTowards(_healthBarFilling.value, currentHealth, _maxDelta * Time.deltaTime);
            Debug.Log(2);
            yield return null;
        }
    }


}
