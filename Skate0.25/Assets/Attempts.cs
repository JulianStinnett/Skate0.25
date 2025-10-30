using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Attempts
{
    // Key used to store the number of attempts in PlayerPrefs
    const string Key = "Attempts";

    // Returns the current number of attempts (defaults to 0 if none saved)
    public static int Current => PlayerPrefs.GetInt(Key, 0);

    public static void Increment()
    {
        // Increase the attempt count and save it to PlayerPrefs
        PlayerPrefs.SetInt(Key, Current + 1);
        PlayerPrefs.Save();
    }

    public static void Reset()
    {
        // Remove the stored attempt data
        PlayerPrefs.DeleteKey(Key);
        PlayerPrefs.Save();
    }
}