using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Object")]
    [SerializeField]
    private GameObject pressToStart;
    [SerializeField]
    private GameObject playTimeUI;

    [Header("Panels")]
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject pause;

    [Header("PlayerInformation")]
    [SerializeField]
    private List<GameObject> informationList = new List<GameObject>();

    private void Start()
    {
        Time.timeScale = 1;
        switch(SceneManager.GetActiveScene().name)
        {
            case "TitleScene":
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
                    UIFunctions.Instance.SwitchPanel(pause);
                    UpdateInformation();
                }
                break;
        }
    }

    private void OnGUI()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "GameScene":
                GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                UIFunctions.Instance.UiText(playTimeUI, gameManager.playTime);
                break;
        }
    }


    private void UpdateInformation() // 역시 하드코딩.
    {
        MainCharacterScript playerinfomation = PlayerInfomation.Instance.player.GetComponent<MainCharacterScript>();

        List<float> list = playerinfomation.playerInfomation.ReturnPlayerInfo();

        UpdateInformationText(list);
    }

    private void UpdateInformationText(List<float> list) // 하드코딩. 만약 좋은 방법 있으면 그걸로
    {
        if (list.Count != 15) return;

        for (int i = 0; i < list.Count; i++)
        {
            if (i == 0 || i == 2 || i == 8 || i == 14)
                UIFunctions.Instance.UiText(informationList[i], list[i].ToString());
            else
                UIFunctions.Instance.UiText(informationList[i], ((list[i] * 100) - 100).ToString() + "%");
        }
    }
}
