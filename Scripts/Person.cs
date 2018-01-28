using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : SpawnCharacter {

    private void Update() {
        transform.Translate(velocity * Time.deltaTime);
    }
}
