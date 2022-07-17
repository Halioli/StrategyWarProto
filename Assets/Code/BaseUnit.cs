using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public enum State
    {
        Nothing,
        Moving,
        AttackingRanged,
        AttackingMelee,
        Dying
    }

    // Health
    public float maxHealth;
    public float currentHeath;

    // Damage
    public float meleeDamage;
    public float rangedDamage;

    // Movement
    public float maxMovementSpeed;
    public float currentMovementSpeed;
}
