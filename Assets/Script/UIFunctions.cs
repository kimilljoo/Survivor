using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFunctions:MonoBehaviour
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

    public IEnumerator BlinkEffectCoroutine(GameObject blinkGameObject,float sec)
    {
        while(true)
        {
            yield return new WaitForSeconds(sec);
            blinkGameObject.SetActive(false);
            yield return new WaitForSeconds(sec);
            blinkGameObject.SetActive(true);
        }
    }
    public void SwitchPanel(GameObject switchPanel, ref int switchNum)
    {
        switchNum %= 2;
        Time.timeScale = switchNum;
        if (Time.timeScale == 0)
            switchPanel.SetActive(true);
        else if (Time.timeScale == 1)
            switchPanel.SetActive(false);
    }
    public void ChangePanel(GameObject curPanel, GameObject changePanel)
    {
        curPanel.SetActive(false);
        changePanel.SetActive(true);
    }
}
