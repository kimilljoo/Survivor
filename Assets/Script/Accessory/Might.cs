using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Might : Accessory
{
    ConcreteAccessorySubject subject;

    public Might(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.might += 0.1f;
        Debug.Log("공격력 증가");
    }
}
