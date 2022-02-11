using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MonsterUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject Canvas;
    [SerializeField]
    private GameObject textObject;

    public void HitDamageUI(Vector3 position, string damage)              // �¾����� Ư�� ��ġ�� TextObj 
    {
        GameObject HitText = Instantiate(textObject, position, Quaternion.identity, Canvas.transform);

        HitText.GetComponent<Text>().text = damage;

        StartCoroutine(FadeOutText(HitText));
    }

    private IEnumerator FadeOutText(GameObject textObject)  // ������ ������ ȿ��
    {
        while (true)
        {
            textObject.GetComponent<Text>().color *= 0.9f;
            textObject.transform.Translate(Vector3.up); // ������ �����غ��̴� ȿ��.. ������ó��

            yield return new WaitForSeconds(0.1f);

            if (textObject.GetComponent<Text>().color.a <= 0.3f)
            {
                Destroy(textObject);
                yield break;
            }
        }
    }
}
