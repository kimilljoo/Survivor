using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject monster;
    private List<GameObject> monsters;

    private void Start()
    {
        ObjectInit();
    }

    private void ObjectInit()
    {
        monsters = new List<GameObject>();
        for (int i = 0; i < 500; ++i)
        {
            GameObject gameObject = Instantiate(monster);
            monsters.Add(gameObject);
            gameObject.SetActive(false);
        }
    }

}
