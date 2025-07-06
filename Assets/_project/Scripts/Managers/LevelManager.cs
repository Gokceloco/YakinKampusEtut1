using System.Collections.Generic;
using Unity.Mathematics.Geometry;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public int levelNo;

    private Level _curLevel;
    
    public List<Level> levels;

    public void RestartLevelManager()
    {
        levelNo = Mathf.Clamp(levelNo, 1, levels.Count);
        
        DestroyCurrentLevel();
        CreateNewLevel();
    }

    public void SetParentToLevel(Transform t)
    {
        t.SetParent(_curLevel.transform);
    }

    private void CreateNewLevel()
    {
        _curLevel = Instantiate(levels[0]);
        _curLevel.StartLevel();
    }

    private void DestroyCurrentLevel()
    {
        if (_curLevel)
            Destroy(_curLevel.gameObject);
    }
    
    public void LoadNextLevel()
    {
        levelNo++;
        GameDirector.instance.RestartLevel();
    }
    public void LoadPreviousLevel()
    {
        levelNo--;
        GameDirector.instance.RestartLevel();
    }
}
