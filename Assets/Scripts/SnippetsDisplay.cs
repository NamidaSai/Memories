using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnippetsDisplay : MonoBehaviour
{
    TextMeshProUGUI snippetsText;
    ScoreManager scoreManager;

    void Start()
    {
        snippetsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        snippetsText.text = FindObjectOfType<SettingsHolder>().GetCurrentSnippet();
    }
}