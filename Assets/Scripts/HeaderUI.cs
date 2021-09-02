using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeaderUI : MonoBehaviour
{
    // UI
    [SerializeField] private TMP_Text muffinText = null;

    public void UpdateUI(int totalClicks)
    {
        if (totalClicks == 1)
        {
            muffinText.text = totalClicks.ToString() + " muffin";
        }
        else
        {
            muffinText.text = totalClicks.ToString() + " muffins";
        }
    }
}
