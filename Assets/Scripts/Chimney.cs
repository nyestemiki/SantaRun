using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimney : MonoBehaviour
{
    private BoxCollider2D chimney;

    void Awake() {
        chimney = GetComponent<BoxCollider2D>();
    }

    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.Instance.GiftHitChimney();  
        Destroy(other.gameObject);
    }
}
