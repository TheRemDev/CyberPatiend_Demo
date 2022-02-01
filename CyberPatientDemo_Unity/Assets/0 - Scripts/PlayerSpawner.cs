using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPositions;

    private void Start()
    {
        //Vector3 position = new Vector3(Random.Range(5, -5), 0, Random.Range(-5, 5));
        Vector3 position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
    }
}
