using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory
{

    private delegate void Effect();
    private void Hp()
    {
        Debug.Log("최대 체력 증가");
    }
    private void Might()
    {
        Debug.Log("공격력 증가");
    }
    private void Amount()
    {
        Debug.Log("투사체 증가");
    }

    private void Magnet()
    {
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
