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
        target = GameObject.FindGameObjectWithTag("Player");
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

        if (animation) // 애니메이션이 존재하지 않을 수도 있음...
            GetComponent<Animation>().clip = animation;

        isSpawned = true;
        gameObject.SetActive(true);

        InitSpawn();
    }

    private void InitSpawn() // 스폰위치를 카메라 밖으로 하는 Func
    {
        int rand = Random.Range(0, 4);

        float x = 0.0f;
        float y = 0.0f;

        switch (rand)
        {
            case 0:
                x = 0.0f;
                y = Random.Range(0.0f, 1.0f); // 왼쪽 아무데나
                break;
            case 1:
                x = 1.0f;
                y = Random.Range(0.0f, 1.0f); // 오른쪽 아무데나
                break;
            case 2:
                y = 0.0f;
                x = Random.Range(0.0f, 1.0f); // 아래쪽 아무데나
                break;
            case 3:
                y = 1.0f;
                x = Random.Range(0.0f, 1.0f); // 위쪽 아무데나
                break;
        }

        Vector3 enemyPosition = Camera.main.ViewportToWorldPoint(new Vector3(x, y, Camera.main.nearClipPlane));
        enemyPosition.z = 0;

        transform.position = enemyPosition;
    }

    private void TraceToTarget() // 추적
    {
        if (!target) return;

        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        float dirToScale = dir.x < 0.0f ? 1.0f : -1.0f;

        if (isBoss)
            dirToScale *= 1.5f; // 보스일 경우 사이즈가 커져야하기 때문에..... ^^

        transform.localScale = new Vector3(dirToScale, transform.localScale.y, transform.localScale.z);
    }

    public void GetDamage(float damage)
    {
        healthPoint -= damage;

        if (healthPoint <= 0)
        {
            healthPoint = 0;
            isSpawned = false;
            gameObject.SetActive(false); // 오브젝트 풀링 적용시 , 위치나 SetActive를 조정하는 방안이 있음. Queue, List를 사용할 수도 있는 것.
        }

        GameObject.Find("MonsterUI").GetComponent<MonsterUIController>().HitDamageUI(Camera.main.WorldToScreenPoint(transform.position), damage.ToString("0")); // 뎀지 0은 말도 안됨 , float를 string으로 바꾸지 않을것임
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                Debug.Log(collision.gameObject.name);
                if (collision.gameObject.GetComponent<Bullet>()) // 움직이는 총알
                {
                    GetDamage(collision.gameObject.GetComponent<Bullet>().fixedDamage); // damage * might;
                    collision.gameObject.GetComponent<Bullet>().parent_Weapon.UpdateTotalDamage(collision.gameObject.GetComponent<Bullet>().fixedDamage);
                }

                else if (collision.gameObject.GetComponent<StillBullet>()) // 안움직이는 총알
                {
                    GetDamage(collision.gameObject.GetComponent<StillBullet>().fixedDamage);
                    collision.gameObject.GetComponent<StillBullet>().parent_Weapon.UpdateTotalDamage(collision.gameObject.GetComponent<StillBullet>().fixedDamage);
                }
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "PassiveWeapon":
                if(collision.gameObject.GetComponent<Weapon>()) // Weapon에서 처리
                {
                    GetDamage(collision.gameObject.GetComponent<Weapon>().fixedDamage); // damage * might;
                    collision.gameObject.GetComponent<Weapon>().UpdateTotalDamage(collision.gameObject.GetComponent<Weapon>().fixedDamage);
                }
                break;
        }
    }
}
