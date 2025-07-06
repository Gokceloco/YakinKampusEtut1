using TMPro;
using UnityEngine;

public class RemainingAttemptsUI : MonoBehaviour
{
    public TextMeshProUGUI reaminingAttemptsTMP;

    public void UpdateRemainingAttemptsTMP(int lives)
    {
        reaminingAttemptsTMP.text = lives.ToString();
    }
}
