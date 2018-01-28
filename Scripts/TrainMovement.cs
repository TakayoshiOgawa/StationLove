using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour {

    [SerializeField]
    private Transform stopLocation;
    [SerializeField]
    private InstancePool persons;

    [SerializeField]
    private float speed = 1F;
    
    private bool depart = false;

    public bool ToDepart
    {
        set
        {
            startTime = Time.time;
            depart = value;
        }
    }

    private float startTime = 0F;
    private Vector3 startPosition;
    private Vector3 endPosition;

    /// <summary>
    /// 開始時に実行
    /// </summary>
    private void Start() {
        //stopLocation = GameObject.Find("StopLocaltion").transform;
        //persons = GameObject.Find("Persons").GetComponent<InstancePool>();

        startTime = Time.time;
        startPosition = transform.position;
        endPosition = stopLocation.position + (stopLocation.position - startPosition);
    }

    /// <summary>
    /// 更新時に実行
    /// </summary>
    private void Update () {
        // 経過時間の算出
        var currentTime = (Time.time - startTime) * speed;

        if (!depart)
        {
            // 電車が到着
            transform.position = Vector3.Lerp(startPosition, stopLocation.position, currentTime);
        }
        else
        {
            // 電車が出発
            transform.position = Vector3.Lerp(stopLocation.position, endPosition, currentTime);
        }
	}

    public void SpawnPerson() {
        StartCoroutine(SpawnPerson(1F));
    }

    private IEnumerator SpawnPerson(float waitTime = 1F) {
        for (int i = 0; i < 10; i++)
        {
            var person = persons.get;
            person.SetActive(true);
            person.transform.position = transform.position;
            person.transform.rotation = transform.rotation;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
