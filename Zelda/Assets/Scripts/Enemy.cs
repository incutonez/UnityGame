using NPCs;
using System;
using UnityEngine;

[Serializable]
public class Enemy
{
    public Enemies enemyType;

    // TODO: Get this from the enum
    private int strength;
    private int health;

    public Sprite GetSprite()
    {
        return EnemyManager.Instance.LoadSpriteByType(enemyType);
    }

    
}