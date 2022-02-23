using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : Accessory
{
    ConcreteAccessorySubject subject;

    public Area(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.area += 0.1f;
        Debug.Log("범위 증가");
    }

}
