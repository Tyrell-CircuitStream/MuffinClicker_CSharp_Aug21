using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuffinButton : MonoBehaviour
{

    [SerializeField] private GameManager gameManager = null;
    
    public void OnMuffinClicked()
    {
        //GameManager.instance.OnMuffinButtonClicked();
        gameManager.OnMuffinButtonClicked();

        // Animate Button

        // Add sound to button
    }
}
