using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("Scene Manager Persistent Singleton Created:" + this.name);
        }
    }

    private void OnEnable()
    {
        EventsManager.OnJoinedRoom += OnJoinedRoom;
    }

    private void OnDisable()
    {
        EventsManager.OnJoinedRoom -= OnJoinedRoom;
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
}


