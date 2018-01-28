using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {
    
    [SerializeField]
    private InstancePool pool;

    [SerializeField]
    private float interval = 1F;

    private float currentTime = 0F;

    /// <summary>
    /// 更新時に実行
    /// </summary>
    private void Update() {
        Spawn();
    }

    public void Spawn() {
        currentTime += Time.deltaTime;

        if (currentTime > interval)
        {
            currentTime = 0F;

            var clone = pool.get;
            if (!clone) return;

            var scale = transform.localScale / 2F;
            var x = Random.Range(transform.position.x - scale.x, transform.position.x + scale.x);
            var y = Random.Range(transform.position.y - scale.y, transform.position.y + scale.y);
            var z = Random.Range(transform.position.z - scale.z, transform.position.z + scale.z);
            clone.transform.position = new Vector3(x, y, z);
            clone.GetComponent<SpawnCharacter>().velocity = transform.forward;
            clone.SetActive(true);
        }
    }
}
