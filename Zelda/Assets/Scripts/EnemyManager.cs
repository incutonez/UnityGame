using NPCs;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will manage all of the enemies needed for the current screen
/// </summary>
public class EnemyManager : BaseManager<EnemyManager>
{
    public static EnemyManager Instance;
    private static List<WorldEnemy> activeEnemies = new List<WorldEnemy>();

    private void Awake()
    {
        Instance = this;
        LoadSprites("Sprites/enemies");
    }

    public static void SpawnEnemy (Vector3 position, Enemies enemyType)
    {
        activeEnemies.Add(Spawn<WorldEnemy, EnemyManager, Enemy, Enemies>(Instance, position, enemyType));
    }
}
