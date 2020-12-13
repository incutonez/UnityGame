using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

// Idea taken from https://codereview.stackexchange.com/questions/5352/getting-the-value-of-a-custom-attribute-from-an-enum
public class CustomAttribute : Attribute
{
    public string Value { get; set; }
    public string Name { get; set; }

    internal CustomAttribute(string name, string value)
    {
        Name = name;
        Value = value;
    }
}

public class DamageAttribute : Attribute
{
    /// <summary>
    /// This is based on 1/2 heart, so a Damage of 1 will take away:
    /// - 1/2 heart with green ring
    /// - 1/4 heart with blue ring
    /// - 1/8 heart with red ring
    /// </summary>
    public float TouchDamage { get; set; }

    public float WeaponDamage { get; set; }

    internal DamageAttribute(float touchDamage = 0f, float weaponDamage = 0f)
    {
        TouchDamage = touchDamage;
        WeaponDamage = weaponDamage;
    }
}

public class HealthAttribute : Attribute
{
    public int BaseHealth { get; set; }
    public int WhiteSwordHealth { get; set; }
    public int MagicalSwordHealth { get; set; }

    internal HealthAttribute(int baseHealth = 0, int whiteSwordHealth = 0, int magicalSwordHealth = 0)
    {
        BaseHealth = baseHealth;
        if (whiteSwordHealth == 0)
        {
            float temp = baseHealth / 2f;
            WhiteSwordHealth = (int) Math.Ceiling(temp);
        }
        else
        {
            WhiteSwordHealth = whiteSwordHealth;
        }
        if (magicalSwordHealth == 0)
        {
            float temp = baseHealth / 4f;
            MagicalSwordHealth = (int)Math.Ceiling(temp);
        }
        else
        {
            MagicalSwordHealth = magicalSwordHealth;
        }
    }
}

public static class EnumExtensions
{
    // Taken from https://stackoverflow.com/questions/972307/how-to-loop-through-all-enum-values-in-c
    public static List<T> GetValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>().ToList();
    }

    public static string GetDescription(this Enum value)
    {
        return GetCustomAttr(value, "Description");
    }

    public static string GetCustomAttr(this Enum value, string propertyName)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        var field = type.GetField(name);
        if (field != null)
        {
            
            if (propertyName == "Description")
            {
                var attr = field.GetCustomAttribute<DescriptionAttribute>();
                if (attr != null)
                {
                    return attr.Description;
                }
            }
            else
            {
                var attr = field.GetCustomAttribute<CustomAttribute>();
                if (attr != null)
                {
                    return attr.Value;
                }
            }
        }
        return name;
    }
}