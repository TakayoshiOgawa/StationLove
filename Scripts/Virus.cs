using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed = 1F;

    [SerializeField]
    private float gravityScale = 10.0f;

    private Rigidbody r;
    

    public Transform Target
    {
        set { target = value; }
    }

    public float Speed
    {
        set { speed = value; }
    }

    private void Awake() {
        tag = "Virus";
        GetComponent<Collider>().isTrigger = true;

        r = GetComponent<Rigidbody>();

        
    }

    private void Update() {
        //var velocity = target.transform.position - transform.position;
        //transform.Translate(velocity.normalized * speed);
        
    }

    public void addForce(Vector3 position) {
        //r.AddForce((position - transform.position)* gravityScale);
        r.AddForce(position - transform.position) ;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "MainCamera")
        {
            gameObject.SetActive(false);
        }
        
    }
}
