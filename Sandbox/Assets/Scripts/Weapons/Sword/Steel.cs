using UnityEngine;

namespace Assets.Weapons.Sword
{
    public class Steel : Weapon
    {
        public Steel()
        {
            _power = 10f;
            subType = WeaponTypes.Sword;
            subSubType = Swords.Steel;
            color = new Color(192f / 255f, 192f / 255f, 192f / 255f);
        }

        public override void Use()
        {
            // TODOJEF: Do something
        }
    }
}