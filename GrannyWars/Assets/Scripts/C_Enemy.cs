﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Enemy : C_Player
{
    public List<Transform> pointsOfInterest;
	public Transform targetTransform;
	public Vector3 target;
	public C_ObsticlePoint obsticlePoint;
	public float minDistanceToTarget;
	public bool rayCastObsticle;

}
