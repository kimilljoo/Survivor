using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillBullet : MonoBehaviour
{
    public Weapon parent_Weapon { get; private set; }
    public float fixedDamage { get; private set; } = 0.0f;

    public void SetStillBullet(Vector3 Scale, Vector3 pos, float fixedDamage, float DestoryTimer, Weapon weapon)
    {
        transform.position = pos;
        transform.localScale = Scale;
        this.fixedDamage = fixedDamage;
        parent_Weapon = weapon;
        Destroy(gameObject, DestoryTimer);
    }
}
