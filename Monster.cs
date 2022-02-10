using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Player
    private GameObject target;

    public bool isSpawned { get; private set; } = false;

    [Header("Stats")]
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float healthPoint = 100.0f;

    public int damage { get; private set; } = 1;
    public bool isBoss { get; private set; } = false;

    private void Start()
    {
        target = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        TraceToTarget();
    }

    public void InitEnemy(float healthPoint = 10.0f, int damage = 1, bool isBoss = false, AnimationClip animation = null)
    {
        this.healthPoint = healthPoint;
        this.damage = damage;

        this.isBoss = isBoss;

        if (this.isBoss)
            transform.localScale = Vector3.one * 1.5f;
        else
            transform.localScale = Vector3.one;

        if (animation) // �ִϸ��̼��� �������� ���� ���� ����...
            GetComponent<Animation>().clip = animation;

        isSpawned = true;
        gameObject.SetActive(true);

        InitSpawn();
    }

    private void InitSpawn() // ������ġ�� ī�޶� ������ �ϴ� Func
    {
        int rand = Random.Range(0, 3);

        float x = 0.0f;
        float y = 0.0f;

        switch (rand)
        {
            case 0:
                x = 0.0f;
                y = Random.Range(0.0f, 1.0f); // ���� �ƹ�����
                break;
            case 1:
                x = 1.0f;
                y = Random.Range(0.0f, 1.0f); // ������ �ƹ�����
                break;
            case 2:
                y = 0.0f;
                x = Random.Range(0.0f, 1.0f); // �Ʒ��� �ƹ�����
                break;
            case 3:
                y = 1.0f;
                x = Random.Range(0.0f, 1.0f); // ���� �ƹ�����
                break;
        }

        Vector3 enemyPosition = Camera.main.ViewportToWorldPoint(new Vector3(x, y, Camera.main.nearClipPlane));
        enemyPosition.z = 0;

        transform.position = enemyPosition;
    }

    private void TraceToTarget() // ����
    {
        if (!target) return;

        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        float dirToScale = dir.x < 0.0f ? 1.0f : -1.0f;

        if (isBoss)
            dirToScale *= 1.5f; // ������ ��� ����� Ŀ�����ϱ� ������..... ^^

        transform.localScale = new Vector3(dirToScale, transform.localScale.y, transform.localScale.z);
    }

    public void GetDamage(float damage)
    {
        healthPoint -= damage;

        if (healthPoint <= 0)
        {
            healthPoint = 0;
            isSpawned = false;
            gameObject.SetActive(false); // ������Ʈ Ǯ�� ����� , ��ġ�� SetActive�� �����ϴ� ����� ����. Queue, List�� ����� ���� �ִ� ��.
        }

        GameObject.Find("MonsterUI").GetComponent<MonsterUIController>().HitDamageUI(Camera.main.WorldToScreenPoint(transform.position), damage.ToString("0")); // ���� 0�� ���� �ȵ� , float�� string���� �ٲ��� ��������
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
