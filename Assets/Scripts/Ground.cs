﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.Instance.GiftHitGround();  
        Destroy(other.gameObject);
    }

}