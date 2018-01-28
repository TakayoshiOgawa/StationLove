using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawn : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float interval = 1F;

    [SerializeField]
    private InstancePool pool;

    private float currentTime;

    private void Start() {
        currentTime = 0F;
    }

    private void Update() {
        currentTime += Time.deltaTime;

        if(currentTime > interval)
        {
            currentTime = 0F;

            var virus = pool.get;
            if (!virus) return;

            var scale = transform.localScale / 2F;
            var x = Random.Range(transform.position.x - scale.x, transform.position.x + scale.x);
            var y = Random.Range(transform.position.y - scale.y, transform.position.y + scale.y);
            var z = Random.Range(transform.position.z - scale.z, transform.position.z + scale.z);
            virus.transform.position = new Vector3(x, y, z);
            virus.GetComponent<Virus>().Target = target;
            virus.SetActive(true);
        }
    }
}
