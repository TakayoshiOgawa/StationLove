// ==================================================
// 生成物をまとめたスクリプト
// ==================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePool : MonoBehaviour {

    [SerializeField]
    private uint poolSize = 1;

    [SerializeField]
    private GameObject original;

    private GameObject[] pool;

    public GameObject get
    {
        get
        {
            // 非アクティブのオブジェクトを使用
            foreach(var obj in pool)
            {
                if(!obj.activeSelf)
                {
                    return obj;
                }
            }
            return null;
        }
    }

    public uint length
    {
        get { return poolSize; }
    }

    /// <summary>
    /// 生成時に実行
    /// </summary>
    private void Awake() {
        Resize(poolSize);
    }

    /// <summary>
    /// 長さの変更
    /// </summary>
    /// <param name="size">
    /// 配列の長さ
    /// </param>
    public void Resize(uint size) {
        // 配列を再生成
        pool = new GameObject[size];
        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(original, transform);
            pool[i].SetActive(false);
        }

        // 長さを変更
        poolSize = (uint)pool.Length;
    }
}
