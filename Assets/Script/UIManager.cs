using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pressToStart;


    private void Start()
    {
        StartCoroutine("PressToStartEffect");
    }
    private IEnumerator PressToStartEffect()
    {
        yield return new WaitForSeconds(0.5f);
        pressToStart.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pressToStart.SetActive(true);
        StartCoroutine("PressToStartEffect");

    }



}
