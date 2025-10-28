using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AttemptsUI : MonoBehaviour
{
    public TMP_Text label;    
    public string prefix = "Attempts: ";

    void Awake()
    {
        if (!label) label = GetComponent<TMP_Text>();
        Refresh();
    }

    public void Refresh()
    {
        if (label)
            label.text = prefix + Attempts.Current.ToString();
    }
}