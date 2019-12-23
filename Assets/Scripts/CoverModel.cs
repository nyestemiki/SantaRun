using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverModel : MonoBehaviour {
    private float objectSpeed = 0.5f;
    private bool direction = true;
    private float altitudeDifference = 20f;

    void Update() {
        if (direction) {
            transform.Translate(Vector3.down * (objectSpeed * Time.deltaTime));
            altitudeDifference--;
        } else {
            transform.Translate(Vector3.up * (objectSpeed * Time.deltaTime));
            altitudeDifference++;
        }

        if (altitudeDifference < 0) {
            direction = false;
        }
        if (altitudeDifference > 20f) {
            direction = true;
        }
    }

}
