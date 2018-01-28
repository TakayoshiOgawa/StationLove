using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKey : MonoBehaviour {

    [SerializeField]
    private MonoBehaviour[] debugObjects;

	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Break();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            (debugObjects[0] as HealthGarge).TakeDamage();
        }
	}
}
