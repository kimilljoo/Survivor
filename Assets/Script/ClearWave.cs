using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearWave : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Waving());
    }

    private IEnumerator Waving()
    {
        while (true)
        {
            transform.localScale += new Vector3(1.0f, 1.0f, 0.0f) * Time.deltaTime;
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Monster>())
            collision.transform.GetComponent<Monster>().GetDamage(1212);
    }
}
