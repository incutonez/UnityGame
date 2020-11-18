using UnityEngine;

namespace Assets.Weapons.Sword
{
    [CreateAssetMenu(fileName = "Blah", menuName = "Wooden")]
    public class Wooden : Weapon
    {
        public Wooden()
        {
            _power = 5f;
            subType = WeaponTypes.Sword;
            subSubType = Swords.Wooden;
            color = new Color(139f / 255f, 69f / 255f, 19f / 255f);
        }

        public override void Use()
        {
            // TODOJEF: Do something
        }
    }
}