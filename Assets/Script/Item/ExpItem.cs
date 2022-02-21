using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItem : Item, IItemWork
{
    [SerializeField]
    private int thisExp;
    public void ItemWork()
    {
        target.GetComponent<MainCharacterScript>().AddPlayerExp(thisExp);
    }
}
