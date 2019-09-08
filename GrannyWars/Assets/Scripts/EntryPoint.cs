using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
	[SerializeField] private C_Player[] players;
	[SerializeField] private C_Enemy[] enemies;
    [SerializeField] private GameObject objectPool;
    [SerializeField] private int[] nbrOfObjects;

    private H_PlayerMovement movement;
    private H_EnemyMovement enemyMovement;
    private H_PlayerAttacking attacking;



    private void Start()
	{
		movement = new H_PlayerMovement(players);
        attacking = new H_PlayerAttacking(players[0]);
        movement.Start();

		enemyMovement = new H_EnemyMovement(enemies);
		enemyMovement.Start();
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