using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{

    private Transform m_currentTarget = null;
    private float m_distance = 2f;
    private float m_height = 1;
    private float m_lookAtAroundAngle = 180;

    [SerializeField] private List<Transform> m_targets = null;
    [SerializeField] private MeshFilter planeMesh = null;
    private Bounds bounds;
    private float boundsX = 0f;
    private float boundsZ = 0f; 
    private int m_currentIndex = 0;

    private void Start()
    {
        if (m_targets.Count > 0)
        {
            m_currentIndex = 0;
            m_currentTarget = m_targets[m_currentIndex];
        }
        Mesh meshy = planeMesh.mesh;
        bounds = meshy.bounds;
        boundsX = (bounds.size.x)/2;
        boundsZ =(bounds.size.z)/2;
        float x = Random.Range(-boundsX,boundsX);
        float z = Random.Range(-boundsZ,boundsZ);
        m_currentTarget.position = new Vector3(x,m_currentTarget.position.y,z);
    }

    private void LateUpdate()
    {
        if (m_currentTarget == null) { return; }
        transform.LookAt(m_currentTarget.position + new Vector3(0, m_height, 0));
    }
}
