using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Player
    private GameObject target;

    [Header("Stats")]
    [SerializeField]
    private float moveSpeed = 1.0f;
    public int damage { get; private set; } = 1;

    private void Start()
    {
        target = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        TraceToTarget();
    }

    private void TraceToTarget()
    {
        if (!target) return;

        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        float dirToScale = dir.x < 0.0f ? 1.0f : -1.0f;
        transform.localScale = new Vector3(dirToScale, 1.0f, 1.0f);
    }
}
