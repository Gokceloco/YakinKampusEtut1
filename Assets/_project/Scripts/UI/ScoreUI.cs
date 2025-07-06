using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreTMP;
    public void UpdateScoreUI(int totalScore)
    {
        scoreTMP.text = totalScore.ToString();
    }
}
