using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_PlayerMovement: HandlerBehaviour
{
	C_Player[] players;

	public H_PlayerMovement(C_Player[] playerComponents)
	{
		this.players = playerComponents;
		Start();
	}

	public void Start()
	{
		foreach (C_Player p in players)
		{
			setSpawnPosition(p);
		}
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
			Vector3 _velocity = (Vector3.forward * _verticalAxis + Vector3.right * _horizontalAxis).normalized;
			_velocity *= players[0].speed * _deltaTime;
			Vector3 _position = _previousPosition + _velocity;
			p.transform.position = _position;

			//Calculate rotation
			Vector3 _direction = _position - _previousPosition;
			_direction = _direction - Vector3.up * _direction.y;
			p.transform.LookAt(p.transform.position + _direction);
		}

	}

	#region Private methods

	void setSpawnPosition(C_Player p)
	{
		p.transform.position = p.transform.position - Vector3.up * p.transform.position.y;
	}

	#endregion

}
