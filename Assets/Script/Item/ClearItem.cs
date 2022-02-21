using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearItem : Item, IItemWork
{
    [SerializeField] private GameObject Wave;
    public void ItemWork()
    {
        Instantiate(Wave, target.transform.position, Wave.transform.rotation);
    }
}
