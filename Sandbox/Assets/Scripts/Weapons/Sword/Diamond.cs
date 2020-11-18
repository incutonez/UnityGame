using UnityEngine;

namespace Assets.Weapons.Sword
{
    public class Diamond : Weapon
    {
        public Diamond()
        {
            _power = 50f;
            subType = WeaponTypes.Sword;
            subSubType = Swords.Diamond;
            color = new Color(185f / 255f, 242f / 255f, 255f / 255f);
        }

        public override void Use()
        {
            // TODOJEF: Do something
        }
    }
}