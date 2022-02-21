using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSkull : Weapon
{
    [SerializeField] private GameObject Effect;
    [SerializeField] private List<Vector3> direction = new List<Vector3>();
    public override void Attack()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bullet = Instantiate(Effect, transform.position, Quaternion.identity);

            if (direction[i] != null)
                bullet.GetComponent<Bullet>().SetBullet(transform.localScale, direction[i], speed, pierceAmount, fixedDamage, this, duration);
        }

    }

    private void LevelUP(int lev)
    {

    }

    public override void LevelUp()
    {
        level++;
    }
}
