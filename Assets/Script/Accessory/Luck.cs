using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luck : Accessory
{
    ConcreteAccessorySubject subject;

    public Luck(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.luck += 0.1f;
        Debug.Log("행운 증가");
    }

}
