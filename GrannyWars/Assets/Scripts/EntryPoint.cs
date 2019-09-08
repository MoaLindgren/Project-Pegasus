using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
	[SerializeField] C_Player[] players;
	[SerializeField] C_Enemy[] enemies;

	H_PlayerMovement movement;
	H_EnemyMovement enemyMovement;
	private void Start()
	{
		movement = new H_PlayerMovement(players);
		movement.Start();

		enemyMovement = new H_EnemyMovement(enemies);
		enemyMovement.Start();


	}

	private void Update()
	{
		movement.Tick();
		enemyMovement.Tick();
	}
}


public class HandlerBehaviour
{
	protected void print(string text)
	{
		Debug.Log(text);
	}
}
