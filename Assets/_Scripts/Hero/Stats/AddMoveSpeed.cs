using UnityEngine;

public class AddMoveSpeed : MonoBehaviour
{
    private Hero obj;
    private Money _money;
    private void Awake()
    {
        obj=GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        _money = GameObject.FindGameObjectWithTag("money").GetComponent<Money>();
    }
    public void ChangeMS(float ms)
    {
        if (_money.money > 100)
        {
            _money.RemoveMoney(100);
            obj.ChangeMoveSpeed(obj.speed+ms, obj.jumpForce);
        }
    }
}
