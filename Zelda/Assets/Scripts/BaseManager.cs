using UnityEngine;

public class BaseManager<T> : MonoBehaviour
{
    public static T Instance { get; private set; }
    public RectTransform prefab;

    private void Awake()
    {
        Instance = this;
    }

    public static T Spawn<T, TOne>(Vector3 position, TOne character) where TOne : BaseCharacter where T : WorldCharacter<TOne>
    {
        RectTransform transform = Instantiate(this.Instance.prefab, position, Quaternion.identity);

        T worldCharacter = transform.GetComponent<T>();
        worldCharacter.SetCharacter(character);

        return worldCharacter;
    }
}
