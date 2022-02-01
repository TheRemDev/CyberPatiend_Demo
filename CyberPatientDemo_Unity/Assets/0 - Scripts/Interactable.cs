using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected Transform interactionTransform;
    public abstract void Interact(Player player);

    public Vector3 GetInteractionPosition()
    {
        return interactionTransform.position;
    }
}
