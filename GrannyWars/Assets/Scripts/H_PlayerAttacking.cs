using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_PlayerAttacking
{
    private readonly C_Player playerComponent;

    private Collider[] enemies = new Collider[1];
    private bool canAttack = false;
    private bool recentlyAttacked = false;
    private float cooldown;
    private string enemy = "Enemy";

    public H_PlayerAttacking
    (C_Player playerComponent)
    {
        this.playerComponent = playerComponent;

        cooldown = playerComponent.basicAttackCooldown;
    }

    public void Tick()
    {
        Physics.OverlapSphereNonAlloc(playerComponent.transform.position, playerComponent.basicAttackRange, enemies);
        if (recentlyAttacked)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0f)
            {
                recentlyAttacked = false;
                cooldown = playerComponent.basicAttackCooldown;
            }
        }
        else
        {
            canAttack = enemies[0].tag == enemy;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            Attack();
            canAttack = false;
            recentlyAttacked = true;
        }
    }

    private void Attack()
    {
        Debug.Log("Attack!");
    }
}
