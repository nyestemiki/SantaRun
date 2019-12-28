using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {
    private float speed = 4.5f;
    private float verticalSpeed = .5f;
    private bool direction = true;
    private float altitudeDifference = 20f;

    void Update() {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));    

        if (direction) {
            transform.Translate(Vector3.down * (verticalSpeed * Time.deltaTime));
            altitudeDifference--;
        } else {
            transform.Translate(Vector3.up * (verticalSpeed * Time.deltaTime));
            altitudeDifference++;
        }

        if (altitudeDifference < 0) {
            direction = false;
        }
        if (altitudeDifference > 20f) {
            direction = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Gift") {
            GameManager.Instance.ActivateBooster();
            Destroy(transform.gameObject);
            Destroy(other.gameObject);
        }
    }
}
