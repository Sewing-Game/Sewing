using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.0f;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _animator = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        _animator.SetFloat("speed", Vector3.Magnitude(_rigidbody.velocity));
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if (vertical != 0 || horizontal != 0)
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

            // @TODO: �밢������ �̵��Ҷ� ����ġ ���� ���ӵ��� �ٴ� ���װ� Ȯ�� �Ǿ����ϴ�.
            //        �ش� �ڵ带 �밢������ �̵��Ҷ� ���� ũ�Ⱑ 1�� �ǵ��� ���� ������ �ʿ䰡 �־�Դϴ�.
            Vector3 move = new(horizontal, 0, vertical);
            _rigidbody.velocity = playerSpeed * move;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
        }

    }
}
