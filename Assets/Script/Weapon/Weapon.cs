using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("**********INFOMATION**********")]
    [SerializeField]
    public string weaponName;

    [Header("**********Stats**********")]
    [SerializeField] private float coolTime = 0.0f;
    private float coolTimer = 0.0f;
    [SerializeField] private float damage;
    public float fixedDamage { get; protected set; }// Attack �Լ� ȣ��� damage * might ���� �����ϱ� ���� �ִ� ��. Enemy���� �̰��� �̿��Ͽ� ������ ����� �� ������.
    [SerializeField] private int totaldamage;     // ���� ������ ������ ��Ż ������ ���. �̰Ŷ� �÷��� �ð��̶� ������ �д�, �ʴ� �������� ���� �� �ִ�.
    [Space]
    [SerializeField] protected float attackspeed = 0.14f; // 1.0�ʸ� ���ð��� ���Ⱑ... 1�ʿ� �ѹ��� �����ϴ� ��. ���� ������ ����ӵ�. (RPM)
    [SerializeField] protected float area = 1.0f; // ���� ����
    [SerializeField] protected float speed;       // ���� ����ü�� �ӵ�
    [SerializeField] protected float amount;      // ����ü�� ����
    [SerializeField] protected float duration;    // ���ӽð�
    [Space]
    [SerializeField] protected int level;         // ������ ����.

    [Header("*******specificity*******")]
    [SerializeField] protected bool is_Non_coolTime = false; // ��Ÿ�� ���� ����� ��Ÿ���� �̿��ؼ� ���� �ӵ��� �����ϸ� ��.
    [Space]
    [SerializeField] protected bool is_passive = false; // �нú� ����

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        // �������� �������� ����. �׸��� �� ��ġ�������� ������ ���۵Ǿ�� ��. �׷��� �������� ��ġ�� �ٲپ� �� ��.
        if (GameObject.Find("Player"))
        {
            transform.position = GameObject.Find("Player").transform.position;
        }
    }

    public void UpgradeWeaponDamage(float value)
    {
        damage += value; // ���� Base Damage ���׷��̵� . ������ �����鼭 ����� ����.
    }
    public void UpgradeWeaponArea(float value)
    {
        area += value; // ���� Base Area ���׷��̵� . ������ �����鼭 ����� ����.
    }
    public void UpgradeWeaponSpeed(float value)
    {
        speed += value; // Base Speed
    }
    public void UpgradeWeaponAttackSpeed(float value)
    {
        attackspeed += value; // Base attack Speed
    }
    public void UpgradeWeaponCoolTime(float value)
    {
        damage += value; // Base CoolDown
    }
    public void UpgradeWeaponAmount(int value)
    {
        amount += value; // Base Amount , �� ����.
    }
    public void UpgradeWeaponDuration(float value)
    {
        duration += value;
    }

    public void UpdateWeapon(float cooldown, float might)
    {
        gameObject.transform.localScale = Vector3.one * area;

        if (!is_Non_coolTime)
            this.coolTimer += Time.deltaTime * cooldown;

        if (coolTimer >= this.coolTime)
        {
            Attack(damage * might);
            coolTimer = 0.0f;
        }
    }

    public abstract void Attack(float upgradeDamage); // ���� ������ �ϸ� ��. Collsion �̿��ϴ� �͵� �ڽ�����...
    public abstract void LevelUp(); // ���� ������ �ϸ� ��. // �������� Weapon �ȿ� �ִ� �Լ��� ���׷��̵�.
}
