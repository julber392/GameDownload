using TMPro;
using UnityEngine;

public class Strength : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AttackController _attack;
    private void Awake()
    {
        _text=GetComponent<TextMeshProUGUI>();
        _text.text = _attack.damage.ToString();
    }

    private void OnEnable()
    {
        _attack.AttackChanged += AttackChanged;
    }
    
    private void OnDisable()
    {
        _attack.AttackChanged += AttackChanged;
    }

    private void AttackChanged(float attack)
    {
        _text.text = attack.ToString();
    }
}
