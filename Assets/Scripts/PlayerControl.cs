using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.0f;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if(vertical != 0 || horizontal != 0)
        {
            float angle = (horizontal, vertical) switch
            {
                ( > 0, > 0) => 45,
                ( > 0, < 0) => 135,
                ( < 0, > 0) => -45,
                ( < 0, < 0) => -135,
                { horizontal: > 0 } => 90,
                { horizontal: < 0 } => -90,
                { vertical: < 0 } => 180,
                { vertical: > 0 } => 0,
                _ => throw new System.NotImplementedException(),
            };

            Vector3 move = new(horizontal, 0, vertical);
            _rigidbody.velocity = playerSpeed * move;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
        }
      
    }
}
