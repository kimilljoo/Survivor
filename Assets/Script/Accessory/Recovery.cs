using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : Accessory
{
    ConcreteAccessorySubject subject;

    public Recovery(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.recovery += 0.1f;
        Debug.Log("체력 회복");
    }

}
