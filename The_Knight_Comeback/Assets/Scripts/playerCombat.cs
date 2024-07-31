using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{

    public Animator _animator;

    public Transform _attackPoint;
    public LayerMask _enemyLayers;

    public float _attackRange = 0.5f;
    public int _attackDamage = 40;

    public float _attackRate = 2f;
    float nextAttacktime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttacktime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttacktime = Time.time + 1f / _attackRate;
            }
        } 
    }

    void Attack()
    {
        // animation tấn công
        _animator.SetTrigger("isAttack");

        // phát hiện quái trong phạm vi tấn công 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);


        // gây sát thương lên quái 
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(_attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(_attackPoint == null)
            return;

        Gizmos.DrawSphere(_attackPoint.position, _attackRange);
    }

}
