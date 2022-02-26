using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Accessory
{
    ConcreteAccessorySubject subject;

    public Speed(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.speed += 0.1f;
        Debug.Log("투사체 속도 증가");
    }

}
