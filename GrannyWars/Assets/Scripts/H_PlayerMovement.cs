using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_PlayerMovement: HandlerBehaviour
{
	C_Player[] players;

	public H_PlayerMovement(C_Player[] playerComponents)
	{
		this.players = playerComponents;
	}

	public void Tick()
	{
		float _deltaTime = Time.deltaTime;
		
		foreach (C_Player p in players)
		{
			float _horizontalAxis = Input.GetAxis("Horizontal");
			float _verticalAxis = Input.GetAxis("Vertical");

			p.transform.position += (Vector3.forward * _verticalAxis + Vector3.right * _horizontalAxis) * players[0].speed * _deltaTime;

		}

	}
}
