using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    bool _isPlayer;

    public float
        currentHealth,
        maxHealth;

    public void AdjustHealth(float healthAdjustmentValue, bool tookDamage = true)
    {
        if (tookDamage)
        {
            currentHealth -= healthAdjustmentValue;

            if (currentHealth <= 0)
                Death();
        }

        else
        {
            currentHealth += healthAdjustmentValue;

            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }
    }

    void Death()
    {
        if (_isPlayer)
            Debug.Log("Player Dead");

        else
            Debug.Log("Enemy Dead");
    }
}
