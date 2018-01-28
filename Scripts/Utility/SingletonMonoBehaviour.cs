// ==================================================
// Unity用のシングルトンテンプレート
// ==================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<Type> : MonoBehaviour where Type : MonoBehaviour {

    [SerializeField]
    private bool dontDestroy = false;

    private static Type _instance = null;
    public static Type instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<Type>();
            }
            return _instance;
        }
    }

    /// <summary>
    /// 生成時に実行
    /// </summary>
    protected virtual void Awake() {

        // 既にある場合は破棄
        if(this != instance)
        {
            Destroy(this.gameObject);
            return;
        }

        // 破棄されないオブジェクトに登録
        if (dontDestroy)
            DontDestroyOnLoad(this.gameObject);
    }
}
