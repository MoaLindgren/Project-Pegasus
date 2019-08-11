using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
	[SerializeField] C_Player[] players;

	H_PlayerMovement movement;
	private void Start()
	{
		movement = new H_PlayerMovement(players);
	}

	private void Update()
	{
		movement.Tick();
	}
}


public class HandlerBehaviour
{
	protected void print(string text)
	{
		Debug.Log(text);
	}
}
