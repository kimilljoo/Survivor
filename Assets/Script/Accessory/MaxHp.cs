using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHp : Accessory
{
    ConcreteAccessorySubject subject;

    public MaxHp(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.maxHp += 10;
        Debug.Log("최대체력 증가");
    }

}
