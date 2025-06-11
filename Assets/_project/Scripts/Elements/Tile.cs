using System;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public MeshRenderer mr;
    public List<Material> materials;
    public void StartTile(bool isWhite)
    {
        if (isWhite)
        {
            mr.material = materials[0];
        }
        else
        {
            mr.material = materials[1];
        }
    }
}
