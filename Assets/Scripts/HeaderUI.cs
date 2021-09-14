using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeaderUI : MonoBehaviour
{
    // UI
    [SerializeField] private TMP_Text muffinsText = null;
    [SerializeField] private TMP_Text muffinsPerSecondText = null;

    public void UpdateUI(int totalClicks, int muffinsPerSecond)
    {
        if (totalClicks == 1)
        {
            muffinsText.text = totalClicks.ToString() + " muffin";
        }
        else
        {
            muffinsText.text = totalClicks.ToString() + " muffins";
        }

        if (muffinsPerSecond == 1)
        {
            muffinsPerSecondText.text = muffinsPerSecond.ToString() + " muffin per second";
        }
        else
        {
            muffinsPerSecondText.text = muffinsPerSecond.ToString() + " muffins per second";
        }
    }
}

