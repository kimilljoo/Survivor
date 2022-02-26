using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteAccessorySubject : IAccessorySubject
{
    List<Accessory> inventory = new List<Accessory>();

    public void AddAccessory(Accessory accessory)
    {
        inventory.Add(accessory);
    }

    public void RemoveAccessory(Accessory accessory)
    {
        if (inventory.IndexOf(accessory) > 0)
            inventory.Remove(accessory);
    }

    public void Notify()
    {
        foreach (Accessory accessory in inventory)
        {
            accessory.Effect();
        }
    }

}
