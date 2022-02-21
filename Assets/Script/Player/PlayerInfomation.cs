using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation:MonoBehaviour
{
    /// <summary>
    /// Power Up �� �� PlayerInfo�� ���� �����Ͽ� ĳ������ ������ �����ָ� ��.
    /// PlayerInfo�� Upgrade�� ������ PlayerInfo ������ �Լ��θ� �����ǰ� �ϱ� �ٶ�.
    /// </summary>

    public GameObject player; 
    
    public PlayerInfo playerInfo;

    private static PlayerInfomation _instance;

    private static readonly object _lock = new object();

    [Serializable]
    public class PlayerInfo
    {
        public float maxHp = 0.0f;              // ü��
        public float recovery = 0.0f;           // �����
        public int armor = 0;                   // ����
        public float moveSpeed = 4.0f;          // �̵��ӵ�

        [Space]

        public float might = 1.0f;              // ���ݷ� ��Ƣ�� . ex) 1.4f�� ���ݷ� 40% ����
        public float area = 1.0f;               // ���� ���� ����. ���� ��ų�� �ִٸ� ��ų �̿�� ������ ����.
        public float speed = 1.0f;              // ����ü �ӵ��� ����.
        public float duration = 1.0f;           // ���� ���ӽð� ����
        public int amount = 0;                  // ����ü ������ ����.
        public float cooldown = 1.0f;           // ��ٿ��� ����. ex) 0.98f�� ��Ÿ�� 2% ���� or deltaTime�� 1.2f �������� ���ؼ� 20% ���ִ� ȿ������... 

        [Space]

        public float luck = 1.0f;               // ����ġ ȹ��� ���� ex) 1.4f�� ����ġ ȹ��� 40% ����
        public float growth = 1.0f;
        public float greed = 1.0f;              // ��� ȹ��� ���� ex) 1.4f�� ��� ȹ��� 40% ����
        public float magnet = 1.0f;             // �������� �Դ� ���� ���� ex) 1.4f�� ���� 40% ����

        [Space]

        public int revialCount = 0;             // ���� ��Ȱ Ƚ��

        public void SetPlayerInfomation(PlayerInfo playerInfo, ref PlayerInfo playerInfo1)
        {
            if (playerInfo == null) return;
            if (playerInfo1 == null) return;

            playerInfo1.maxHp += playerInfo.maxHp;
            playerInfo1.recovery += playerInfo.recovery;
            playerInfo1.armor += playerInfo.armor;
            playerInfo1.moveSpeed += playerInfo.moveSpeed;
            playerInfo1.area += playerInfo.area;
            playerInfo1.might += playerInfo.might;
            playerInfo1.speed += playerInfo.speed;
            playerInfo1.duration += playerInfo.duration;
            playerInfo1.amount += playerInfo.amount;
            playerInfo1.cooldown += playerInfo.cooldown;
            playerInfo1.luck += playerInfo.luck;
            playerInfo1.growth += playerInfo.growth;
            playerInfo1.greed += playerInfo.greed;
            playerInfo1.magnet += playerInfo.magnet;
            playerInfo1.revialCount += playerInfo.revialCount;
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
    }

    private PlayerInfomation()
    {
        Debug.Log("GameManager Constructor");
    }

    public static PlayerInfomation Instance
    {
        get
        {
            // �ν��Ͻ��� ������� ���
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new PlayerInfomation();
                }
            }

            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}