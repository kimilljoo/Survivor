using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoint : MonoBehaviour
{
    private void GetHitDamage(float damage, ref float health, ref int reviveCount)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;

            if (reviveCount <= 0)
                PlayerDead();
            else
                PlayerRevive();
        }
    }

    private void PlayerDead()
    {

    }

    private void PlayerRevive()
    {

    }
}
