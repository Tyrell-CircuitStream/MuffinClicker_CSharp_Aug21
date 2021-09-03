using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public struct SaveData
{
    public int totalClicks;
    public int pointsPerClick;
}

public class GameManager : MonoBehaviour
{
    // Score
    private int totalClicks = 0;
    [SerializeField] private int pointsPerClick = 1;

    // Floating Text
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private RectTransform floatingTextParent;

    [SerializeField] private HeaderUI headerUI = null;


    private void Awake()
    {
        LoadGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        headerUI.UpdateUI(totalClicks);
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            totalClicks = 0;
            pointsPerClick = 1;
            headerUI.UpdateUI(totalClicks);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void OnMuffinButtonClicked()
    {
        // Increasing the score
        totalClicks = totalClicks + pointsPerClick;

        // Update UI
        headerUI.UpdateUI(totalClicks);

        // Create the floating text notification
        CreateFloatingText("+" + pointsPerClick);
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

    private void SaveGame()
    {
        Debug.Log("Saving Game...");

        // Create the save data object
        SaveData saveData = new SaveData();

        // Populate the save data object with the game's current state
        saveData.totalClicks = totalClicks;
        saveData.pointsPerClick = pointsPerClick;

        // Convert the save data object into JSON (Serialize it!)
        string saveJSON = JsonUtility.ToJson(saveData);
        Debug.Log("Save JSON: " + saveJSON);

        // Save the JSON to PlayerPrefs
        PlayerPrefs.SetString("savegame", saveJSON);
    }

    private void LoadGame()
    {
        Debug.Log("Loading Game...");

        // Load the JSON to PlayerPrefs
        string saveJSON = PlayerPrefs.GetString("savegame", "{}");

        // Convert the JSON into a save data object (Deserialize it!)
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveJSON);

        // Populate the game's current state with the save data object 
        totalClicks = saveData.totalClicks;

        if (saveData.pointsPerClick == 0)
        {
            pointsPerClick = 1;
        }
        else
        {
            pointsPerClick = saveData.pointsPerClick;
        }

    }


}
