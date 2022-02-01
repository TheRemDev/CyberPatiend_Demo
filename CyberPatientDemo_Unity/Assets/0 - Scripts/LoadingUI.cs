using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LoadingUI : MonoBehaviour
{
    // UI Screens
    [Header("UI Screens RectTransforms")]
    [SerializeField] private RectTransform[] all_screens;

    [Header("Create and Join Elements")]
    [SerializeField] private string createdRoomName;
    [SerializeField] private TMP_InputField createRoomImputField;
    [SerializeField] private Button createRoomButton;
    [SerializeField] private string joinedRoomName;
    [SerializeField] private TMP_InputField joinRoomImputField;
    [SerializeField] private Button joinRoomButton;

    private void Awake()
    {
        CenterAllScreens();
        DisableButtons();
        DisableAllScreens();
        all_screens[0].gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        EventsManager.OnJoinedLobby += OnJoinedLobby;
        EventsManager.OnJoinedRoom += OnJoinedRoom;
    }

    private void OnDisable()
    {
        EventsManager.OnJoinedLobby -= OnJoinedLobby;
        EventsManager.OnJoinedRoom -= OnJoinedRoom;
    }

    private void OnJoinedRoom()
    {
   
    }

    private void OnJoinedLobby()
    {
        all_screens[0].gameObject.SetActive(false);
        all_screens[1].gameObject.SetActive(true);
    }

    void CenterAllScreens()
    {
        for (int i = 0; i < all_screens.Length; i++)
        {
            all_screens[i].offsetMax = Vector2.one;
            all_screens[i].offsetMin = Vector2.zero;
        }
    }

    void DisableButtons()
    {
        createRoomButton.interactable = false;
        joinRoomButton.interactable = false;
    }

    public void ValidateCreateRoomInput(string input)
    {
        if (input != string.Empty && input.Length == 5)
        {
            createRoomButton.interactable = true;
            createdRoomName = createRoomImputField.text.ToLower();
        }
        else
        {
            createRoomButton.interactable = false;
            createdRoomName = string.Empty;
        }
    }


    public void ValidateJoinRoomInput(string input)
    {
        if (input != string.Empty && input.Length == 5)
        {
            joinRoomButton.interactable = true;
            joinedRoomName = joinRoomImputField.text.ToLower();
        }
        else
        {
            joinRoomButton.interactable = false;
            joinedRoomName = string.Empty;
        }
    }

    public void OnCreateRoomButtonPressed()
    {
        Debug.Log("Create Room button pressed");
        MultiplayerManager.Instance.CreateRoom(createdRoomName);
    }

    public void OnJoinRoomButtonPressed()
    {
        Debug.Log("Join Room button pressed");
        MultiplayerManager.Instance.JoinRoom(joinedRoomName);
    }

    void DisableAllScreens()
    {
        for (int i = 0; i < all_screens.Length; i++)
        {
            all_screens[i].gameObject.SetActive(false);
        }
    }
}
