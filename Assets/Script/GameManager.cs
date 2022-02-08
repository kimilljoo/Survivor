using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Power Up 할 시 PlayerInfo의 값을 조정하여 캐릭터의 스텟을 더해주면 됨.
    /// PlayerInfo의 Upgrade는 오로지 GameManager 내부의 함수로만 설정되게 하길 바람.
    /// </summary>
    public class PlayerInfo
    {
        public float maxHp { get; private set; } = 0.0f;            // 체력
        public float recovery { get; private set; } = 0.0f;         // 재생력
        public int armor { get; private set; } = 0;                 // 방어력
        public float moveSpeed { get; private set; } = 4.0f;        // 이동속도

        public float might { get; private set; } = 1.0f;            // 공격력 뻥튀기 . ex) 1.4f면 공격력 40% 증가
        public float area { get; private set; } = 1.0f;             // 공격 범위 증가. 만약 스킬이 있다면 스킬 이용시 범위도 증가.
        public float speed { get; private set; } = 1.0f;            // 투사체 속도의 증가.
        public float duration { get; private set; } = 1.0f;         // 공격 지속시간 증가
        public int amount { get; private set; } = 0;                // 투사체 갯수의 증가.
        public float cooldown { get; private set; } = 1.0f;         // 쿨다운의 감소. ex) 0.98f면 쿨타임 2% 감소 or deltaTime에 1.2f 느낌으로 곱해서 20% 쿨감주는 효과같은... 

        public float luck { get; private set; } = 1.0f;             // 행운, 보물상자나 레벨업시 추가 선택지 or 보상
        public float growth { get; private set; } = 1.0f;           // 경험치 획득률 증가 ex) 1.4f면 경험치 획득률 40% 증가
        public float greed { get; private set; } = 1.0f;            // 골드 획득률 증가 ex) 1.4f면 골드 획득률 40% 증가
        public float magnet { get; private set; } = 1.0f;           // 아이템을 먹는 범위 증가 ex) 1.4f면 범위 40% 증가

        public int revialCount { get; private set; } = 0;           // 남은 부활 횟수
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