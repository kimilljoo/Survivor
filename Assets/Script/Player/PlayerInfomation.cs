using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation : MonoBehaviour
{
    /// <summary>
    /// Power Up 할 시 PlayerInfo의 값을 조정하여 캐릭터의 스텟을 더해주면 됨.
    /// PlayerInfo의 Upgrade는 오로지 PlayerInfo 내부의 함수로만 설정되게 하길 바람.
    /// </summary>

    public GameObject player; 
    
    public PlayerInfo playerInfo;

    private static PlayerInfomation _instance;

    private static readonly object _lock = new object();

    [Serializable]
    public class PlayerInfo
    {
        public float maxHp = 0.0f;              // 체력
        public float recovery = 0.0f;           // 재생력
        public int armor = 0;                   // 방어력
        public float moveSpeed = 4.0f;          // 이동속도

        [Space]

        public float might = 1.0f;              // 공격력 뻥튀기 . ex) 1.4f면 공격력 40% 증가
        public float area = 1.0f;               // 공격 범위 증가. 만약 스킬이 있다면 스킬 이용시 범위도 증가.
        public float speed = 1.0f;              // 투사체 속도의 증가.
        public float duration = 1.0f;           // 공격 지속시간 증가
        public int amount = 0;                  // 투사체 갯수의 증가.
        public float cooldown = 1.0f;           // 쿨다운의 감소. ex) 0.98f면 쿨타임 2% 감소 or deltaTime에 1.2f 느낌으로 곱해서 20% 쿨감주는 효과같은... 

        [Space]

        public float luck = 1.0f;               // 경험치 획득률 증가 ex) 1.4f면 경험치 획득률 40% 증가
        public float growth = 1.0f;
        public float greed = 1.0f;              // 골드 획득률 증가 ex) 1.4f면 골드 획득률 40% 증가
        public float magnet = 1.0f;             // 아이템을 먹는 범위 증가 ex) 1.4f면 범위 40% 증가

        [Space]

        public int revialCount = 0;             // 남은 부활 횟수

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

        public List<float> ReturnPlayerInfo() // list로 리턴, GameManager에서 정보업데이트시 씀. 하드코딩
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
            // 인스턴스가 비어있을 경우
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
