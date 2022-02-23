using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : Accessory
{
    ConcreteAccessorySubject subject;

    public Growth(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.growth += 0.08f;
        Debug.Log("∞Ê«Ëƒ° »πµÊ∑Æ ¡ı∞°");
    }

}
