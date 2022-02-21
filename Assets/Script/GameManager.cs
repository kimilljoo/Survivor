using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> infomationList = new List<GameObject>();

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            UpdateInformation();
    }

    private void UpdateInformation() // ���� �ϵ��ڵ�.
    {
        MainCharacterScript playerinfomation = PlayerInfomation.Instance.player.GetComponent<MainCharacterScript>();

        List<float> list = playerinfomation.playerInfomation.ReturnPlayerInfo();

        UpdateInformationText(list);
    }

    private void UpdateInformationText(List<float> list) // �ϵ��ڵ�. ���� ���� ��� ������ �װɷ�
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