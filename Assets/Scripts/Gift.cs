using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour {

    private float speed = 1.25f;

    void Update() {

        // Continuous moving oving to the left
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
    }

}
