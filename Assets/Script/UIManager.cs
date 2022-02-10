using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Object")]
    [SerializeField]
    private GameObject pressToStart;
    [Header("Panels")]
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private GameObject menu;

    private void Start()
    {
        StartCoroutine("PressToStartEffect");
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            PanelChange(title, menu);
        }
    }

    private IEnumerator PressToStartEffect()
    {
        yield return new WaitForSeconds(0.5f);
        pressToStart.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pressToStart.SetActive(true);
        StartCoroutine("PressToStartEffect");

    }

    private void PanelChange(GameObject curPanel,GameObject changePanel)
    {
        curPanel.SetActive(false);
        changePanel.SetActive(true);
    }



}
