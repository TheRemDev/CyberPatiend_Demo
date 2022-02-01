using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    PhotonView photonView;
    Camera mainCam;
    NavMeshAgent agent;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Player clicked on interactable
                if (hit.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();

                    MoveToPoint(interactable.GetInteractionPosition());
                    interactable.Interact(this);
                }
                //Player clicked on something else, moving him/her to position
                else 
                {
                    MoveToPoint(hit.point);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            EventsManager.Fire_evt_PlayerOpenedString("Test message to show on pop up screens");
        }
    }

    private void MoveToPoint(Vector3 point)
    {
        Debug.Log("Moving to position: " + point);
        agent.SetDestination(point);
        agent.isStopped = false;
    }

}
