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
            int Limit = ((int)(rushTimeToSecond / 120.0f)); // 120�� ��������... 0.5�ʴ� �Ѹ��� , 120�� ���Ŀ��� 0.5�ʴ� �θ���, 180�ʰ� �Ѿ�� limit�� 50�� �Ǿ� �� �����ӿ� 50���� ����

            if (Timer >= rushTimeToSecond)
            {
                monsters.Find(isSpawn => isSpawn.GetComponent<Monster>().isSpawned == false).GetComponent<Monster>().InitEnemy(100.0f, 3, true);
                Timer = 0.0f;
                Limit = 50;
            }

            for (int i = 0; i < Limit; i++)
            {
                if (monsters.Find(isSpawn => isSpawn.GetComponent<Monster>().isSpawned == false)) // �׷����� �ֳ� ���� �ľ��ؾ���.
                    monsters.Find(isSpawn => isSpawn.GetComponent<Monster>().isSpawned == false).GetComponent<Monster>().InitEnemy(100.0f, 2, false);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
