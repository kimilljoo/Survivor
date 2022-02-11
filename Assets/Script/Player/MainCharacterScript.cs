using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    [Header("************Infomation************")]
    [SerializeField]    private string charactherName;
    [SerializeField]    public GameObject defaultWeapon;

    [Header("************Stats************")]
    [SerializeField] public float maxHp;                         // �ִ�ü��
    [SerializeField] private float recovery;                     // �����
    [SerializeField] private float armor;                          // ����
    [SerializeField] private float moveSpeed;                    // �̵��ӵ�
    [Space]
    [SerializeField] private float might;                        // ���ݷ� ��Ƣ�� . ex) 1.4f�� ���ݷ� 40% ����
    [SerializeField] private float area;                         // ���� ���� ����. ���� ��ų�� �ִٸ� ��ų �̿�� ������ ����.
    [SerializeField] private float speed;                        // ����ü �ӵ��� ����.
    [SerializeField] private float duration;                     // ���� ���ӽð� ����
    [SerializeField] private int amount;                         // ����ü ������ ����.
    [SerializeField] private float cooldown;                     // ��ٿ��� ����. ex) 0.98f�� ��Ÿ�� 2% ���� or deltaTime�� 1.2f �������� ���ؼ� 20% ���ִ� ȿ������... 
    [Space]
    [SerializeField] private float luck;                         // ���, �������ڳ� �������� �߰� ������ or ����
    [SerializeField] private float growth;                       // ����ġ ȹ��� ���� ex) 1.4f�� ����ġ ȹ��� 40% ����
    [SerializeField] private float greed;                        // ��� ȹ��� ���� ex) 1.4f�� ��� ȹ��� 40% ����
    [SerializeField] private float magnet;                       // �������� �Դ� ���� ���� ex) 1.4f�� ���� 40% ����

    [SerializeField] private int revialCount;                    // ���� ��Ȱ Ƚ��

    [Header("OnlyScript")]
    private float curHp;

    public void Start()
    {
        SetPlayerInfomation(PlayerInfomation.Instance.playerInfo);
    }

    public void SetPlayerInfomation(PlayerInfomation.PlayerInfo playerInfo)
    {
        if (playerInfo == null) return;

        this.maxHp += playerInfo.maxHp;
        this.recovery += playerInfo.recovery;
        this.armor += playerInfo.armor;
        this.moveSpeed += playerInfo.moveSpeed;
        this.area += playerInfo.area;
        this.might += playerInfo.might;
        this.speed += playerInfo.speed;
        this.duration += playerInfo.duration;
        this.amount += playerInfo.amount;
        this.cooldown += playerInfo.cooldown;
        this.luck += playerInfo.luck;
        this.growth += playerInfo.growth;
        this.greed += playerInfo.greed;
        this.magnet += playerInfo.magnet;
        this.revialCount += playerInfo.revialCount;

        curHp = this.maxHp;
    }

    public List<float> ReturnPlayerInfo() // list�� ����, GameManager���� ����������Ʈ�� ��. �ϵ��ڵ�
    {
        List<float> list = new List<float>();

        list.Add(maxHp);
        list.Add(recovery);
        list.Add(armor);
        list.Add(moveSpeed);
        list.Add(area);
        list.Add(might);
        list.Add(speed);
        list.Add(duration);
        list.Add(amount);
        list.Add(cooldown);
        list.Add(luck);
        list.Add(growth);
        list.Add(greed);
        list.Add(magnet);
        list.Add(revialCount);

        return list;
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<PlayerAttack>().UpdateWeapon(cooldown, might);
        gameObject.GetComponent<PlayerMove>().Move(moveSpeed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        { 
            case "Enemy":
                // �ӽ� ������ 1 - [���� : 0]
                gameObject.GetComponent<PlayerHealthPoint>().GetHitDamage(collision.gameObject.GetComponent<Monster>().damage - armor, ref curHp, ref revialCount);
                break;
        
        }
    }
}
