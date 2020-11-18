using System;
using System.Reflection;
using UnityEngine;

namespace Assets.Weapons
{
    public enum WeaponTypes
    {
        None = 0,
        Sword = 1
    }

    /**
     * virtual (feels the most loose)
     * - can have impl in base class
     * - can have override in extending class
     */

    /**
     * abstract (seems like middleground)
     * - cannot be instantiated directly
     * - has definition in base class
     * - must have impl/override in extending class
     */

    /**
     * interfaces (strictest)
     * - cannot be instantiated directly
     * - provides contract details only, no impl
     * - derived classes must impl
     * - cannot contain constants, fields, operators, instance constructors, destructors, or types.
     * - cannot contain static members.
     */

    public class Weapon : Item
    {
        public float _power = 0f;
        public Color color;

        public Weapon()
        {
            itemType = ItemTypes.Weapon;
        }
    }
}