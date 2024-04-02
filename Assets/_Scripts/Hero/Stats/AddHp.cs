using UnityEngine;

public class AddHp : MonoBehaviour
{
    private Health obj;
    private Money _money;
    private void Awake()
    {
        obj=GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _money = GameObject.FindGameObjectWithTag("money").GetComponent<Money>();
    }
    public void ChangeMaxHP(int newHp)
    {
        if (_money.money >= 100)
        {
            _money.RemoveMoney(100);
            obj.maxHP += newHp;
        }
    }
}
