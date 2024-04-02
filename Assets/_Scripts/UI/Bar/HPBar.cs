using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float percantage)
    {
        _healthBar.fillAmount = percantage;
    }
}
