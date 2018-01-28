using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveGun : BaseWeapon
{

    [SerializeField]
    private GameObject original;

    [SerializeField]
    private float shotGage=0.0f;

    [SerializeField]
    private float maxShotGage=2.0f;
    
    [SerializeField]
    private float bulletSpeed = 1F;

    //コントローラーのPos
    [SerializeField]
    private Vector3 position;
    //コントローラーの前方
    [SerializeField]
    private Vector3 foward;

    //Triggerを押しているのかを判定
    private bool triggerPush = false;

    private GameObject bullet;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        if(triggerPush==false&&shotGage>0.0f)
            shotGage -= Time.deltaTime;

        if (shotGage < 0.0f)
            shotGage = 0.0f;

        if(triggerPush==true)
            shotGage += Time.deltaTime;
    }

    //タメ撃ち
    public override void Trigger_Down()
    {
        triggerPush = true;
    }

    public override void Trigger_Up()
    {
        if (shotGage > maxShotGage)
        {
            position = transform.position;
            foward = transform.forward;
            bullet = Instantiate(original, position, original.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce((foward * bulletSpeed * 100F));
            shotGage = 0.0f;
        }

        triggerPush = false;

    }
}
