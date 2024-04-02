using UnityEngine;

public class AddAttackSpeed : MonoBehaviour
{
    private AttackController obj;
    private Money _money;
    private void Awake()
    {
        obj=GameObject.FindGameObjectWithTag("Player").GetComponent<AttackController>();
        _money = GameObject.FindGameObjectWithTag("money").GetComponent<Money>();
    }
    public void ChangeAS(float speed)
    {
        if (_money.money > 100)
        {
            _money.RemoveMoney(100);
            obj.ChangeAttackSpeed(obj.attackDelay-speed);
        }
    }
}
