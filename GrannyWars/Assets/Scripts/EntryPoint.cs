using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
	[SerializeField] private C_Player[] players;
	[SerializeField] private C_Enemy[] enemies;
	[SerializeField] private C_Obsticle[] obsticles;

    [Header("Objectpool")]
    [SerializeField] private C_Projectile[] projectiles = new C_Projectile[20];

    private H_PlayerMovement movement;
    private H_EnemyMovement enemyMovement;
    private H_PlayerAttacking attacking;
	private H_Obsticle obsticle;

    private void Start()
	{
		movement = new H_PlayerMovement(players);
        attacking = new H_PlayerAttacking(players[0], projectiles);
		obsticle = new H_Obsticle(obsticles);
		enemyMovement = new H_EnemyMovement(enemies, obsticle);
	}

	private void Update()
	{
		movement.Tick();
		enemyMovement.Tick();
        attacking.Tick();
    }
}


public class HandlerBehaviour
{
	protected void print(string text)
	{
		Debug.Log(text);
	}
}