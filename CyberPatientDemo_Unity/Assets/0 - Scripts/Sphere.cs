using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;

public class Sphere : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SendNetworkMessage(  other.gameObject.name + " has touched the network sphere !!!");
        }
    }

    // BYTE Event code (1-199) 0 and 200 onwards reserved...
    public const byte NetworkCodeOne = 1;

    private void SendNetworkMessage(string message)
    {
        object[] data = new object[] { message }; // Object with desired data to pass
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
        PhotonNetwork.RaiseEvent(NetworkCodeOne, data, raiseEventOptions, SendOptions.SendReliable);
    }
}
