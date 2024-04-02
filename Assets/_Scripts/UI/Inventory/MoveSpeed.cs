using TMPro;
using UnityEngine;

public class MoveSpeed : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Hero _moveSpeed;
    private void Awake()
    {
        _text=GetComponent<TextMeshProUGUI>();
        _text.text=(_moveSpeed.speed*10).ToString("0.0");
    }

    private void OnEnable()
    {
        _moveSpeed.MoveSpeedChanged += MoveChanged;
    }
    
    private void OnDisable()
    {
        _moveSpeed.MoveSpeedChanged += MoveChanged;
    }

    private void MoveChanged(float moveSpeed)
    {
        _text.text = (moveSpeed*10).ToString("0.0");
    }
}