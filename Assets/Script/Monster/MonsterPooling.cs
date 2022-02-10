using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject monster;
    private List<GameObject> monsters;

    private const float rushTimeToSecond = 180.0f;  // 3분마다 러쉬가 옴. 즉, 180s
    private float Timer = 0.0f;                     // 180초마다 바꿔주는거

    private const int enemyPoolLimit = 300;  // 오브젝트 풀링의 갯수

    private void Awake()
    {
        ObjectInit();
        StartCoroutine(EnemySpawnCoroutine());
    }

    private void FixedUpdate()
    {
        Timer += Time.deltaTime;
    }

    private void ObjectInit()
    {
        monsters = new List<GameObject>();
        monsters.Clear();

        for (int i = 0; i < enemyPoolLimit; ++i)
        {
            GameObject gameObject = Instantiate(monster, transform.position , Quaternion.identity, transform); // Hierarchy 창에서 잘 보이기 위해 MonsterPool Object의 자식으로 상속함
            monsters.Add(gameObject);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        while (true)
        {
            int Limit = ((int)(rushTimeToSecond / 180.0f));

            for (int i = 0; i < Limit; i++)
                monsters.Find(isSpawn => isSpawn.GetComponent<Monster>().isSpawned == false).GetComponent<Monster>().InitEnemy(100.0f, 2, false);

            if (Timer >= rushTimeToSecond)
            {
                monsters.Find(isSpawn => isSpawn.GetComponent<Monster>().isSpawned == false).GetComponent<Monster>().InitEnemy(100.0f, 2, true);
                Timer = 0.0f;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
