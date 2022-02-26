using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Accessory
{
    ConcreteAccessorySubject subject;

    public Armor(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.armor += 1;
        Debug.Log("방어력 증가");
    }

}
