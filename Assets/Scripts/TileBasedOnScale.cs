using UnityEngine;

public class SetTilingBasedOnScale : MonoBehaviour
{
    public Material material;

    void Start()
    {
        if(material == null)
        {
            Debug.LogError("Material not assigned to SetTilingBasedOnScale script!");
            return;
        }

        
    }
    void Update()
    {
        Vector3 scale = transform.localScale;
        float ratio = Mathf.Max(scale.x, Mathf.Max(scale.y, scale.z)) / 5f;
        material.mainTextureScale = new Vector2(ratio, ratio);
    }
}