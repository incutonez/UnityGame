using UnityEngine;

namespace Assets.Weapons.Sword
{
    [CreateAssetMenu(fileName = "Blah", menuName = "Wooden")]
    public class Wooden : Weapon
    {
        public Wooden()
        {
            _power = 5f;
        }

        public override void Attack()
        {
            // TODOJEF: Do something
        }
    }
}