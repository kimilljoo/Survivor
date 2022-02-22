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
        Debug.Log("�ִ� ü�� ����");
    }
    private void Might()
    {
        player.playerInfomation.might += 1;
        Debug.Log("���ݷ� ����");
    }
    private void Amount()
    {
        player.playerInfomation.amount += 10;
        Debug.Log("����ü ����");
    }

    private void Magnet()
    {
        player.playerInfomation.magnet += 10;
        Debug.Log("������ ȹ�� �ݰ� ����");
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
