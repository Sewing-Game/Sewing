using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTranspart : MonoBehaviour
{
    [Range(0f, 1f)]
    public float Opacity = 0.5f;
    public int FloorLayer = 10;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == FloorLayer)
        {
            var mesh = other.gameObject.GetComponent<MeshRenderer>();
            if(mesh != null)
            {
                var color = mesh.material.color;
                color.a = Opacity;
                mesh.material.color = color;                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == FloorLayer)
        {
            var mesh = other.gameObject.GetComponent<MeshRenderer>();
            if (mesh != null)
            {
                var color = mesh.material.color;
                color.a = 1;
                mesh.material.color = color;
            }
        }
    }
}
