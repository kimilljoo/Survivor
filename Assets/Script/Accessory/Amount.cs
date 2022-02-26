using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amount : Accessory
{
    ConcreteAccessorySubject subject;

    public Amount(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.amount += 1;
        Debug.Log("투사체 개수 증가");
    }

}
