using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Over : MonoBehaviour {

    [SerializeField] private Text message;

    void Start() {
        int hits = GameManager.Instance.getHits();

        if (hits < 0) {
            message.text = "You failed way too many gifts... :(";
        } else {
            message.text = hits.ToString() + " gifts delivered :)";
        }
    }

    public void newGame() {
        GameManager.Instance.restart();        
    }

}
