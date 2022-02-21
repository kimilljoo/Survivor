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
        gameObject.GetComponent<PlayerAttack>().UpdateWeapon(playerInfomation);
        gameObject.GetComponent<PlayerMove>().Move(playerInfomation.moveSpeed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        { 
            case "Enemy":
                // �ӽ� ������ 1 - [���� : 0]
                gameObject.GetComponent<PlayerHealthPoint>().GetHitDamage(collision.gameObject.GetComponent<Monster>().damage - playerInfomation.armor, ref curHp, ref playerInfomation.revialCount);
                break;
        
        }
    }

    public void AddPlayerExp(int Exp)
    {
        //�÷��̾��� Exp�� ���Ѵ�. *������
    }
}
