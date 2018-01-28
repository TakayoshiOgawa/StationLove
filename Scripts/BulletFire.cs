using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : BaseWeapon {

    [SerializeField]
    private GameObject original;

    [SerializeField]
    private Transform bulletDir;

    [SerializeField]
    private float bulletSpeed = 1F;

    [SerializeField]
    private float destroyTime = 1F;

    //コントローラーのPos
    [SerializeField]
    private Vector3 position;

    //コントローラーの前方
    [SerializeField]
    private Vector3 foward;

    private void Update() {

        if (Input.GetMouseButtonDown(0))
        {
            // カメラとマウスの座標
            var camera = Camera.main;
            var mousePosition = Input.mousePosition + Vector3.forward * 10F;
            // スクリーン座標からワールド座標に変換
            var spawnPos = camera.ScreenToWorldPoint(mousePosition);
            
        }
    }

    /// <summary>
    /// 弾の発射
    /// </summary>
    /// <param name="position">
    /// 出現座標
    /// </param>
    /// <param name="foward">
    /// 弾の進行方向
    /// </param>
  
    

    public override void Trigger_Down()
    {
        position = bulletDir.position;
        foward = bulletDir.forward;

        // 弾の生成と前方向へ発射
        var bullet = Instantiate(original, position, original.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce((foward * bulletSpeed * 100F));

        // 時限破棄を設定
        Destroy(bullet, destroyTime);
    }
    public override void Trigger_Up()
    {
        
    }
}
