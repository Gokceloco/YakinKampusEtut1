using System.Collections.Generic;
using UnityEngine;

public class TopUI : MonoBehaviour
{
    public List<CollectableIcon> collectableIcons;
    public CollectableIcon collectableIconPrefab;

    public float startX = 400;

    public void ClearTopUI()
    {
        foreach (var c in collectableIcons)
        {
            Destroy(c.gameObject);
        }
        collectableIcons.Clear();
    }
    public void ShowCollectables(List<Collectable> shuffledList)
    {
        var step = (startX * 2) / (shuffledList.Count - 1);
        var createdIconCount = 0;
        foreach (var c in shuffledList)
        {
            var newIcon = Instantiate(collectableIconPrefab, transform);
            newIcon.StartIcon(c);
            newIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(-startX + step * createdIconCount, 0);
            collectableIcons.Add(newIcon);
            createdIconCount++;
        }
    }

    public void ObjectCollected(int i)
    {
        collectableIcons[i].ShowCheckImage();
    }
}
