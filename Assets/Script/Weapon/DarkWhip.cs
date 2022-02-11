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
        SetPositonAndRotate();
    }
    private void SetPositonAndRotate()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position += new Vector3(direction, 0.0f, 0.0f);

        float h = Input.GetAxis("Horizontal");

        if (h != 0)
            direction = h;

        direction = direction >= 0.01f ? 2.0f : -2.5f;

        if (direction >= 0.01f)
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f); 
        else
            transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
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


            yield return new WaitForSeconds(attackspeed);
        }
        
        yield break;
    }
}
