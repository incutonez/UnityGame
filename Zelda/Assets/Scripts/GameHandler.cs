using NPCs;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public void Start()
    {
        CharacterManager.SpawnPlayer(Vector3.zero);
        EnemyManager.SpawnEnemy(new Vector3(-0.245f, 0.004f), Enemies.Armos);
        EnemyManager.SpawnEnemy(new Vector3(-0.45f, 0.004f), Enemies.Gibdo);
        EnemyManager.SpawnEnemy(new Vector3(-0.245f, -0.2f), Enemies.Bubble);
        EnemyManager.SpawnEnemy(new Vector3(-0.45f, -0.2f), Enemies.Moldorm);
    }
}
