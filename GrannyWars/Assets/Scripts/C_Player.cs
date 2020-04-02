using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Player : MonoBehaviour
{
	public enum AttackerType
	{
		Range,
		Melee
	}


	[Header("Data")]
	public PlayerStats stats;
	public Ability ability;

	public AttackerType attackerType;

	[Header("Movement Settings")]
	public float speed;

	[Header("Health Settings")]
	public float health;

	[Header("Damage Settings")]
	public float basicAttackDamage;
	public float basicAttackSpeed;
	public float basicAttackRange;
	public float basicAttackCooldown;
	public float[] abilityAttackDamage;
	public float[] abilityAttackSpeed;
	public float[] abilityCooldown;

	[Header("Other Settings || NOT SET WITH DATA ||")]
	public Transform projectileStartPos;


	public void SetValues()
	{
		if (stats != null)
		{
			attackerType = stats.attackerType;
			speed = stats.speed;
			health = stats.health;
			basicAttackDamage = stats.basicAttackDamage;
			basicAttackSpeed = stats.basicAttackSpeed;
			basicAttackRange = stats.basicAttackRange;
			basicAttackCooldown = stats.basicAttackCooldown;
		}
		else
		{
			attackerType = AttackerType.Melee;
			speed = 3;
			health = 10;
			basicAttackDamage = 1;
			basicAttackSpeed = 2;
			basicAttackRange = 50;
			basicAttackCooldown = 0.5f;
		}

	}
}



[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class Ability : ScriptableObject
{
	float attackDMG;
	float attackSPD;
	float abilityCooldown;
}
