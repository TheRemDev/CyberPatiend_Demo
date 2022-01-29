using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        Vector3 position = new Vector3(Random.Range(5, -5), 0, Random.Range(-5, 5));
        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
    }
}
