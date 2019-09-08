using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_EnemyMovement : HandlerBehaviour
{
	C_Enemy[] enemies;
	H_Obsticle obsticleHandler;

	public H_EnemyMovement(C_Enemy[] enemies, H_Obsticle obsticleHandler)
	{
		this.enemies = enemies;
		this.obsticleHandler = obsticleHandler;
		Start();
	}

	public void Start()
	{
		foreach (C_Enemy e in enemies)
		{
			e.rayCastObsticle = true;
			setSpawnPosition(e);
			if (e.pointsOfInterest.Count > 0)
			{
				e.targetTransform = e.pointsOfInterest[0];
			}
		}
	}
	public void Tick()
	{
		float _deltaTime = Time.deltaTime;
		foreach (C_Enemy _enemy in enemies)
		{
			if (_enemy.targetTransform != null)
			{
				//Calculate distance and direction to target
				Vector3 _direction = _enemy.target - _enemy.transform.position;
				float _directionMag = _direction.magnitude;

				if (_enemy.rayCastObsticle)
				{
					_enemy.target = _enemy.targetTransform.position - _enemy.targetTransform.position.y * Vector3.up;
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
					_enemy.rayCastObsticle = !RayCastObsticle(_enemy);
				}
				else
				{
					
					if (_directionMag >= 0.1f)
					{
						//Movement
						_direction = _direction / _directionMag;
						_enemy.transform.position += _direction * _enemy.speed * _deltaTime;

						//Rotation
						_enemy.transform.LookAt(_enemy.transform.position + _direction);
					}
					else
					{
						Vector3 _dir = _enemy.targetTransform.position - _enemy.transform.position;
						RaycastHit _hit;
						if (Physics.Raycast(_enemy.transform.position, _dir, out _hit))
						{
							if(_hit.transform.tag == "Obsticle")
							{
								_enemy.obsticlePoint = _enemy.obsticlePoint.next;
								_enemy.target = _enemy.obsticlePoint.transform.position;
							}
							else
							{
								_enemy.rayCastObsticle = true;
								_enemy.target = _enemy.targetTransform.position;
							}
						}
						else
						{
							_enemy.rayCastObsticle = true;
							_enemy.target = _enemy.targetTransform.position;
						}
					}
				}
			}
		}
	}

	#region Private methods

	private bool RayCastObsticle(C_Enemy e)
	{
		Vector3 _direction = e.target - e.transform.position;
		RaycastHit _hit;
		if (Physics.Raycast(e.transform.position, _direction, out _hit))
		{
			if (_hit.transform.tag == "Obsticle")
			{
				print("<color=red>Obsticle found!</color>");
				C_Obsticle _obs = _hit.transform.GetComponent<C_Obsticle>();
				e.obsticlePoint = obsticleHandler.FindClosestPoint(_obs, e.transform.position);
				e.target = e.obsticlePoint.transform.position;
				return true;
			}
		}

		return false;
	}

	private void setSpawnPosition(C_Enemy p)
	{
		p.transform.position = p.transform.position - Vector3.up * p.transform.position.y;
	}

	private void ChangeTarget(C_Enemy e)
	{
		if (e.pointsOfInterest.Count > 1)
		{
			e.pointsOfInterest.Remove(e.targetTransform);
			e.targetTransform = e.pointsOfInterest[0];
		}
	}

	#endregion
}
