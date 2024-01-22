using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class L2_Finish : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
        Time.timeScale = 0;
    }
}
