using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] // CharacterControllerコンポーネント必須

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxMoveSpeed = 5.0f;  // 最大移動速度

    private CharacterController controller;

    // フレーム更新処理の前に一度だけ呼ばれる関数
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // 毎フレーム更新処理
    void Update()
    {
        // 水平方向入力情報取得
        float horizontal = Input.GetAxisRaw("Horizontal");

        // 移動処理
        Vector3 move;
        move.x = horizontal * maxMoveSpeed;
        move.y = 0.0f;
        move.z = 0.0f;
        controller.Move(move * Time.deltaTime);
    }
}
