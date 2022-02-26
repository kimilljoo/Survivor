using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTime : Accessory
{
    ConcreteAccessorySubject subject;

    public CoolTime(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.cooldown -= 0.8f;
        Debug.Log("ÄðÅ¸ÀÓ °¨¼Ò");
    }

}
