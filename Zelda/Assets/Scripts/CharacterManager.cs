using UnityEngine;

public class CharacterManager : BaseManager<CharacterManager>
{
    public static T Spawn<T, TOne>(Vector3 position, TOne character) where TOne : BaseCharacter where T : WorldCharacter<TOne>
    {
        RectTransform transform = Instantiate(Instance.prefab, position, Quaternion.identity);

        T worldCharacter = transform.GetComponent<T>();
        worldCharacter.SetCharacter(character);

        return worldCharacter;
    }
}
