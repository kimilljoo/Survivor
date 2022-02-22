using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFunctions
{
    private static UIFunctions instance = null;
    public static UIFunctions Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new UIFunctions();
            }
            return instance;
        }
        private set
        {

        }
    }

    public IEnumerator BlinkEffectCoroutine(GameObject blinkGameObject,float sec)//�����̴� ȿ��
    {
        while(true)
        {
            yield return new WaitForSeconds(sec);
            blinkGameObject.SetActive(false);
            yield return new WaitForSeconds(sec);
            blinkGameObject.SetActive(true);
        }
    }
    public void SwitchPanel(GameObject switchPanel)
    {
        if (switchPanel.activeSelf)
        {
            Time.timeScale = 1;
            switchPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            switchPanel.SetActive(true);
        }
    }
    public void ChangePanel(GameObject curPanel, GameObject changePanel)//���� �г��� �����гΰ� �ٲٱ�
    {
        curPanel.SetActive(false);
        changePanel.SetActive(true);
    }

    public void UiText(GameObject text, string printText)
    {
        text.GetComponent<Text>().text = printText;
    }


    public void UiTextMeshPro()
    {

    }


}
