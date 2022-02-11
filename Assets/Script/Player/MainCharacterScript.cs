using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    [Header("************Infomation************")]
    [SerializeField]    private string charactherName;
    [SerializeField]    public GameObject defaultWeapon;

    [SerializeField] public PlayerInfomation.PlayerInfo playerInfomation;

    [Header("OnlyScript")]
    private float curHp;

    public void Start()
    {
        SetPlayerInfomation(PlayerInfomation.Instance.playerInfo);
    }

    public void SetPlayerInfomation(PlayerInfomation.PlayerInfo playerInfo)
    {
        if (playerInfo == null) return;

        playerInfomation.maxHp += playerInfo.maxHp;
        playerInfomation.recovery += playerInfo.recovery;
        playerInfomation.armor += playerInfo.armor;
        playerInfomation.moveSpeed += playerInfo.moveSpeed;
        playerInfomation.area += playerInfo.area;
        playerInfomation.might += playerInfo.might;
        playerInfomation.speed += playerInfo.speed;
        playerInfomation.duration += playerInfo.duration;
        playerInfomation.amount += playerInfo.amount;
        playerInfomation.cooldown += playerInfo.cooldown;
        playerInfomation.luck += playerInfo.luck;
        playerInfomation.growth += playerInfo.growth;
        playerInfomation.greed += playerInfo.greed;
        playerInfomation.magnet += playerInfo.magnet;
        playerInfomation.revialCount += playerInfo.revialCount;

        curHp = playerInfomation.maxHp;
    }

    public List<float> ReturnPlayerInfo() // list로 리턴, GameManager에서 정보업데이트시 씀. 하드코딩
    {
        List<float> list = new List<float>();

        list.Add(playerInfomation.maxHp);
        list.Add(playerInfomation.recovery);
        list.Add(playerInfomation.armor);
        list.Add(playerInfomation.moveSpeed);
        list.Add(playerInfomation.area);
        list.Add(playerInfomation.might);
        list.Add(playerInfomation.speed);
        list.Add(playerInfomation.duration);
        list.Add(playerInfomation.amount);
        list.Add(playerInfomation.cooldown);
        list.Add(playerInfomation.luck);
        list.Add(playerInfomation.growth);
        list.Add(playerInfomation.greed);
        list.Add(playerInfomation.magnet);
        list.Add(playerInfomation.revialCount);

        return list;
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<PlayerAttack>().UpdateWeapon(playerInfomation.cooldown, playerInfomation.might);
        gameObject.GetComponent<PlayerMove>().Move(playerInfomation.moveSpeed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        { 
            case "Enemy":
                // 임시 데미지 1 - [방어력 : 0]
                gameObject.GetComponent<PlayerHealthPoint>().GetHitDamage(collision.gameObject.GetComponent<Monster>().damage - playerInfomation.armor, ref curHp, ref playerInfomation.revialCount);
                break;
        
        }
    }
}
