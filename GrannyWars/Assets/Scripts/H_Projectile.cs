using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Projectile
{
    private readonly C_Projectile[] projectiles;
    private readonly Quaternion direction;
    private readonly int projectileIndex;
    private readonly C_Player player;

    public H_Projectile(
        C_Projectile[] projectiles,
        Quaternion direction,
        int projectileIndex,
        C_Player player)
    {
        this.projectiles = projectiles;
        this.direction = direction;
        this.projectileIndex = projectileIndex;
        this.player = player;

        Shoot();
    }

    private void Shoot()
    {
       // projectiles[projectileIndex].transform.position = player.
    }
}
