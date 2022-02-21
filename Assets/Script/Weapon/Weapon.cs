using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private float coolTimer = 0.0f;

    [Header("**********INFOMATION**********")]
    [SerializeField]
    public string weaponName;

    [Header("**********Stats**********")]
    [SerializeField] private float coolTime = 0.0f;
    [SerializeField] private float damage;
    public float fixedDamage { get; protected set; }// Attack �Լ� ȣ��� damage * might ���� �����ϱ� ���� �ִ� ��. Enemy���� �̰��� �̿��Ͽ� ������ ����� �� ������.
    [SerializeField] private float totaldamage;     // ���� ������ ������ ��Ż ������ ���. �̰Ŷ� �÷��� �ð��̶� ������ �д�, �ʴ� �������� ���� �� �ִ�.
    [SerializeField] protected int pierceAmount;      // �����
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

    private void FixedUpdate()
    {
        // �������� �������� ����. �׸��� �� ��ġ�������� ������ ���۵Ǿ�� ��. �׷��� �������� ��ġ�� �ٲپ� �� ��.
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

    protected void UpgradeWeaponDamage(float value)
    {
        damage += value; // ���� Base Damage ���׷��̵� . ������ �����鼭 ����� ����.
    }
    protected void UpgradeWeaponArea(float value)
    {
        area += value; // ���� Base Area ���׷��̵� . ������ �����鼭 ����� ����.
    }
    protected void UpgradeWeaponSpeed(float value)
    {
        speed += value; // Base Speed
    }
    protected void UpgradeWeaponAttackSpeed(float value)
    {
        attackspeed += value; // Base attack Speed
    }
    protected void UpgradeWeaponCoolTime(float value)
    {
        damage += value; // Base CoolDown
    }
    protected void UpgradeWeaponAmount(int value)
    {
        amount += value; // Base Amount , �� ����.
    }
    protected void UpgradeWeaponDuration(float value)
    {
        duration += value;
    }

    public void UpdateWeapon(float cooldown, float might)
    {
        fixedDamage = damage * might;

        gameObject.transform.localScale = Vector3.one * area;

        if (!is_Non_coolTime)
            this.coolTimer += Time.deltaTime * cooldown;

        if (coolTimer >= this.coolTime)
        {
            Attack();
            coolTimer = 0.0f;
        }
    }

    public void UpdateTotalDamage(float damage)
    {
        totaldamage += damage;
    }

    public abstract void Attack(); // ���� ������ �ϸ� ��. Collsion �̿��ϴ� �͵� �ڽ�����...
    public abstract void LevelUp(); // ���� ������ �ϸ� ��. // �������� Weapon �ȿ� �ִ� �Լ��� ���׷��̵�.
}
