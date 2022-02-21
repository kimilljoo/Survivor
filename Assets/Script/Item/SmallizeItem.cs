using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallizeItem : Item, IItemWork
{
    [SerializeField] private float resultSize;
    [SerializeField] private float duration;
    static private float curSize = 1.0f;
    static private int usingThis = 0;

    public void ItemWork()
    {
        StartCoroutine(Smallize());
    }

    private IEnumerator Smallize()
    {
        if (usingThis++ > 0)
            yield break;
        while(curSize >= resultSize)
        {
            target.transform.localScale = new Vector2(curSize, curSize);
            curSize -= Time.deltaTime;
            yield return null;
        }
        curSize = resultSize;
    }
}
