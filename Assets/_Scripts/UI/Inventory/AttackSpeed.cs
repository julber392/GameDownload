using TMPro;
using UnityEngine;

public class AttackSpeed : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AttackController _attackSpeed;
    private void Awake()
    {
        _text=GetComponent<TextMeshProUGUI>();
        _text.text=((int)(100/_attackSpeed.attackDelay)).ToString();
    }

    private void OnEnable()
    {
        _attackSpeed.AttackSpeedChanged += Attack;
    }
    
    private void OnDisable()
    {
        _attackSpeed.AttackSpeedChanged += Attack;
    }

    private void Attack(float attackSpeed)
    {
        _text.text = ((int)(100/attackSpeed)).ToString();
    }
}