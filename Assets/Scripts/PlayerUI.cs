using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI promptText;
    void Start()
    {
        
    }

    public void UpdateText(string message)
    {
        promptText.text = message;
    }
}
