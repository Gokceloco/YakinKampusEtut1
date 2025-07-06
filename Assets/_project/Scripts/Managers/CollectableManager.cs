using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public List<Collectable> collectablePrefabs;
    public List<Material> materials;
    
    public int minCollectableCount;
    public int maxCollectableCount;

    public List<Collectable> collectablesInScene;
    public List<Collectable> shuffledCollectables;
    
    public void StartCollectableManager()
    {
        collectablesInScene.Clear();
        shuffledCollectables.Clear();
        SpawnCollectables();
        RearrangeCollectablesList();
        ShowPlayerTheQueue();
    }
    private void SpawnCollectables()
    {
        var collectableCount = Random.Range(minCollectableCount, maxCollectableCount);
        var step = 15f / collectableCount;
        var tempMaterialList = new List<Material>(materials);
        for (int i = 0; i < collectableCount; i++)
        {
            var randomCollectableIndex = Random.Range(0, collectablePrefabs.Count);
            var randomMaterialIndex = Random.Range(0, tempMaterialList.Count);
            var selectedMaterial = tempMaterialList[randomMaterialIndex];
            tempMaterialList.RemoveAt(randomMaterialIndex);
            
            var collectableShape = CollectableShape.Box;
            if (randomCollectableIndex == 1)
            {
                collectableShape = CollectableShape.Sphere;
            }
            var newCollectable = Instantiate(collectablePrefabs[randomCollectableIndex]);
            gameDirector.levelManager.SetParentToLevel(newCollectable.transform);
            newCollectable.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 0, 3 + (i * step));
            newCollectable.StartCollectable(selectedMaterial, collectableShape);
            
            collectablesInScene.Add(newCollectable);
        }
    }
    private void RearrangeCollectablesList()
    {
        shuffledCollectables = collectablesInScene.OrderBy(i => Guid.NewGuid()).ToList();
    }
    private void ShowPlayerTheQueue()
    {
        gameDirector.topUI.ShowCollectables(shuffledCollectables);
    }
}
public enum CollectableShape
{
    Box,
    Sphere,
}