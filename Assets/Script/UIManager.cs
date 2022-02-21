using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private GameObject pause;
    [Header("Number")]
    private int switchNum = 1;

    private void Start()
    {
        Time.timeScale = 1;
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                StartCoroutine(UIFunctions.Instance.BlinkEffectCoroutine(pressToStart,0.5f));
                break;

        }
    }

    private void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleScene":
                if (Input.anyKeyDown)
                {
                    StopAllCoroutines();
                    UIFunctions.Instance.ChangePanel(title, menu);
                }
                break;
            case "GameScene":
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ++switchNum;
                    UIFunctions.Instance.SwitchPanel(pause, ref switchNum);
                }
                break;
        }
    }

    

}
