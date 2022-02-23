using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revial : Accessory
{
    ConcreteAccessorySubject subject;

    public Revial(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.revialCount += 1;
        Debug.Log("부활 횟수 증가");
    }

}
