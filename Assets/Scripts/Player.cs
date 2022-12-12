using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] // CharacterController�R���|�[�l���g�K�{

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxMoveSpeed = 5.0f;  // �ő�ړ����x

    private CharacterController controller;

    // �t���[���X�V�����̑O�Ɉ�x�����Ă΂��֐�
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // ���t���[���X�V����
    void Update()
    {
        // �����������͏��擾
        float horizontal = Input.GetAxisRaw("Horizontal");

        // �ړ�����
        Vector3 move;
        move.x = horizontal * maxMoveSpeed;
        move.y = 0.0f;
        move.z = 0.0f;
        controller.Move(move * Time.deltaTime);
    }
}
