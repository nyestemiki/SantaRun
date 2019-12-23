using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {
    private float objectSpeed = 2f;
    private bool reproduced = false;
    private float startOfScreen;
    private float endOfScreen;
    float width;
    float areaWithPadding;

    void Awake() {
        // Start of the visible screen
        startOfScreen = GameManager.Instance.GetStartOfScreen();
        // End of the visible screen
        endOfScreen = GameManager.Instance.GetEndOfScreen();
        // Width of the House
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        // Continuous moving oving to the left
        transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

        // Position of the ending of the House with a padding of .5*House
        areaWithPadding = transform.position.x + width;

        // House ready to reproduce (once)
        if (!reproduced && areaWithPadding < endOfScreen) {
            GameManager.Instance.SpawnNewHouse();
            reproduced = true;
        }

        // House out of screen
        if (areaWithPadding < startOfScreen) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.Instance.GiftHitChimney();  
        Destroy(other.gameObject);
    }
}
