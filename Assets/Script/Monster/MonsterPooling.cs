using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject monster;
    private List<GameObject> monsters;

    private const float rushTimeToSecond = 180.0f;  // 3�и��� ������ ��. ��, 180s
    private float Timer = 0.0f;                     // 180�ʸ��� �ٲ��ִ°�

    private const int enemyPoolLimit = 300;  // ������Ʈ Ǯ���� ����

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
            GameObject gameObject = Instantiate(monster, transform.position , Quaternion.identity, transform); // Hierarchy â���� �� ���̱� ���� MonsterPool Object�� �ڽ����� �����
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
                monsters.Find(isSpawn => isSpawn.GetComponent<Monster>().isSpawned == false).GetComponent<Monster>().InitEnemy(100.0f, 3, true);
                Timer = 0.0f;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
