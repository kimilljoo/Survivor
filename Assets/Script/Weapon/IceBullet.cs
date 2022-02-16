using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Weapon
{
    [SerializeField]
    private GameObject Effect;

    private Vector2 direction = new Vector2(0.0f, 1.0f);

    public override void Attack()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
            direction = new Vector2(h, v);

        StartCoroutine(AttackCoroutine());
    }

    public override void LevelUp()
    {
        level++;
    }

    private IEnumerator AttackCoroutine()
    {
        if (!Effect) yield break;

        for (int i = 0; i < amount; i++)
        {
            GameObject bullet = Instantiate(Effect, transform.position, Quaternion.identity);

            bullet.GetComponent<Bullet>().SetBullet(transform.localScale, direction.normalized, speed, pierceAmount, fixedDamage, this, duration);

            yield return new WaitForSeconds(attackspeed);
        }
    }
}
