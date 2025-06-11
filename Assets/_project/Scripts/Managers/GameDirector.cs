using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static GameDirector instance;

    public Player player;
    
    public LevelManager levelManager;
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
        levelManager.RestartLevelManager();
        player.RestartPlayer();
    }
}
