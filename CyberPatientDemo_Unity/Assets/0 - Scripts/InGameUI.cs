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
    [Header("Pop Up")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI textLabel;

    [Header("Chat")]
    [SerializeField] private GameObject textMessagePrefab;
    [SerializeField] private RectTransform textMessagesContainer;
    [SerializeField] private TMP_InputField chatInputField;
    [SerializeField] private Button sendMessageButton;

    private void Awake()
    {
        canvasGroup.alpha = 0f;
        textLabel.text = string.Empty;
    }

    public void ShowNetworkMessage(string message)
    {
        canvasGroup.alpha = 1f;
        textLabel.text = message;
        StartCoroutine(ClosePopUp());
    }

    //Shows pop up window with message
    private void ShowChatMessage(string message)
    {
        //Instantiate a new bubble
        GameObject newChatMessageBubble = PhotonNetwork.Instantiate(textMessagePrefab.name, Vector2.zero, Quaternion.identity);
        newChatMessageBubble.transform.SetParent(textMessagesContainer.transform);
        newChatMessageBubble.transform.localScale = Vector3.one;
        newChatMessageBubble.GetComponent<ChatMessage>().InitMessage(message);
    }

    IEnumerator ClosePopUp(float time = 10f)
    {
        yield return new WaitForSeconds(time);
        canvasGroup.alpha = 0f;
        textLabel.text = string.Empty;
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
        else if (eventCode == (byte)2)
        {
            object[] data = (object[])photonEvent.CustomData;
            string message = (string)data[0];
            ShowChatMessage(message);
        }
    }

    public void OnSendButtonPressed()
    {
        if (chatInputField.text != string.Empty)
        {
            string msg = chatInputField.text;
            SendNetworkChatMessage(msg);
            chatInputField.text = string.Empty;
        }
    }

    // BYTE Event code (1-199) 0 and 200 onwards reserved...
    public const byte NetworkCodeTwo = 2;
    private void SendNetworkChatMessage(string message)
    {
        object[] data = new object[] { message }; // Object with desired data to pass
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
        PhotonNetwork.RaiseEvent(NetworkCodeTwo, data, raiseEventOptions, SendOptions.SendReliable);
    }
}
