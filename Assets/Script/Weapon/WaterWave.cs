using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWave : Weapon
{
    private float rotateSpeed = 1.0f;

    private void FixedUpdate()
    {
        transform.Rotate(0.0f, 0.0f, rotateSpeed);

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            transform.position = GameObject.Find("Player").transform.position + new Vector3(-0.3f,-1.0f,0.0f);
        }
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
        GetComponent<BoxCollider2D>().enabled = true;

        yield return new WaitForSeconds(duration);

        GetComponent<BoxCollider2D>().enabled = false;

        yield break;    
    }
}
