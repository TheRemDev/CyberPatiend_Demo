using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ChatMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageLabel;

    public void InitMessage(string msg)
    {
        messageLabel.text = msg;
    }
}
