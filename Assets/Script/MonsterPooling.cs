using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject monster;
    private List<GameObject> monsters;

    private void Awake()
    {
        ObjectInit();
    }

    private void ObjectInit()
    {
        monsters = new List<GameObject>();
        monsters.Clear();

        for (int i = 0; i < 300; ++i)
        {
            GameObject gameObject = Instantiate(monster, transform.position , Quaternion.identity, transform); // Hierarchy â���� �� ���̱� ���� MonsterPool Object�� �ڽ����� �����
            monsters.Add(gameObject);
            gameObject.SetActive(false);
        }
    }

}
