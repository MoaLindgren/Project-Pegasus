using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_PlayerAttacking
{
    private readonly C_Player player;
    private readonly EntryPoint entryPoint;
    private readonly C_Projectile[] projectiles;

    private Collider[] enemies = new Collider[1];
    private bool canAttack = false;
    private bool recentlyAttacked = false;
    private bool transformProjectilePos = false;
    private float cooldown;
    private string enemy = "Enemy";
    private H_Projectile projectile;


    public H_PlayerAttacking
    (C_Player player, C_Projectile[] projectiles)
    {
        this.player = player;
        this.projectiles = projectiles;

        cooldown = player.basicAttackCooldown;
    }

    public void Tick()
    {
        Physics.OverlapSphereNonAlloc(player.transform.position, player.basicAttackRange, enemies);
        if (recentlyAttacked)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0f)
            {
                recentlyAttacked = false;
                cooldown = player.basicAttackCooldown;
            }
        }
        else
        {
            canAttack = enemies[0].tag == enemy;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
           // Attack();
            canAttack = false;
            recentlyAttacked = true;
        }

        if (transformProjectilePos)
        {
            projectile.Tick();
        }
    }

    private void Attack()
    {
        switch (player.attackerType)
        {
            case C_Player.AttackerType.Melee:
                break;
            case C_Player.AttackerType.Range:
                Quaternion direction = player.transform.rotation;
                projectile = new H_Projectile(projectiles, direction, 1, player);
                transformProjectilePos = true;
                break;
        }
    }
}
