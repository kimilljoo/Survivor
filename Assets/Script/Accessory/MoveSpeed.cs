using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeed : Accessory
{
    ConcreteAccessorySubject subject;

    public MoveSpeed(ConcreteAccessorySubject subject)
    {
        this.subject = subject;
        subject.AddAccessory(this);
        Effect();
    }


    public override void Effect()
    {
        MainCharacterScript player = GameObject.Find("Player").GetComponent<MainCharacterScript>();
        player.playerInfomation.moveSpeed += 0.1f;
        Debug.Log("�̵��ӵ� ����");
    }

}
