using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class PlayerStats : ScriptableObject
{
	public C_Player.AttackerType attackerType;

	[Header("Movement Settings")]
	public float speed;

	[Header("Health Settings")]
	public float health;

	[Header("Damage Settings")]
	public float basicAttackDamage;
	public float basicAttackSpeed;
	public float basicAttackRange;
	public float basicAttackCooldown;

	public Ability ability;
	public Transform projectileStartPos;
}


