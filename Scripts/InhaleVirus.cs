using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhaleVirus : BaseWeapon
{

    [SerializeField]
    private LayerMask mask;

    //raycastの長さ
    [SerializeField]
    private float length=10.0f;

    [SerializeField]
    private float destroyDistance = 0.001f;

    public bool hitVirus = false;

    private Virus virus;

    private void Update()
    {
        if(hitVirus)
        {
            if (virus) virus.addForce(transform.position);
        }

    }

    public override void Trigger_Down()
    {
        //Ray生成
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //Hit判定
        if (Physics.Raycast(ray, out hit, length, mask))
        {
            hitVirus = true;

            virus = hit.transform.gameObject.GetComponent<Virus>();



            if ((hit.transform.position-transform.position).magnitude< destroyDistance)
            {
                Debug.Log((hit.transform.position - transform.position).magnitude);
                hit.transform.gameObject.SetActive(false);
                virus = null;
                hitVirus = false;

            }
        }
    }

    public override void Trigger_Up()
    {

        virus = null;
        hitVirus = false;
    }
}
