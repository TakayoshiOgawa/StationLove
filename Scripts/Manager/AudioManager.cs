// ==================================================
// オーディオの管理クラス
// ==================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AudioIndex = System.Collections.Generic.Dictionary<string, int>;

public class AudioManager : SingletonMonoBehaviour<AudioManager> {

    [SerializeField]
    private AudioClip[] bgmList;
    [SerializeField]
    private AudioClip[] seList;

    public float bgmVolume
    {
        set
        {
            bgm.volume = Mathf.Clamp01(value);
        }
    }

    public float seVolume
    {
        set
        {
            se.volume = Mathf.Clamp01(value);
        }
    }

    private AudioIndex bgmIndex;
    private AudioIndex seIndex;

    private AudioSource bgm;
    private AudioSource se;

    /// <summary>
    /// 生成時に実行
    /// </summary>
    protected override void Awake() {
        // シングルトン
        base.Awake();

        // BGMの音源、リスト、番号表を生成
        bgm = gameObject.AddComponent<AudioSource>();
        bgm.loop = true;
        bgmIndex = new AudioIndex();
        for(int i = 0; i < bgmList.Length; i++)
        {
            bgmIndex.Add(bgmList[i].name, i);
        }

        // SEの音源、リスト、番号表を生成
        se = gameObject.AddComponent<AudioSource>();
        se.loop = false;
        seIndex = new AudioIndex();
        for(int i = 0; i < seList.Length; i++)
        {
            seIndex.Add(seList[i].name, i);
        }
    }

    /// <summary>
    /// 背景音の再生
    /// </summary>
    /// <param name="audioName">
    /// オーディオ名
    /// </param>
    public void PlayBGM(string audioName) {
        PlayBGM(bgmIndex[audioName]);
    }

    /// <summary>
    /// 背景音の再生
    /// </summary>
    /// <param name="index">
    /// オーディオリスト番号
    /// </param>
    public void PlayBGM(int index) {
        bgm.clip = bgmList[index];
        bgm.Play();
    }

    /// <summary>
    /// 背景音の停止
    /// </summary>
    public void StopBGM() {
        bgm.Stop();
    }

    /// <summary>
    /// 効果音の再生
    /// </summary>
    /// <param name="audioName">
    /// オーディオ名
    /// </param>
    public void PlaySE(string audioName) {
        PlaySE(seIndex[audioName]);
    }

    /// <summary>
    /// 効果音の再生
    /// </summary>
    /// <param name="index">
    /// オーディオリスト番号
    /// </param>
    public void PlaySE(int index) {
        se.PlayOneShot(seList[index]);
    }
}
