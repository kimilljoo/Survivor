using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] public List<Weapon> weapons = new List<Weapon>();
    private void Start()
    {
        // defaultWeapon = GetComponent<MainCharacterScript>().defaultWeapon;
        // weapons.Clear();

        // GetWeapon(defaultWeapon.GetComponent<Weapon>());
    }

    public void UpdateWeapon(PlayerInfomation.PlayerInfo playerInfomation)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].UpdateWeapon(playerInfomation);
        }
    }

    public void GetWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void DeleteWeapon(string key)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].name == key)
            {
                weapons.Remove(weapons[i]);
                return;
            }
        }
    }

}
