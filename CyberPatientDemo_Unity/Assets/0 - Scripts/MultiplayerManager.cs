using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    public static MultiplayerManager Instance;

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
            Debug.Log("Multiplayer Manager Persistent Singleton Created:" + this.name);
        }
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Multiplayer Manager: Connected to master");

        EventsManager.Fire_evt_ConnectedToMaster();

        PhotonNetwork.JoinLobby();
        Debug.Log("Multiplayer Manager: Joining Lobby...");

     
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Multiplayer Manager: Join Lobby Success !");
        EventsManager.Fire_evt_JoinedLobby();
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        EventsManager.Fire_evt_JoinedRoom();

    }

}
