﻿using System.Linq;
using UnityEngine;

public class SuitHandler : MonoBehaviour
{
    public Texture2D texture;

    private const int textureWidth = 105;
    private const int textureHeight = 76;
    // This is a reference to the green color in the baseTexture that we'll be searching for and replacing
    // TODO: This might be a different value when on different displays, like my laptop wasn't quite 248 / 255f... not sure how to fix this
    private const float baseSuitColor = 247 / Constants.MAX_RGB;
    private readonly static Color greenSuit = new Color(184 / Constants.MAX_RGB, 248 / Constants.MAX_RGB, 24 / Constants.MAX_RGB);
    private readonly static Color blueSuit = new Color(184 / Constants.MAX_RGB, 184 / Constants.MAX_RGB, 248 / Constants.MAX_RGB);
    private readonly static Color redSuit = new Color(248 / Constants.MAX_RGB, 56 / Constants.MAX_RGB, 0 / Constants.MAX_RGB);
    private Color[] baseColors; 

    private void Awake()
    {
        baseColors = Resources.Load<Sprite>("Sprites/characterBase").texture.GetPixels(0, 0, textureWidth, textureHeight);
        SetSuitColor(Items.RingGreen);
    }

    public Color GetSuitColor(Items itemType)
    {
        switch(itemType)
        {
            case Items.RingBlue:
                return blueSuit;
            case Items.RingRed:
                return redSuit;
            default:
                return greenSuit;
        }
    }

    public void SetSuitColor(Items itemType)
    {
        Color suit = GetSuitColor(itemType);
        Color[] colors = baseColors.ToArray();
        for (int i = 0; i < colors.Length; i++)
        {
            Color color = colors[i];
            if (color.g > baseSuitColor && color.a == 1)
            {
                colors[i] = suit;
            }
        }
        texture.SetPixels(0, 0, textureWidth, textureHeight, colors);
        texture.Apply();
    }
}
