// ==================================================
// 速度込みの簡易移動系処理
// ==================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 1F;
    [SerializeField]
    private float rotaSpeed = 1F;

    /// <summary>
    /// 移動処理
    /// </summary>
    /// <param name="velocity">
    /// 進行方向
    /// </param>
    public void Move(Vector3 velocity) {
        transform.Translate(velocity * moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 回転処理
    /// </summary>
    /// <param name="direction">
    /// 回転方向
    /// </param>
    public void Rotate(Vector3 direction) {
        transform.Rotate(direction * rotaSpeed * Time.deltaTime);
    }
}
