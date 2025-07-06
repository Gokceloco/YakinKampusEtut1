using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static GameDirector instance;
    
    public CollectableManager collectableManager;

    public TopUI topUI;
    
    public Player player;
    
    public LevelManager levelManager;
    public ScoreManager scoreManager;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        RestartLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            levelManager.LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            levelManager.LoadPreviousLevel();
        }
    }

    public void RestartLevel()
    {
        topUI.ClearTopUI();
        levelManager.RestartLevelManager();
        collectableManager.StartCollectableManager();
        player.RestartPlayer();
        scoreManager.RestartScoreManager(collectableManager.shuffledCollectables.Count);
    }

    public void LevelFailed()
    {
        print("LEVEL FAILED!");
        print("press R to restart level");
    }
    public void LevelCompleted()
    {
        print("LEVEL COMPLETED!");
        print("press R to restart level");
    }
}
