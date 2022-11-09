using UnityEngine;

public class WindmillRotation : MonoBehaviour
{
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * 360));
    }
}
