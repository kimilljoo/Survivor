using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int pierceAmount = 0;

    public float fixedDamage { get; private set; } = 0.0f;

    public void SetBullet(Vector3 dir , float speed, int pierceAmount, float fixedDamage, bool isRotate = true)
    {
        this.pierceAmount = pierceAmount;
        this.fixedDamage = fixedDamage;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;//각도 구하기

        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);//구한 각도로 변경
        gameObject.GetComponent<Rigidbody2D>().AddForce(dir.normalized * speed);

        if (isRotate == false)
        {
            transform.localRotation = Quaternion.identity;
        }

        Destroy(gameObject, 10.0f);
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        switch(collsion.gameObject.tag)
        {
            case "Enemy":
                if (pierceAmount <= 1)
                    Destroy(gameObject);
                else
                    pierceAmount--;
                break;
        }
    }
}
