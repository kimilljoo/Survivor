using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    [Header("************Infomation************")]
    [SerializeField]    private string charactherName;
    [SerializeField]    public GameObject defaultWeapon;

    [Header("************Stats************")]
    [SerializeField]    private float recovery;                     // �����
    [SerializeField]    public float maxHp;                         // �ִ�ü��
    [SerializeField]    private int armor;                          // ����
    [SerializeField]    private float moveSpeed;                    // �̵��ӵ�
    [SerializeField]    private int maxExp;                    // �̵��ӵ�
    [Space]
    [SerializeField]    private float might;                        // ���ݷ� ��Ƣ�� . ex) 1.4f�� ���ݷ� 40% ����
    [SerializeField]    private float area;                         // ���� ���� ����. ���� ��ų�� �ִٸ� ��ų �̿�� ������ ����.
    [SerializeField]    private float speed;                        // ����ü �ӵ��� ����.
    [SerializeField]    private float duration;                     // ���� ���ӽð� ����
    [SerializeField]    private int amount;                         // ����ü ������ ����.
    [SerializeField]    private float cooldown;                     // ��ٿ��� ����. ex) 0.98f�� ��Ÿ�� 2% ���� or deltaTime�� 1.2f �������� ���ؼ� 20% ���ִ� ȿ������... 
    [Space]
    [SerializeField]    private float luck;                         // ���, �������ڳ� �������� �߰� ������ or ����
    [SerializeField]    private float growth;                       // ����ġ ȹ��� ���� ex) 1.4f�� ����ġ ȹ��� 40% ����
    [SerializeField]    private float greed;                        // ��� ȹ��� ���� ex) 1.4f�� ��� ȹ��� 40% ����
    [SerializeField]    private float magnet;                       // �������� �Դ� ���� ���� ex) 1.4f�� ���� 40% ����
    [Space]
    [SerializeField]    private int revialCount;// ���� ��Ȱ Ƚ��

    [Header("OnlyScript")]
    private float curHp;
    private float curExp;

    public void Start()
    {
        curHp = this.maxHp; // �̱����� �����ؾ߰ڳ�.. GameManager.Instance.playerInfo�� �ȵǴ� ���� �̷��Ը� ������.
    }

    public void SetPlayerInfomation(GameManager.PlayerInfo playerInfo)
    {
        if (playerInfo == null) return;

        this.maxHp += playerInfo.maxHp;
        this.recovery += playerInfo.recovery;
        this.armor += playerInfo.armor;
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

    public void AddPlayerExp(int addExp)
    {
        //�÷��̾��� ����ġ�� ���Ѵ�.
        curExp += addExp;
        //�Ʒ��� �÷��̾��� ������ �ø��� �Լ��� ���� �ִ°� ���� ��
        //������ �Լ��� ����ġ�� ��û���� ���������� ����� ����Լ��� �����.
        if (curExp >= maxExp)
        {
            //�÷��̾��� ������.
            curExp -= maxExp;
        }
    }
    public void HealPlayerHP(float addHP)
    {
        //�÷��̾��� HP�� ȸ����Ų��.
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<PlayerMove>().Move(moveSpeed);
        gameObject.GetComponent<PlayerAttack>().UpdateWeapon(cooldown, might);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        { 
            case "Enemy":
                // �ӽ� ������ 1 - [���� : 0]
                gameObject.GetComponent<PlayerHealthPoint>().GetHitDamage(collision.gameObject.GetComponent<Monster>().damage - armor, ref curHp, ref revialCount);
                break;
            case "Item":
                IItemWork curITemWork = collision.gameObject.GetComponent<IItemWork>();
                if (curITemWork == null)
                    break;
                curITemWork.ItemWork();
                break;
        
        }
    }
}
