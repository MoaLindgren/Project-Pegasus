using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_EnemyMovement : HandlerBehaviour
{
	C_Enemy[] enemies;

	public H_EnemyMovement(C_Enemy[] enemies)
	{
		this.enemies = enemies;
	}

	public void Start()
	{
		foreach (C_Enemy e in enemies)
		{
			setSpawnPosition(e);
			e.targetTransform = e.pointsOfInterest[0];
		}
	}

	public void Tick()
	{
		float _deltaTime = Time.deltaTime;
		foreach (C_Enemy _enemy in enemies)
		{
			if (_enemy.targetTransform != null)
			{
				_enemy.target = _enemy.targetTransform.position - _enemy.targetTransform.position.y * Vector3.up;

				//Calculate distance and direction to target
				Vector3 _direction = _enemy.target - _enemy.transform.position;
				float _directionMag = _direction.magnitude;

				if (_directionMag >= _enemy.minDistanceToTarget)
				{
					//Movement
					_direction = _direction / _directionMag;
					_enemy.transform.position += _direction * _enemy.speed * _deltaTime;

					//Rotation
					_enemy.transform.LookAt(_enemy.transform.position + _direction);
				}
				else
				{
					ChangeTarget(_enemy);
				}
			}
		}
	}

	#region Private methods

	private void setSpawnPosition(C_Enemy p)
	{
		p.transform.position = p.transform.position - Vector3.up * p.transform.position.y;
	}

	private void ChangeTarget(C_Enemy e)
	{
		if(e.pointsOfInterest.Count > 1)
		{
			e.pointsOfInterest.Remove(e.targetTransform);
			e.targetTransform = e.pointsOfInterest[0];
		}
	}

	#endregion
}
