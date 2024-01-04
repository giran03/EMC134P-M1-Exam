using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsManagerScript : MonoBehaviour
{
    public TMP_Text Score;
    public TMP_Text Lives;
    public static int scoreCount = 0;
    public static int livesCount = 3;

    void Update()
    {
        Score.SetText("Score: " + scoreCount);
        Lives.SetText("Lives: " + livesCount);
    }
}
