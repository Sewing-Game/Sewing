#nullable enable

using System;
using Unity.VisualScripting;
using UnityEngine;


public class TrackingCamera : MonoBehaviour
{
    public GameObject? target;

    [InspectorLabel("FrozenTrasnslate")]
    public Frozen frozenTrasnslate = new() { x = false, Y = false, Z = false };

    private Vector3 _prevPosition = Vector3.zero;

    private Vector3 _diff = Vector3.zero;
    private Vector3 Diff => _diff;

    private Vector3 getFilteredPosition(Vector3 p)
    {
        p.Scale(frozenTrasnslate.ToVector3());
        return p;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (target == null) return;        
        _diff = transform.position - getFilteredPosition(target.transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) return;
        if (target.transform.position == _prevPosition) return;
        
        var p = target.transform.position;
        _prevPosition = p;
        transform.position = getFilteredPosition(p) + Diff;
    }

    [Serializable]
    public struct Frozen
    {
        public bool x;
        public bool Y;
        public bool Z;

        public Vector3 ToVector3() => new(Convert.ToInt32(!x), Convert.ToInt32(!Y), Convert.ToInt32(!Z));
    }
}
