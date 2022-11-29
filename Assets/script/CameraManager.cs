using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Just Loot at the Canvas (consists with Shop and Inventory)
public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Canvas target;

    void Start()
    {
        
    }
    void Update()
    {
        this.transform.LookAt(target.transform);
    }
}
