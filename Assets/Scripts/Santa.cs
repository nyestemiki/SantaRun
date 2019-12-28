using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : Singleton<Santa> {
    private Vector3 giftSpawnPosition;
    private float objectSpeed = 0.5f;
    private bool direction = true;
    private float altitudeDifference = 20f;

    void Awake() {
        giftSpawnPosition = GameManager.Instance.GetGiftSpawnPosition();
    }

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

        if (Input.GetMouseButtonDown(0)) {
            GameObject[] gifts = GameManager.Instance.GetGifts();
            int randomGiftId = Random.Range(0, gifts.Length);
            GameObject gift = gifts[randomGiftId]; 
            Vector3 position = giftSpawnPosition;
            
            Instantiate(gift, position, Quaternion.identity);
        }
    }
}
