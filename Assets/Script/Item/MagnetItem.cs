using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : Item, IItemWork
{
    private List<Item> ExpItems = new List<Item>();
    public void ItemWork()
    {
        ExpItems.AddRange(GameObject.FindObjectsOfType<ExpItem>());
        foreach (var Item in ExpItems)
        {
            Item.check = true;
            Item.StartFollowTarget();
        }
        ExpItems.Clear();
    }
}
