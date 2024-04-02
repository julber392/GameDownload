using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class procentVolume : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;
    void Start()
    {
        _text.text=Mathf.RoundToInt(_slider.value* 100) + "%";

    }
    void Update()
    {
        _text.text=Mathf.RoundToInt(_slider.value* 100) + "%";
    }
}
