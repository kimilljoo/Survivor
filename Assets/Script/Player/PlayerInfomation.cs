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
