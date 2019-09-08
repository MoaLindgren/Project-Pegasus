using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Obsticle : HandlerBehaviour
{
	C_Obsticle[] obsticles;

	public H_Obsticle(C_Obsticle[] obsticles)
	{
		this.obsticles = obsticles;
	}

	private void Start()
	{
		foreach(C_Obsticle o in obsticles)
		{
			o.obsticlePoints = new ObsticlePoint[8];
			for (int i = 0; i < 8; i++)
			{
				o.obsticlePoints[i] = o.transform.GetChild(i).GetComponent<ObsticlePoint>();
			}
		}
	}

}
