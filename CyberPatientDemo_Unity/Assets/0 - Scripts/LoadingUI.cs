using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    // UI Screens 
    [SerializeField] private RectTransform[] all_screens;

    private void Awake()
    {
        CenterAllScreens();
    }

    void CenterAllScreens()
    {
        for (int i = 0; i < all_screens.Length; i++)
        {
            all_screens[i].offsetMax = Vector2.one;
            all_screens[i].offsetMin = Vector2.zero;
        }
    }
}
