using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pavement : MonoBehaviour {

    private float speed = 2f;
    private float startScreen;
    private float endScreen;
    private float width;
    private bool reproduced = false;
    private float endOfPicture;

    void Awake() {
        startScreen = GameManager.Instance.GetStartOfScreen();
        endScreen = GameManager.Instance.GetEndOfScreen();
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {

        // Continuous moving oving to the left
        transform.Translate(Vector3.left * (speed * Time.deltaTime));

        endOfPicture = transform.position.x + width/2;

        // new
        if (!reproduced && endOfPicture < endScreen) {
            GameManager.Instance.SpawnNewPavement();
            reproduced = true;
        }

        // delete
        if (endOfPicture < startScreen) {
            Destroy(this.gameObject);
        }

    }

}
