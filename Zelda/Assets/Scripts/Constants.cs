using UnityEngine;

public static class Constants
{
    public const float MAX_RGB = 255;

    public const float ATTACK_DELAY = 0.2f;
    public const float ATTACK_DELAY_THRESHOLD = 0f;

    public static readonly Vector3 SWORD_RIGHT = new Vector3(0.114f, -0.01f, 0f);
    public static readonly Vector3 SWORD_LEFT = new Vector3(-0.114f, -0.01f, 0f);
    public static readonly Vector3 SWORD_UP = new Vector3(0.015f, 0.11f, 0f);
    public static readonly Vector3 SWORD_DOWN = new Vector3(0.015f, -0.11f, 0f);
    public static readonly Quaternion SWORD_X_ROTATION = Quaternion.Euler(new Vector3(0, 0, -90));
    public static readonly Quaternion SWORD_Y_ROTATION = Quaternion.Euler(new Vector3(0, 0, 0));
}