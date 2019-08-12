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

	//Called every frame by entry point
	public void Tick()
	{
		float _deltaTime = Time.deltaTime;
		
		foreach (C_Player p in players)
		{
			float _horizontalAxis = Input.GetAxis("Horizontal");
			float _verticalAxis = Input.GetAxis("Vertical");
			Vector3 _previousPosition = p.transform.position;
			
			//Calculate position
			Vector3 _position = _previousPosition + (Vector3.forward * _verticalAxis + Vector3.right * _horizontalAxis) * players[0].speed * _deltaTime;
			p.transform.position = _position;

			//Calculate rotation
			Vector3 _direction = _position - _previousPosition;
			_direction = _direction - Vector3.up * _direction.y;
			p.transform.LookAt(p.transform.position + _direction);
		}

	}
	
}
