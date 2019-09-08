using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed;

    [Header("Damage Settings")]
    public float basicAttackDamage;
    public float basicAttackSpeed;
    public float basicAttackRange;
    public float basicAttackCooldown;
    public float[] abilityAttackDamage;
    public float[] abilityAttackSpeed;
    public float[] abilityCooldown;

}

public struct Ability
{
	float attackDMG;
	float attackSPD;
	float abilityCooldown;
}
