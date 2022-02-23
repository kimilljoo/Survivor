using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;
    public static ItemManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<ItemManager>();
                instance.name = "ItemManager";
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField] private GameObject Chest;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
        StartCoroutine(SpawnChest());
    }

    private void FixedUpdate()
    {
        transform.position = Player.transform.position;
        transform.Rotate(Vector3.forward * 1000.0f * Time.deltaTime);
    }

    private IEnumerator SpawnChest()
    {
        Chest ChestCS = Chest.GetComponent<Chest>();
        while (Player != null)
        {
            yield return new WaitForSeconds(Random.Range(ChestCS.spawnTime * 0.5f, ChestCS.spawnTime) * 1.5f);
            Instantiate(Chest, this.transform.position + this.transform.right * Random.Range(ChestCS.spawnRadius,ChestCS.spawnRadius * 1.5f), Chest.transform.rotation);
        }
    }


}
