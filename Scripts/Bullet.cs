using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void Awake() {
        tag = "Bullet";
    }

    private void OnCollisionEnter(Collision collision) {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Person")
        {
            if (other.name == "Targe")
            {
                Debug.Log("Game Clear!");
                return;
            }
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
