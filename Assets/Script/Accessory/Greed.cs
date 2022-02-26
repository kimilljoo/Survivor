using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greed : Accessory
{
    ConcreteAccessorySubject subject;

    public Greed(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.greed +=1;
        Debug.Log("µ∑ »πµÊ∑Æ ¡ı∞°");
    }

}
