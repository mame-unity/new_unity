using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] // CharacterControllerコンポーネント必須

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxMoveSpeed = 5.0f;  // 最大移動速度

    private CharacterController controller;

    private float horizontalSpeed;  // 水平移動速度
    private float verticalSpeed;    // 垂直方向移動

    // フレーム更新処理の前に一度だけ呼ばれる関数
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // 毎フレーム更新処理
    void Update()
    {
        // 進行方向更新処理
        UpdateDirection();

        // 移動更新処理
        UpdateMovement();
    }

    // 進行方向更新処理
    private void UpdateDirection()
    {
        // 水平方向入力情報取得
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 水平軸入力情報が一定以上なら移動中
        float power = Mathf.Abs(horizontal);
        if(power>0.1f)
        {
            // 水平軸入力情報から進行方向を設定
            Vector3 direction = new Vector3(horizontal, 0, 0);

            // 進行方向に向くように回転設定
            transform.rotation = Quaternion.LookRotation(direction);
        }
        power = Mathf.Abs(vertical);
        if(power>0.1f)
        {
            // 水平軸入力情報から進行方向を設定
            Vector3 direction = new Vector3(vertical, 0, 0);

            // 進行方向に向くように回転設定
            transform.rotation = Quaternion.LookRotation(direction);
        }

        // 移動速度
        horizontalSpeed = horizontal * maxMoveSpeed;
        verticalSpeed = vertical * maxMoveSpeed;
    }

    // 移動更新処理
    private void UpdateMovement()
    {
        // 移動量を計算
        Vector3 move = new Vector3(horizontalSpeed, 0, verticalSpeed);

        // 移動処理
        controller.Move(move * Time.deltaTime);
    }
}
