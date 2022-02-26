using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAccessorySubject
{
    void AddAccessory(Accessory accessory);
    void RemoveAccessory(Accessory accessory);
    void Notify();
}
