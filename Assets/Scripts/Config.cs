using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    public const string Achievement1 = "achievement_1";
    public const string Achievement2 = "achievement_2";
    public const string Achievement3 = "achievement_3";
    public const string Achievement4 = "achievement_4";
    public static bool GetValue(string key)
    {
        return PlayerPrefs.GetInt(key, 0) == 1;
    }
    public static void SetValue(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
}
