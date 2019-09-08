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
			o.obsticlePoints = new C_ObsticlePoint[8];
			o.obsticlePoints[0] = o.transform.GetChild(0).GetComponent<C_ObsticlePoint>();
			for (int i = 1; i < 8; i++)
			{
				o.obsticlePoints[i] = o.transform.GetChild(i).GetComponent<C_ObsticlePoint>();
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
		return closestPoint;
		
	}

}
