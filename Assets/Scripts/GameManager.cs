using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    // Score
    private int totalClicks = 0;
    [SerializeField] private int pointPerClick = 1;

    // Floating Text
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private RectTransform floatingTextParent;

    [SerializeField] private HeaderUI headerUI = null;

    // Start is called before the first frame update
    void Start()
    {
        headerUI.UpdateUI(totalClicks);
    }

    public void OnMuffinButtonClicked()
    {
        // Increasing the score
        totalClicks = totalClicks + pointPerClick;

        // Update UI
        headerUI.UpdateUI(totalClicks);

        // Create the floating text notification
        CreateFloatingText("+" + pointPerClick);
    }

    private void CreateFloatingText(string message)
    {
        // Spawn a new floating text
        GameObject newFloatingText = Instantiate(floatingTextPrefab, floatingTextParent);

        // Generate a random position around the muffin
        Vector3 randomPosition = GetRandomPosAroundMuffin();

        // Position the new floating text at the random position
        newFloatingText.transform.localPosition = randomPosition;

        // Set the floating text's actual text
        newFloatingText.GetComponent<TMP_Text>().text = message;

    }

    private Vector3 GetRandomPosAroundMuffin()
    {
        float x = Random.Range(-200f, 200f);
        float y = Random.Range(75f, 225f);

        return new Vector3(x, y);
    }
}
