using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGarge : MonoBehaviour {

    private CircleSlider circle;
    private Text healthCount;

    /// <summary>
    /// 生成時に実行
    /// </summary>
    private void Awake() {
        circle = GetComponentInChildren<CircleSlider>();
        healthCount = GetComponentInChildren<Text>();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update() {
        //AddVirus(0.01F);
        if(circle.amount >= circle.max)
        {
            circle.amount = circle.min;
            TakeDamage();
        }
    }

    /// <summary>
    /// ウイルス追加
    /// </summary>
    /// <param name="value">
    /// 上昇値
    /// </param>
    public void AddVirus(float value) {
        circle.amount += value;
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <returns>
    /// 死亡判定
    /// </returns>
    public bool TakeDamage() {
        var health = int.Parse(healthCount.text) - 1;
        healthCount.text = health.ToString();
        return health <= 0F;
    }
}
