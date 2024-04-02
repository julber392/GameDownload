using System;
using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform attackPoint;
    public float damage;
    public float attackDelay;
    public float range;
    public LayerMask damageableLayerMask;
    private Animator _animator;
    private float timer;
    private Health playerHP;
    public int vampirism;
    public event Action<float> AttackChanged;
    public event Action<float> AttackSpeedChanged;

    private void Awake()
    {
        vampirism = (int)(damage / 20);
    }

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        playerHP = GetComponent<Health>();
    }

    private void Update()
    {
        Attack();
    }
    private void Attack()
    {
        if (timer <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, range, damageableLayerMask);
                if (enemies.Length != 0)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<DamagebleObject>().TakeDamage(damage);
                        if (playerHP.currentHP < playerHP.maxHP)
                        {
                            playerHP.ChangeHealth(vampirism);
                        }
                    }
                }
                int rand = UnityEngine.Random.Range(1, 3);
                _animator.Play("HeroAttack"+rand);
                _animator.SetInteger("state",10);
                StartCoroutine(DoAttack());
                timer = attackDelay;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        _animator.SetInteger("state",0);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(attackPoint.position,range);
    }

    public void ChangeAttack(float attack)
    {
        damage = attack;
        AttackChanged?.Invoke(attack);
    }
    public void ChangeAttackSpeed(float attack)
    {
        attackDelay = attack;
        AttackSpeedChanged?.Invoke(attack);
    }
}
