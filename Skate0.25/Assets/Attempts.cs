using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public static class Attempts
{
    const string Key = "Attempts";

    public static int Current => PlayerPrefs.GetInt(Key, 0);

    public static void Increment()
    {
        PlayerPrefs.SetInt(Key, Current + 1);
        PlayerPrefs.Save();
    }

    public static void Reset()
    {
        PlayerPrefs.DeleteKey(Key);
        PlayerPrefs.Save();
    }
}