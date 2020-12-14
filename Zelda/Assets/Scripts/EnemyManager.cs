using NPCs;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will manage all of the enemies needed for the current screen
/// </summary>
public class EnemyManager : BaseManager<EnemyManager>
{
    private Sprite[] sprites;
    private List<WorldEnemy> activeEnemies = new List<WorldEnemy>();

    private void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("Sprites/enemies");
        activeEnemies.Add(Spawn<WorldEnemy, Enemy>(new Vector3(-0.245f, 0.004f), new Enemy { enemyType = Enemies.Armos }));
        activeEnemies.Add(Spawn<WorldEnemy, Enemy>(new Vector3(-0.45f, 0.004f), new Enemy { enemyType = Enemies.Gibdo }));
        activeEnemies.Add(Spawn<WorldEnemy, Enemy>(new Vector3(-0.245f, -0.2f), new Enemy { enemyType = Enemies.Bubble }));
        activeEnemies.Add(Spawn<WorldEnemy, Enemy>(new Vector3(-0.45f, -0.2f), new Enemy { enemyType = Enemies.Moldorm }));
    }

    public Sprite LoadSpriteByType(Enemies enemyType)
    {
        return LoadSprite(enemyType.GetCustomAttr("Resource"));
    }

    // Idea taken from https://answers.unity.com/questions/1417421/how-to-load-all-my-sprites-in-my-folder-and-put-th.html
    public Sprite LoadSprite(string spriteName)
    {
        Sprite sprite = null;
        foreach (Sprite item in sprites)
        {
            if (item.name == spriteName)
            {
                sprite = item;
                break;
            }
        }
        return sprite;

    }
}
