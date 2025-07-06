using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableIcon : MonoBehaviour
{
    public List<Image> images;
    public Image checkImage;

    public void StartIcon(Collectable c)
    {
        foreach (var i in images)
        {
            i.gameObject.SetActive(false);
        }

        Image selectedImage;
        if (c.collectableShape == CollectableShape.Box)
        {
            images[0].gameObject.SetActive(true);
            selectedImage = images[0];
        }
        else
        {
            images[1].gameObject.SetActive(true);
            selectedImage = images[1];
        }
        
        selectedImage.color = c.mr.material.color;
    }

    public void ShowCheckImage()
    {
        checkImage.gameObject.SetActive(true);
    }
}
