using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public RemainingAttemptsUI remainingAttemptsUI;
    public ScoreUI scoreUI;
    private int _totalScore;
    public FXManager1 fxManager;
    public int remainingAttemps;

    public GameDirector gameDirector;

    public void RestartScoreManager(int totalAttempts)
    {
        _totalScore = 0;
        scoreUI.UpdateScoreUI(0);
        remainingAttemps = totalAttempts;
        remainingAttemptsUI.UpdateRemainingAttemptsTMP(remainingAttemps);
    }

    public void UpdateScore(int score, Vector3 pos)
    {
        _totalScore += score;
        PlayScoreFX(score, pos);
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreUI.UpdateScoreUI(_totalScore);
    }

    private void PlayScoreFX(int score, Vector3 pos)
    {
        fxManager.PopScoreOnObject(score, pos);
    }

    public void DragReleased()
    {
        remainingAttemps--;
        remainingAttemptsUI.UpdateRemainingAttemptsTMP(remainingAttemps);
    }
}
