using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumKinTracer : Weapon
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
            Vector3 dir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

            GameObject Bullet = Instantiate(Effect, transform.position, Quaternion.identity);

            Bullet.GetComponent<PumkinTracerBullet>().SetBullet(transform.localScale, dir, speed, 100, fixedDamage, this, duration, false);

            new WaitForSeconds(attackspeed);
        }

        yield break;
    }
}
