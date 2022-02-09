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
    [SerializeField]
    private float healthPoint = 100.0f;
    public int damage { get; private set; } = 1;

    private void Start()
    {
        target = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        TraceToTarget();
    }

    public void InitEnemy(AnimationClip animation = null, float moveSpeed = 1.0f , float healthPoint = 100.0f, int damage = 1)
    {
        this.moveSpeed = moveSpeed;
        this.healthPoint = healthPoint;
        this.damage = damage;

        if (animation)
            GetComponent<Animation>().clip = animation;
    }

    private void TraceToTarget() // ����
    {
        if (!target) return;

        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        float dirToScale = dir.x < 0.0f ? 1.0f : -1.0f;
        transform.localScale = new Vector3(dirToScale, 1.0f, 1.0f);
    }

    public void GetDamage(float damage)
    {
        healthPoint -= damage;

        if (healthPoint <= 0)
        {
            healthPoint = 0;

            gameObject.SetActive(false); // ������Ʈ Ǯ�� ����� , ��ġ�� SetActive�� �����ϴ� ����� ����. Queue, List�� ����� ���� �ִ� ��.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Weapon":
                GetDamage(collision.gameObject.GetComponentInParent<Weapon>().fixedDamage); // damage * might;
                break;
        }
    }
}
