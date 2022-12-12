using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] // CharacterController�R���|�[�l���g�K�{

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxMoveSpeed = 5.0f;  // �ő�ړ����x

    private CharacterController controller;

    private float horizontalSpeed;  // �����ړ����x
    private float verticalSpeed;    // ���������ړ�

    // �t���[���X�V�����̑O�Ɉ�x�����Ă΂��֐�
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // ���t���[���X�V����
    void Update()
    {
        // �i�s�����X�V����
        UpdateDirection();

        // �ړ��X�V����
        UpdateMovement();
    }

    // �i�s�����X�V����
    private void UpdateDirection()
    {
        // �����������͏��擾
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // ���������͏�񂪈��ȏ�Ȃ�ړ���
        float power = Mathf.Abs(horizontal);
        if(power>0.1f)
        {
            // ���������͏�񂩂�i�s������ݒ�
            Vector3 direction = new Vector3(horizontal, 0, 0);

            // �i�s�����Ɍ����悤�ɉ�]�ݒ�
            transform.rotation = Quaternion.LookRotation(direction);
        }
        power = Mathf.Abs(vertical);
        if(power>0.1f)
        {
            // ���������͏�񂩂�i�s������ݒ�
            Vector3 direction = new Vector3(vertical, 0, 0);

            // �i�s�����Ɍ����悤�ɉ�]�ݒ�
            transform.rotation = Quaternion.LookRotation(direction);
        }

        // �ړ����x
        horizontalSpeed = horizontal * maxMoveSpeed;
        verticalSpeed = vertical * maxMoveSpeed;
    }

    // �ړ��X�V����
    private void UpdateMovement()
    {
        // �ړ��ʂ��v�Z
        Vector3 move = new Vector3(horizontalSpeed, 0, verticalSpeed);

        // �ړ�����
        controller.Move(move * Time.deltaTime);
    }
}
