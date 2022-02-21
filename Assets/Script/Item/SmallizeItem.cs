using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallizeItem : Item, IItemWork
{
    [Range(0.1f,1.0f)]
    [SerializeField] private float resultSize;
    [SerializeField] private float duration;
    static private int UsingThis = 0;
    static private float curSize = 1.0f;

    public void ItemWork()
    {
    }

    private IEnumerator ManageThis()
    {
        StartCoroutine(Smallize());
        yield return new WaitForSeconds(duration);
        if (--UsingThis != 0)
            yield break;
//        while(curSize )
    }

    private IEnumerator Smallize()
    {
        UsingThis++;
        if (curSize == resultSize)
            yield break;
        while(curSize >= resultSize)
        {
            //시간 경과에 따라 스피드를 올려주는 스크립트
            curSize -= Time.deltaTime;
            target.transform.localScale = new Vector2(curSize, curSize);
            yield return null;
        }
        curSize = resultSize;
        target.transform.localScale = new Vector2(curSize, curSize);
    }
}
