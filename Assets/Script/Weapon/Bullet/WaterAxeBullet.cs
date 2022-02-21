using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAxeBullet : Bullet
{
    private void FixedUpdate()
    {
        transform.Rotate(0.0f, 0.0f, 2.0f);
    }
}
