using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.Networking;
using System;

public class TV : Interactable
{
    // BYTE Event code (1-199) 0 and 200 onwards reserved...
    public const byte NetworkCodeOne = 1;
    public string URL;

    private void SendNetworkMessage(string message)
    {
        object[] data = new object[] { message }; // Object with desired data to pass
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
        PhotonNetwork.RaiseEvent(NetworkCodeOne, data, raiseEventOptions, SendOptions.SendReliable);
    }

    public override void Interact(Player player)
    {
        StartCoroutine(InteractWhenReachedDestination(player));
    }

    IEnumerator InteractWhenReachedDestination(Player player)
    {
        bool has_reached_destination = false;

        while (!has_reached_destination)
        {
            float distance = Vector3.Distance(interactionTransform.position, player.transform.position);
            //Debug.Log("distance from tv and " + player.name + ": " + distance);

            if (distance <= 0.5f)
            {
                has_reached_destination = true;
            }

            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        //SendNetworkMessage("Player interacted with TV");
        //TODO Change this to actual message from URL

        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;

            string resultAsString = System.Text.Encoding.UTF8.GetString(results);

            string simpleFormat = resultAsString.Replace(',', '\n');

            SendNetworkMessage(simpleFormat);
        }
    }
}
