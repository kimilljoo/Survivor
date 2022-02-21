using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAxe : Weapon
{
    [SerializeField] private GameObject Effect;

    public override void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    public override void LevelUp()
    {
        level++;
    }

    private IEnumerator AttackCoroutine()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bullet = Instantiate(Effect, transform.position, Quaternion.identity);

            bullet.GetComponent<Bullet>().SetBullet(transform.localScale, new Vector3(Random.Range(-0.4f, 0.4f), 1.0f), speed ,pierceAmount, fixedDamage, this, duration);

            yield return new WaitForSeconds(attackspeed);
        }

        yield break;
    }
}
