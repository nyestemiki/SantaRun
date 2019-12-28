using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Over : MonoBehaviour {

    [SerializeField] private Text message;

    void Start() {
        int hits = GameManager.Instance.getHits();

        message.text = hits.ToString();
    }

    public void newGame() {
        GameManager.Instance.restart();        
    }

}
