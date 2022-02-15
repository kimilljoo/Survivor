using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWhip : Weapon
{
    [SerializeField]
    private GameObject WhipEffect;

    private float direction = -2.5f;
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h >= 0.01f)
            direction = 2.0f;
        else
            direction = 2.5f;
    }
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
            GameObject bullet = Instantiate(WhipEffect, transform.position + new Vector3(direction, 0.0f, 0.0f), Quaternion.identity, transform);

            if(direction == 2.5f)
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + 180.0f);
            }

            Destroy(bullet, 0.25f);

            yield return new WaitForSeconds(attackspeed);

            direction = direction == 2.0f ? 2.5f : 2.0f;
        }

        yield break;
    }
}
