using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory
{
    
    MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();

    private delegate void Effect();
    private void Hp()
    {
        player.playerInfomation.maxHp += 10;
        Debug.Log("최대 체력 증가");
    }
    private void Might()
    { 
        player.playerInfomation.might += 1;
        Debug.Log("공격력 증가");
    }
    private void Amount()
    {
        player.playerInfomation.amount += 10;
        Debug.Log("투사체 증가");
    }

    private void Magnet()
    {
        player.playerInfomation.magnet += 10;
        Debug.Log("아이템 획득 반경 증가");
    }


    public Accessory()
    {
        Effect effect = new Effect(Hp);
        effect += new Effect(Might);
        effect += new Effect(Amount);
        effect += new Effect(Magnet);
        effect();
    }
}
