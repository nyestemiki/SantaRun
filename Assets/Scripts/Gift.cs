using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour {

    private float speed = 1.5f;
    private bool fallen = false;
    private Rigidbody2D rigidbody;

    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {

        // Gift is on the ground
        if (fallen) {
            if (transform.position.x < GameManager.Instance.GetStartOfScreen()) {
                Destroy(transform.gameObject);
            }

            transform.Translate(Vector3.left * (2 * Time.deltaTime));
            return;
        }

        // Continuous moving oving to the left
        transform.Translate(Vector3.left * (speed * Time.deltaTime));

        // Downscaling
        float x = 0.05f * Time.deltaTime;
        float y = 0.05f * Time.deltaTime;
        float z = 0.05f * Time.deltaTime;
        transform.localScale -= new Vector3(x, y, z);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground") {
            fallen = true;
            rigidbody.simulated = false;
        }
    }

}
