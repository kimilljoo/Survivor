using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    [Header("************Infomation************")]
    [SerializeField]    private string charactherName;
    [SerializeField]    public GameObject defaultWeapon;

    [Header("************Stats************")]
    [SerializeField] public float maxHp;                         // 최대체력
    [SerializeField] private float recovery;                     // 재생력
    [SerializeField] private float armor;                          // 방어력
    [SerializeField] private float moveSpeed;                    // 이동속도
    [Space]
    [SerializeField] private float might;                        // 공격력 뻥튀기 . ex) 1.4f면 공격력 40% 증가
    [SerializeField] private float area;                         // 공격 범위 증가. 만약 스킬이 있다면 스킬 이용시 범위도 증가.
    [SerializeField] private float speed;                        // 투사체 속도의 증가.
    [SerializeField] private float duration;                     // 공격 지속시간 증가
    [SerializeField] private int amount;                         // 투사체 갯수의 증가.
    [SerializeField] private float cooldown;                     // 쿨다운의 감소. ex) 0.98f면 쿨타임 2% 감소 or deltaTime에 1.2f 느낌으로 곱해서 20% 쿨감주는 효과같은... 
    [Space]
    [SerializeField] private float luck;                         // 행운, 보물상자나 레벨업시 추가 선택지 or 보상
    [SerializeField] private float growth;                       // 경험치 획득률 증가 ex) 1.4f면 경험치 획득률 40% 증가
    [SerializeField] private float greed;                        // 골드 획득률 증가 ex) 1.4f면 골드 획득률 40% 증가
    [SerializeField] private float magnet;                       // 아이템을 먹는 범위 증가 ex) 1.4f면 범위 40% 증가

    [SerializeField] private int revialCount;                    // 남은 부활 횟수
    [Header("OnlyScript")]
    private float curHp;

    private Accessory accessory;

    public void Start()
    {
        SetPlayerInfomation(PlayerInfomation.Instance.playerInfo);
        accessory = new Accessory();
    }

    public void SetPlayerInfomation(PlayerInfomation.PlayerInfo playerInfo)
    {
        if (playerInfo == null) return;

        this.maxHp += playerInfo.maxHp;
        this.recovery += playerInfo.recovery;
        this.armor += playerInfo.armor;
        this.moveSpeed += playerInfo.moveSpeed;
        this.area += playerInfo.area;
        this.might += playerInfo.might;
        this.speed += playerInfo.speed;
        this.duration += playerInfo.duration;
        this.amount += playerInfo.amount;
        this.cooldown += playerInfo.cooldown;
        this.luck += playerInfo.luck;
        this.growth += playerInfo.growth;
        this.greed += playerInfo.greed;
        this.magnet += playerInfo.magnet;
        this.revialCount += playerInfo.revialCount;

        curHp = this.maxHp;
    }

    public List<float> ReturnPlayerInfo() // list로 리턴, GameManager에서 정보업데이트시 씀. 하드코딩
    {
        List<float> list = new List<float>();

        list.Add(maxHp);
        list.Add(recovery);
        list.Add(armor);
        list.Add(moveSpeed);
        list.Add(area);
        list.Add(might);
        list.Add(speed);
        list.Add(duration);
        list.Add(amount);
        list.Add(cooldown);
        list.Add(luck);
        list.Add(growth);
        list.Add(greed);
        list.Add(magnet);
        list.Add(revialCount);

        return list;
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<PlayerMove>().Move(moveSpeed);
        gameObject.GetComponent<PlayerAttack>().UpdateWeapon(cooldown, might);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        { 
            case "Enemy":
                // 임시 데미지 1 - [방어력 : 0]
                gameObject.GetComponent<PlayerHealthPoint>().GetHitDamage(collision.gameObject.GetComponent<Monster>().damage - armor, ref curHp, ref revialCount);
                break;
        
        }
    }
}
