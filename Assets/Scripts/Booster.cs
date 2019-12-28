using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {
    private float speed = 4.5f;

    void Update() {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Gift") {
            GameManager.Instance.ActivateBooster();
            Destroy(transform.gameObject);
            Destroy(other.gameObject);
        }
    }
}
