using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    }

    public void OnJoinRoomButtonPressed()
    {
        Debug.Log("Join Room button pressed");
    }
}
