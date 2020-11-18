using Assets.Weapons;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActions : MonoBehaviour
{
    public List<Weapon> weapons;

    public void CallUse()
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.Use();
        }
    }
}
