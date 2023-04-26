using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build.Reporting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float maxScale = 20;
    public float growthFactor = 1.000001f;
    Material material;

    void Start()
    {
        // changes the color of the material that compounds the mesh renderer component of the GameObject
        material = Renderer.material;
        material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);

        GetComponent<TrailRenderer>().material.SetColor("_Color", material.color);
        GetComponent<TrailRenderer>().widthMultiplier = 10.0f;

        InvokeRepeating("ScaleCube", 1.0f, 0.06f);
    }
    
    void Update()
    {
        transform.Rotate(Vector3.back, Space.Self);
        
    }
    
    void ScaleCube ()
    {
        
        if (transform.localScale.x > maxScale)
        {
            growthFactor = -1.000001f;
        }
        else if (transform.localScale.x < 1)
        {
            growthFactor = 1.000001f;
            material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.1f, 1.0f));
            GetComponent<TrailRenderer>().material.SetColor("_Color", material.color);
        }

        transform.localScale += (Vector3.one * growthFactor);
    }
}
