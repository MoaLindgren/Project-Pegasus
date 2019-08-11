using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_PlayerMovement : MonoBehaviour
{
	C_Player[] players;

	public H_PlayerMovement(C_Player[] playerComponents)
	{
		this.players = playerComponents;
	}

	public void Tick()
	{
		float _horizontalAxis = Input.GetAxis("Horizontal");
		float _verticalAxis = Input.GetAxis("Vertical");
	}
}
