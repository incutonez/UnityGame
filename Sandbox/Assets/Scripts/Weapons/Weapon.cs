using UnityEngine;

namespace Assets.Weapons
{
    public abstract class Weapon : ScriptableObject
    {
        public float _power = 0f;

        public abstract void Attack();
    }
}