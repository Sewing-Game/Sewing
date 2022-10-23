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

            // @TODO: 대각선으로 이동할때 예상치 못한 가속도가 붙는 버그가 확인 되었습니다.
            //        해당 코드를 대각선으로 이동할때 백터 크기가 1이 되도록 값을 설정할 필요가 있어보입니다.
            Vector3 move = new(horizontal, 0, vertical);
            _rigidbody.velocity = playerSpeed * move;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
        }

    }
}
