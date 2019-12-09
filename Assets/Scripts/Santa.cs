using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : Singleton<Santa> {
    private Vector3 giftSpawnPosition;

    void Awake() {
        giftSpawnPosition = GameManager.Instance.GetGiftSpawnPosition();
    }

    void Start() {
        
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject[] gifts = GameManager.Instance.GetGifts();
            GameObject gift = gifts[0]; // Randomize
            Vector3 position = giftSpawnPosition;
            
            Instantiate(gift, position, Quaternion.identity);
        }
    }
}
