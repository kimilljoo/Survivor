using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallizeItem : Item, IItemWork
{
    [Range(0.1f, 1.0f)] public float resultSize;
    [Range(0.0f, 15.0f)] public float duration;
    static public float curSize = 1.0f;
    static public int usingThis = 0;

    public void ItemWork()
    {
        durationItem = true;
        StartCoroutine(SmallizeManage());
    }

    public IEnumerator SmallizeManage()
    {
        if (usingThis++ > 0)
        {
            yield return new WaitForSeconds(duration);
            StartCoroutine(Restoration());
            yield break;
        }
        StartCoroutine(Smallize());
        yield return new WaitForSeconds(duration);
        StartCoroutine(Restoration());
    }

    public IEnumerator Smallize()
    {
        while (curSize > resultSize)
        {
            curSize -= Time.deltaTime;
            curSize = Mathf.Clamp(curSize, resultSize, 1.0f);
            target.transform.localScale = new Vector2(curSize, curSize);
            //플레이어의 속도를 점점 증가시키는 스크립트.
            yield return null;
        }
    }

    public IEnumerator Restoration()
    {
        usingThis--;
        while (curSize < 1.0f && usingThis == 0)
        {
            curSize += Time.deltaTime;
            curSize = Mathf.Clamp(curSize, resultSize, 1.0f);
            target.transform.localScale = new Vector2(curSize, curSize);
            yield return null;
        }

        Destroy(this.gameObject);
    }
}
