using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Obsticle : HandlerBehaviour
{
	C_Obsticle[] obsticles;

	public H_Obsticle(C_Obsticle[] obsticles)
	{
		this.obsticles = obsticles;
		Start();
	}

	private void Start()
	{
		foreach(C_Obsticle o in obsticles)
		{
			//Creating path around obsticle
			if(o.obsticlePoints == null)
			{
				o.obsticlePoints = new C_ObsticlePoint[o.transform.GetChild(0).childCount];
			}
			print(o.transform.GetChild(0).GetChild(0).name);
			o.obsticlePoints[0] = o.transform.GetChild(0).GetChild(0).GetComponent<C_ObsticlePoint>();
			for (int i = 1; i < o.obsticlePoints.Length; i++)
			{
				o.obsticlePoints[i] = o.transform.GetChild(0).GetChild(i).GetComponent<C_ObsticlePoint>();
				o.obsticlePoints[i].previous = o.obsticlePoints[i - 1];
				o.obsticlePoints[i].previous.next = o.obsticlePoints[i];
			}
			o.obsticlePoints[0].previous = o.obsticlePoints[o.obsticlePoints.Length -1];
			o.obsticlePoints[o.obsticlePoints.Length - 1].next = o.obsticlePoints[0];
		}
	}

	//Finds the closest obsticle point from a given point
	public C_ObsticlePoint FindClosestPoint(C_Obsticle obsticle,Vector3 point)
	{
		C_ObsticlePoint closestPoint = obsticle.obsticlePoints[0];
		float _distance = int.MaxValue;

		foreach(C_ObsticlePoint op in obsticle.obsticlePoints)
		{
			float _tempDistance = Vector2.Distance(op.transform.position - op.transform.position.y * Vector3.up, point - point.y * Vector3.up);
			if(_tempDistance < _distance)
			{
				_distance = _tempDistance;
				closestPoint = op;
			}
			
		}
		Debug.Log("Returning " + closestPoint.name + " as the closest point");
		return closestPoint;
		
	}

	//Should the AI go clockwise around the obsticle?
	/*
		The obsticle goes through the obsticlepoints one at a time (alternating between clockwise and counter clockwise) and raycast towards our target,
		if the raycast hits the obsticle, we move on to the next node, otherwise, we tell our caller whether the obsticlepoint that
		missed was clockwise or not. 
	 * */
	public bool NavigateClockwise(C_Obsticle obsticle, C_ObsticlePoint point, Vector3 ultimateTarget)
	{
		Transform _obsTransform = obsticle.transform;

		C_ObsticlePoint _next = point.next;
		C_ObsticlePoint _previous = point.previous;

		for (int i = 0; i < obsticle.obsticlePoints.Length *0.5f; i++)
		{
			RaycastHit _hit;
			Vector3 _direction = ultimateTarget - _next.transform.position;
			Debug.DrawRay(_next.transform.position, _direction, Color.blue,5);
			if (Physics.Raycast(_next.transform.position, _direction, out _hit))
			{
				if(_hit.transform.GetComponent<C_Obsticle>() != obsticle)
				{
					return false;
				}
				else
				{
					_next = _next.next;
				}
			}
			else
			{
				return false;
			}
			_direction = ultimateTarget - _previous.transform.position;
			Debug.DrawRay(_previous.transform.position, _direction, Color.red, 5);
			if (Physics.Raycast(_previous.transform.position, _direction, out _hit))
			{
				if (_hit.transform.GetComponent<C_Obsticle>() != obsticle)
				{
					return true;
				}
				else
				{
					_previous = _previous.previous;
				}
			}
			else
			{
				return true;
			}
		}
		return true;
	}

}
