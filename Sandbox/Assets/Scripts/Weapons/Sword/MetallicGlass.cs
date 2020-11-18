namespace Assets.Weapons.Sword
{
    public class MetallicGlass : Weapon
    {
        public MetallicGlass()
        {
            _power = 20f;
            subType = WeaponTypes.Sword;
            subSubType = Swords.MetallicGlass;
        }

        public override void Use()
        {
            // TODOJEF: Do something
        }
    }
}