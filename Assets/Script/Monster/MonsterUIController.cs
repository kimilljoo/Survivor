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

    public void HitDamageUI(Vector3 position, string damage)              // 맞았을때 특정 위치에 TextObj 
    {
        GameObject HitText = Instantiate(textObject, position, Quaternion.identity, Canvas.transform);

        HitText.GetComponent<Text>().text = damage;

        StartCoroutine(FadeOutText(HitText));
    }

    private IEnumerator FadeOutText(GameObject textObject)  // 서서히 꺼지는 효과
    {
        while (true)
        {
            textObject.GetComponent<Text>().color *= 0.9f;
            textObject.transform.Translate(Vector3.up);

            textObject.transform.localScale *= 1.1f;

            yield return new WaitForSeconds(0.1f);

            if (textObject.GetComponent<Text>().color.a <= 0.6f)
            {
                textObject.transform.localScale *= 0.9f;
            }

            if (textObject.GetComponent<Text>().color.a <= 0.3f)
            {
                Destroy(textObject);
                yield break;
            }
        }
    }
}
