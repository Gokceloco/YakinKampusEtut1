using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Collectable : MonoBehaviour
{
    public MeshRenderer mr;
    public CollectableShape collectableShape;
    public void StartCollectable(Material mat, CollectableShape shape)
    {
        SetMaterial(mat);
        collectableShape = shape;
    }

    private void SetMaterial(Material mat)
    {
        mr.material = mat;   
    }
}
