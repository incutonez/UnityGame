using NPCs;
using UnityEngine;

public class CharacterManager : BaseManager<CharacterManager>
{
    public static CharacterManager Instance;

    public void Awake()
    {
        Instance = this;
        LoadSprites("Sprites/characters");
    }

    public static PlayerCharacter SpawnPlayer(Vector3 position)
    {
        RectTransform transform = Instantiate(Instance.prefab, position, Quaternion.identity);

        PlayerCharacter worldCharacter = transform.GetComponent<PlayerCharacter>();
        BaseCharacter character = new BaseCharacter { characterType = Characters.Link };
        worldCharacter.SetCharacter(character);

        return worldCharacter;
    }
}
