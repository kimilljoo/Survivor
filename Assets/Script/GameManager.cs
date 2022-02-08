using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Power Up �� �� PlayerInfo�� ���� �����Ͽ� ĳ������ ������ �����ָ� ��.
    /// PlayerInfo�� Upgrade�� ������ GameManager ������ �Լ��θ� �����ǰ� �ϱ� �ٶ�.
    /// </summary>
    public class PlayerInfo
    {
        public float maxHp { get; private set; } = 0.0f;            // ü��
        public float recovery { get; private set; } = 0.0f;         // �����
        public int armor { get; private set; } = 0;                 // ����
        public float moveSpeed { get; private set; } = 4.0f;        // �̵��ӵ�

        public float might { get; private set; } = 1.0f;            // ���ݷ� ��Ƣ�� . ex) 1.4f�� ���ݷ� 40% ����
        public float area { get; private set; } = 1.0f;             // ���� ���� ����. ���� ��ų�� �ִٸ� ��ų �̿�� ������ ����.
        public float speed { get; private set; } = 1.0f;            // ����ü �ӵ��� ����.
        public float duration { get; private set; } = 1.0f;         // ���� ���ӽð� ����
        public int amount { get; private set; } = 0;                // ����ü ������ ����.
        public float cooldown { get; private set; } = 1.0f;         // ��ٿ��� ����. ex) 0.98f�� ��Ÿ�� 2% ���� or deltaTime�� 1.2f �������� ���ؼ� 20% ���ִ� ȿ������... 

        public float luck { get; private set; } = 1.0f;             // ���, �������ڳ� �������� �߰� ������ or ����
        public float growth { get; private set; } = 1.0f;           // ����ġ ȹ��� ���� ex) 1.4f�� ����ġ ȹ��� 40% ����
        public float greed { get; private set; } = 1.0f;            // ��� ȹ��� ���� ex) 1.4f�� ��� ȹ��� 40% ����
        public float magnet { get; private set; } = 1.0f;           // �������� �Դ� ���� ���� ex) 1.4f�� ���� 40% ����

        public int revialCount { get; private set; } = 0;           // ���� ��Ȱ Ƚ��
    }

    public PlayerInfo playerinfo;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
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
}