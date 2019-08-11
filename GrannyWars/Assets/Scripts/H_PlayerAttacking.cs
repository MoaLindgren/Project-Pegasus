using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_PlayerAttacking
{
    private Collider[] enemies;
    private C_Player[] playerComponent;
    private bool canAttack = false;

    public H_PlayerAttacking(C_Player[] playerComponent)
    {
        this.playerComponent = playerComponent;
    }

    void Tick()
    {
        Physics.OverlapSphereNonAlloc(playerComponent[0].transform.position, playerComponent[0].basicAttackRange, enemies);

        if(enemies.Length > 0)
        {
            canAttack = true;
        }
    }

    private void Attack()
    {

    }
}
