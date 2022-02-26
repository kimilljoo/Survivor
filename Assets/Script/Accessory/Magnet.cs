using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Accessory
{
    ConcreteAccessorySubject subject;

    public Magnet(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }

    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.magnet += 0.1f;
        Debug.Log("æ∆¿Ã≈€ »◊µÊ π¸¿ß ¡ı∞°");
    }

}
