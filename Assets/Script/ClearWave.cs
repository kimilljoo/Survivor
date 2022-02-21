using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearWave : MonoBehaviour
{
    [Range(1.0f, 100.0f)]
    [SerializeField] float WavingSpeed;
    void Start()
    {
        StartCoroutine(Waving());
        Destroy(this.gameObject, 1.0f);
    }

    private IEnumerator Waving()
    {
        while (true)
        {
            transform.localScale += new Vector3(1.0f, 1.0f, 0.0f) * Time.deltaTime * WavingSpeed;
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Monster>())
            collision.transform.GetComponent<Monster>().GetDamage(1212);
    }

}
