using NPCs;
using System;
using UnityEngine;

[Serializable]
public class Enemy : BaseCharacter
{
    public Enemies enemyType;

    public new Sprite GetSprite()
    {
        return EnemyManager.Instance.LoadSpriteByType(enemyType);
    }

    public bool CanBomb()
    {
        switch (enemyType)
        {
            // TODO: Fill out rest of enemies
            case Enemies.Armos:
                return true;
        }
        return false;
    }

    public bool CanArrow()
    {
        switch (enemyType)
        {
            // TODO: Fill out rest of enemies
            case Enemies.Armos:
                return true;
        }
        return false;
    }

    public bool CanWand()
    {
        switch (enemyType)
        {
            case Enemies.Armos:
                return true;
        }
        return false;
    }

    public bool CanCandle()
    {
        switch (enemyType)
        {
            case Enemies.Armos:
                return true;
        }
        return false;
    }

    public bool CanBoomerang()
    {
        switch (enemyType)
        {
            case Enemies.Armos:
                return true;
        }
        return false;
    }
}