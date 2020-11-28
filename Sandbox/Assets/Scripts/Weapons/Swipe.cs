using UnityEngine;
using System.Collections;
using Assets.Weapons;

namespace Assets.Scripts.Weapons
{
    public class Swipe : Weapon
    {
        public Transform position;
        public float range;

        // TODO: Get character to hold weapon, then use https://www.youtube.com/watch?v=35BmB7s3OfY
        public override void Use()
        {
            RaycastHit hit;
            if (Physics.Raycast(position.position, position.forward, out hit, range))
            {
                //print($"I HIT YOU {hit.transform}");
            }
        }
    }
}