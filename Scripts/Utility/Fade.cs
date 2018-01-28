// ==================================================
// イメージに対する透過処理のスクリプト
// ==================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    /// <summary>
    /// フェードイン
    /// </summary>
    /// <param name="img">
    /// 透過画像
    /// </param>
    /// <param name="fadeTime">
    /// 経過終了時間
    /// </param>
    /// <param name="method">
    /// ラムダ式
    /// </param>
    public void In(Image img, float fadeTime = 1F, System.Action method = null) {
        StartCoroutine(FadeUpdate(img, 0F, 1F, fadeTime, method));
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    /// <param name="img">
    /// 透過画像
    /// </param>
    /// <param name="fadeTime">
    /// 経過終了時間
    /// </param>
    /// <param name="method">
    /// ラムダ式
    /// </param>
    public void Out(Image img, float fadeTime = 1F, System.Action method = null) {
        StartCoroutine(FadeUpdate(img, 1F, 0F, fadeTime, method));
    }

    /// <summary>
    /// フェードアウト→フェードイン
    /// </summary>
    /// <param name="img">
    /// 透過画像
    /// </param>
    /// <param name="outTime">
    /// フェードアウトの時間
    /// </param>
    /// <param name="inTime">
    /// フェードインの時間
    /// </param>
    /// <param name="method">
    /// ラムダ式
    /// </param>
    public void On(Image img, float outTime, float inTime, System.Action method = null) {
        StartCoroutine(FadeOn(img, outTime, inTime, method));
    }


    /// <summary>
    /// フェードアウト→フェードイン
    /// </summary>
    /// <param name="img">
    /// 透過画像
    /// </param>
    /// <param name="outTime">
    /// フェードアウトの時間
    /// </param>
    /// <param name="inTime">
    /// フェードインの時間
    /// </param>
    /// <param name="method">
    /// ラムダ式
    /// </param>
    /// <returns>
    /// コルーチン
    /// </returns>
    private IEnumerator FadeOn(Image img, float outTime, float inTime, System.Action method = null) {
        In(img, inTime, () => { });
        yield return new WaitForSeconds(inTime);

        method();

        yield return new WaitForSeconds(outTime);
        Out(img, outTime, () => { });
    }

    /// <summary>
    /// 透過更新
    /// </summary>
    /// <param name="img">
    /// 透過画像
    /// </param>
    /// <param name="start">
    /// 開始する値[0 ~ 1]
    /// </param>
    /// <param name="end">
    /// 終了する値[1 ~ 0]
    /// </param>
    /// <param name="interval">
    /// 経過終了時間
    /// </param>
    /// <param name="method">
    /// ラムダ式
    /// </param>
    /// <returns>
    /// コルーチン
    /// </returns>
    private IEnumerator FadeUpdate(Image img, float start, float end, float interval, System.Action method = null) {
        // 0から1までクランプ
        start = Mathf.Clamp01(start);
        end = Mathf.Clamp01(end);

        // 経過終了まで透過度を補間する
        float time = 0F;
        while (time <= interval)
        {
            SetAlpha(img, Mathf.Lerp(start, end, time / interval));
            time += Time.deltaTime;
            yield return 0;
        }

        // フェード終了後の処理
        method();
    }

    /// <summary>
    /// 透過度の設定
    /// </summary>
    /// <param name="img">
    /// 透過画像
    /// </param>
    /// <param name="alpha">
    /// 透過度
    /// </param>
    private void SetAlpha(Image img, float alpha) {
        img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
    }
}
