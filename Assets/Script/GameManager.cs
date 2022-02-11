using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    private bool isEscapemenu = false;

    [SerializeField]
    private List<GameObject> infomationList = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            EscapeMenu();
    }

    private void EscapeMenu()
    {
        isEscapemenu = !isEscapemenu;
        pausePanel.SetActive(isEscapemenu);

        if (isEscapemenu)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        UpdateInformation();
    }

    private void UpdateInformation() // 역시 하드코딩.
    {
        MainCharacterScript playerinfomation = PlayerInfomation.Instance.player.GetComponent<MainCharacterScript>();

        List<float> list = playerinfomation.ReturnPlayerInfo();

        UpdateInformationText(list);
    }

    private void UpdateInformationText(List<float> list) // 하드코딩. 만약 좋은 방법 있으면 그걸로
    {
        if (list.Count != 15) return;

        for (int i = 0; i < list.Count; i++) 
        {
            if (i == 0 || i == 2 || i == 8 || i == 14)
                infomationList[i].GetComponent<Text>().text = list[i].ToString();
            else
                infomationList[i].GetComponent<Text>().text = ((list[i]* 100)-100).ToString() + "%";
        }
    }
}