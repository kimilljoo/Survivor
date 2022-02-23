using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public float spawnRadius;
    public float spawnTime;
    public List<GameObject> Items = new List<GameObject>();
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            anim.SetTrigger("Open");
            int rand = Random.Range(0, Items.Count);
            Instantiate(Items[rand], this.transform.position + new Vector3(0.0f, 0.0f, 0.0f), Items[rand].transform.rotation);
        }
    }
}
