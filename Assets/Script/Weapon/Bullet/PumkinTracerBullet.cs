using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumkinTracerBullet : Bullet
{
    private Rigidbody2D rigid;
    private BoxCollider2D _collider;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        Vector3 _colliderMaxBounds = Camera.main.WorldToScreenPoint(_collider.bounds.max);

        Vector3 _colliderMinBounds = Camera.main.WorldToScreenPoint(_collider.bounds.min);


        if (_colliderMaxBounds.y >= Screen.height || _colliderMinBounds.y <= 0.0f)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -rigid.velocity.y);
        }
        else if ( _colliderMaxBounds.x >= Screen.width || _colliderMinBounds.x <= 0.0f)
        {
            rigid.velocity = new Vector2(-rigid.velocity.x, rigid.velocity.y);
        }
    }
}
