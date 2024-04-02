using UnityEngine;

public class AddStrength : MonoBehaviour
{
    private AttackController obj;
    private Money _money;
    private void Awake()
    {
        obj=GameObject.FindGameObjectWithTag("Player").GetComponent<AttackController>();
        _money = GameObject.FindGameObjectWithTag("money").GetComponent<Money>();
    }
    public void ChangeStrength(int strength)
    {
        if (_money.money > 100)
        {
            _money.RemoveMoney(100);
            obj.ChangeAttack(obj.damage+strength);
        }
    }
}
