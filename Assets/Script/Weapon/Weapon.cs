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
    public float fixedDamage { get; protected set; }// Attack 함수 호출시 damage * might 값을 저장하기 위해 있는 것. Enemy에서 이것을 이용하여 데미지 계산을 할 예정임.
    [SerializeField] private int totaldamage;     // 게임 끝날때 나오는 토탈 데미지 계수. 이거랑 플레이 시간이랑 나누면 분당, 초당 데미지를 구할 수 있다.
    [Space]
    [SerializeField] protected float speed;       // 무기 투사체의 속도
    [SerializeField] protected float amount;      // 투사체의 갯수
    [SerializeField] protected float duration;    // 지속시간
    [Space]
    [SerializeField] protected int level;         // 아이템 갯수.

    [Header("*******specificity*******")]
    [SerializeField] private bool is_Non_coolTime = false; // 쿨타임 없는 무기는 쿨타임을 이용해서 공격 속도를 조정하면 됨.
    [SerializeField] private float attackspeed = 0.0f; // 1.0초면 마늘같은 무기가... 1초에 한번씩 공격하는 꼴.
    [Space]
    [SerializeField] private bool is_passive = false; // 패시브 여부

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        // 아이템은 떨어지지 않음. 그리고 내 위치에서부터 공격이 시작되어야 함. 그래서 아이템의 위치를 바꾸어 줄 것.
        if (GameObject.Find("Player"))
        {
            transform.position = GameObject.Find("Player").transform.position;
        }
    }

    public void UpgradeWeaponDamage(float value)
    {
        damage += value; // 무기 Base Damage 업그레이드 . 레벨이 오르면서 생기는 거임.
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
        amount += value; // Base Amount , 그 반지.
    }
    public void UpgradeWeaponDuration(float value)
    {
        duration += value;
    }

    public void UpdateWeapon(float cooldown, float might)
    {
        if (!is_Non_coolTime)
            this.coolTimer += Time.deltaTime * cooldown;

        if (coolTimer >= this.coolTime)
        {
            Attack(damage * might);
            coolTimer = 0.0f;
        }
    }

    public abstract void Attack(float upgradeDamage); // 패턴 구현만 하면 됨. Collsion 이용하는 것도 자식한테...
    public abstract void LevelUp(); // 패턴 구현만 하면 됨. // 레벨업시 Weapon 안에 있는 함수로 업그레이드.
}
