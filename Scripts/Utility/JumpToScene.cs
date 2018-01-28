// ==================================================
// シーン遷移の簡易スクリプト
// ==================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToScene : MonoBehaviour {

    [SerializeField]
    private string sceneName;

    /// <summary>
    /// 実行処理
    /// </summary>
    public void Exicute() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
