using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Fade))]
public class FadeScreen : MonoBehaviour {

    private Fade fade;
    private Image img;


    private void Awake() {
        fade = GetComponent<Fade>();
        img = GetComponent<Image>();
        img.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Use this for initialization
    void Start () {
        FadeOut();
	}

    public void FadeOut() {
        fade.Out(img, 1F, () => { });
    }

    public void FadeIn() {
        fade.In(img, 1F, () => { });
    }

    /// <summary>
    /// フェードオン（呼び出し用）
    /// </summary>
    public void FadeOn() {
        fade.On(img, 1F, 1F, () => { });
    }
}
