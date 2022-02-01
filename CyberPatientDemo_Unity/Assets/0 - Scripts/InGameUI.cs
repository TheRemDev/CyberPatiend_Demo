using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;

public class InGameUI : MonoBehaviour, IOnEventCallback
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI textLabel;

    private void Awake()
    {
        canvasGroup.alpha = 0f;
        textLabel.text = string.Empty;
    }

    public void ShowNetworkMessage(string message)
    {
        canvasGroup.alpha = 1f;
        textLabel.text = string.Format(message);
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        if (eventCode == (byte)1)
        {
            object[] data = (object[])photonEvent.CustomData;
            string message = (string)data[0];
            ShowNetworkMessage(message);
        }
    }
}
