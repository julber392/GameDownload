using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Equip : MonoBehaviour
{
    [SerializeField] private Sprite icon1;
    [SerializeField] private Sprite icon2;
    [SerializeField] private Sprite icon3;
    [SerializeField] private Sprite icon4;
    [SerializeField] private Sprite icon5;
    [SerializeField] private int[] hp;
    [SerializeField] private int[] _strength;
    [SerializeField] private float[] _attackspeed;
    [SerializeField] private float[] _movespeed;
    private Money _money;
    private Image _image;
    private int _equip = 1;
    private Health _health;
    private AttackController _attack;
    private Hero _movement;
    void Awake()
    {
        _image = GetComponent<Image>();
        _money = GameObject.FindGameObjectWithTag("money").GetComponent<Money>();
        _health=GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _attack=GameObject.FindGameObjectWithTag("Player").GetComponent<AttackController>();
        _movement=GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        _equip++;
        _health.maxHP += hp[0];
        _attack.ChangeAttack(_attack.damage + _strength[0]);
        _attack.ChangeAttackSpeed(_attack.attackDelay - _attackspeed[0]);
        _movement.ChangeMoveSpeed(_movement.speed + _movespeed[0], _movement.jumpForce);
        _image.sprite= icon1;
    }

    public void ChangeEquip()
    {
        switch (_equip)
        {
            case 2:
                if (_money.money>=100)
                {
                    _equip++;
                    _health.maxHP += hp[1];
                    _attack.ChangeAttack(_attack.damage + _strength[1]);
                    _attack.ChangeAttackSpeed(_attack.attackDelay - _attackspeed[1]);
                    _movement.ChangeMoveSpeed(_movement.speed + _movespeed[1], _movement.jumpForce);
                    _image.sprite = icon2;
                    _money.RemoveMoney(100);
                }
                break;
            case 3:
                if (_money.money>=300)
                {
                    _equip++;
                    _health.maxHP += hp[2];
                    _attack.ChangeAttack(_attack.damage + _strength[2]);
                    _attack.ChangeAttackSpeed(_attack.attackDelay - _attackspeed[2]);
                    _movement.ChangeMoveSpeed(_movement.speed + _movespeed[2], _movement.jumpForce);
                    _image.sprite = icon3;
                    _money.RemoveMoney(300);
                }
                break;
            case 4:
                if (_money.money>=500)
                {
                    _equip++;
                    _health.maxHP += hp[3];
                    _attack.ChangeAttack(_attack.damage + _strength[3]);
                    _attack.ChangeAttackSpeed(_attack.attackDelay - _attackspeed[3]);
                    _movement.ChangeMoveSpeed(_movement.speed + _movespeed[3], _movement.jumpForce);
                    _image.sprite = icon4;
                    _money.RemoveMoney(500);
                }
                break;
            case 5:
                if (_money.money>=1000)
                {
                    _equip++;
                    _health.maxHP += hp[4];
                    _attack.ChangeAttack(_attack.damage + _strength[4]);
                    _attack.ChangeAttackSpeed(_attack.attackDelay - _attackspeed[4]);
                    _movement.ChangeMoveSpeed(_movement.speed + _movespeed[4], _movement.jumpForce);
                    _image.sprite = icon5;
                    _money.RemoveMoney(1000);
                }
                break;
        }
    }
}
