using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventsManager
{
    public static event Action OnConnectedToMaster = delegate { };
    public static void Fire_evt_ConnectedToMaster()
    {
        OnConnectedToMaster();
    }

    public static event Action OnJoinedLobby = delegate { };
    public static void Fire_evt_JoinedLobby()
    {
        OnJoinedLobby();
    }

    public static event Action OnJoinedRoom = delegate { };
    public static void Fire_evt_JoinedRoom()
    {
        OnJoinedRoom();
    }
}
