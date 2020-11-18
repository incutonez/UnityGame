using Assets.Weapons;
using System;
using UnityEditor;
using UnityEngine;

public enum ItemTypes
{
    Weapon = 1,
    Elixir = 2,
    Food = 3
}

// Taken from https://stackoverflow.com/a/58307889/1253609
public class Item : MonoBehaviour
{
    public ItemTypes itemType = ItemTypes.Elixir;
    public WeaponTypes subType = WeaponTypes.None;
    public Swords subSubType = Swords.None;
    public GameObject display;

    public virtual void Use()
    {

    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    //public virtual Enum Value
    //{
    //    get
    //    {
    //        switch (itemType)
    //        {
    //            case ItemTypes.Weapon:
    //                return subType;
    //            default:
    //                return null;
    //        }
    //    }
    //}

    //public virtual Enum Value2
    //{
    //    get
    //    {
    //        switch (subType)
    //        {
    //            case WeaponTypes.Sword:
    //                return subSubType;
    //            default:
    //                return null;
    //        }
    //    }
    //}
}

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    SerializedProperty display;
    SerializedProperty itemType;
    SerializedProperty subType;
    SerializedProperty subSubType;

    void OnEnable()
    {
        display = serializedObject.FindProperty("display");
        itemType = serializedObject.FindProperty("itemType");
        subType = serializedObject.FindProperty("subType");
        subSubType = serializedObject.FindProperty("subSubType");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(display);
        EditorGUILayout.PropertyField(itemType);
        switch ((ItemTypes)itemType.intValue)
        {
            case ItemTypes.Weapon:
                EditorGUILayout.PropertyField(subType);
                switch ((WeaponTypes)subType.intValue)
                {
                    case WeaponTypes.Sword:
                        EditorGUILayout.PropertyField(subSubType);
                        break;
                }
                break;
        }
        serializedObject.ApplyModifiedProperties();
    }
}

public class WeaponDisplay: Item
{
    public WeaponDisplay()
    {
        itemType = ItemTypes.Weapon;
    }
}