using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {

    [SerializeField]
    private FadeScreen fadescreen;

    [SerializeField]
    private TrainMovement train;

    [SerializeField]
    private float limitedTime = 1F;

    private bool once = true;
    private float time = 0F;

    /// <summary>
    /// 開始時に実行
    /// </summary>
    private void Start() {
        time = Time.time;
    }

    /// <summary>
    /// 更新時に実行
    /// </summary>
    void Update () {
        // 経過時間を算出
        var currentTime = Time.time - time;

        // 一定時間経過で次の処理へ
        if (currentTime <= limitedTime) return;

        if (once)
        {
            // 一度のみシーン遷移を行う
            once = false;
            train.ToDepart = true;
            //StartCoroutine(FadeInScene());
        }
	}

    /// <summary>
    /// フェードイン＋シーン遷移
    /// </summary>
    /// <returns>
    /// コルーチン
    /// </returns>
    private IEnumerator FadeInScene() {
        fadescreen.FadeIn();
        yield return new WaitForSeconds(2F);
        GetComponent<JumpToScene>().Exicute();
    }
}
