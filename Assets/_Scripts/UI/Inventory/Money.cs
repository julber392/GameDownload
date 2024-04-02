using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Money : MonoBehaviour
{
    public int money = 0;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        money = PlayerPrefs.GetInt("coins");
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _text.text = money.ToString();
    }
    
    public void AddMoney(int f)
    {
        money = PlayerPrefs.GetInt("coins");
        money += f;
        PlayerPrefs.SetInt("coins",money);
        _text.text = money.ToString();
    }

    public bool RemoveMoney(int g)
    {
        if (money - g < 0)
        {
            return false;
        }
        else
        {
            money = PlayerPrefs.GetInt("coins");
            money -= g;
            PlayerPrefs.SetInt("coins",money);
            _text.text = money.ToString();
            return true;
        }
    }
}
