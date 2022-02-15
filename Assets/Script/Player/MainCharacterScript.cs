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
        playerInfomation.SetPlayerInfomation(PlayerInfomation.Instance.playerInfo, ref playerInfomation);

        curHp = playerInfomation.maxHp;
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
