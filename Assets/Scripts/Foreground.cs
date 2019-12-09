using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foreground : Singleton<Foreground> {

    private float objectSpeed = 2f;
    private bool reproduced = false;

    void Start() {
        
    }

    void Update() {
        transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

        float endOfScreen = GameManager.Instance.GetEndOfScreen();

        if (transform.position.x < -2f
                && !reproduced) {
            GameManager.Instance.SpawnNewHouses();
            reproduced = true;
        }
    }
}
