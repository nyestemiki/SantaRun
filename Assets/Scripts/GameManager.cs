using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    [SerializeField] private GameObject[] houses;
    [SerializeField] private GameObject[] gifts; 
    [SerializeField] private GameObject backGround;
    [SerializeField] private float[] giftSpawnPosition;
    [SerializeField] private float[] houseSpawnPosition;
    [SerializeField] private float[] backgroundSpawnPosition;
    [SerializeField] Text giftHitDisplay;
    [SerializeField] Text timerDisplay;
    [SerializeField] float startOfScreen;
    [SerializeField] float endOfScreen;
    [SerializeField] private AudioClip beep;
    [SerializeField] private AudioClip deepBeep;

    private int giftHitChimney;
    private float time = 60f; // 1 minute
    private AudioSource audioSource;
    private bool gameover = false;

    void Awake() {
        giftHitChimney = 0;
        audioSource = GetComponent<AudioSource>();

        DontDestroyOnLoad(timerDisplay);
    }

    void Start() {
        SpawnNewHouse();
    }

    void Update() {
        if (gameover) {
            return;
        }

        if (time <= 0) {
            SceneManager.LoadScene("Over");
            gameover = true;
            return;
        }

        time -= Time.deltaTime;
        timerDisplay.text = (Mathf.FloorToInt(time)).ToString();
    }

    public void restart() {
        giftHitChimney = 0;
        time = 60f;
        gameover = false;    
        SceneManager.LoadScene("Game");
        Destroy(this.gameObject);
    }

    public GameObject[] GetGifts() {
        return gifts;
    }

    public Vector3 GetGiftSpawnPosition() {
        Vector3 position = new Vector3(
            giftSpawnPosition[0],
            giftSpawnPosition[1],
            giftSpawnPosition[2]
        );

        return position;
    }

    public Vector3 GetHouseSpawnPosition() {
        Vector3 position = new Vector3(
            houseSpawnPosition[0],
            houseSpawnPosition[1],
            houseSpawnPosition[2]
        );

        return position;
    }
    
    public Vector3 GetBackgroundSpawnPosition() {
        Vector3 position = new Vector3(
            backgroundSpawnPosition[0],
            backgroundSpawnPosition[1],
            backgroundSpawnPosition[2]
        );

        return position;
    }

    public void GiftHitChimney() {
        giftHitChimney++;
        DisplayGiftHitChimneyCount();
        audioSource.PlayOneShot(beep);
    }

    private void DisplayGiftHitChimneyCount() {
        giftHitDisplay.text = giftHitChimney.ToString();
    }

    public float GetStartOfScreen() {
        return startOfScreen;
    }

    public float GetEndOfScreen() {
        return endOfScreen;
    }

    public void SpawnNewHouse() {
        int randomHouseId = Random.Range(0, houses.Length);
        GameObject randomHouse = houses[randomHouseId]; 
        Vector3 position = GetHouseSpawnPosition();
        Instantiate(randomHouse, position, Quaternion.identity);
    }

    public void GiftHitGround() {
        giftHitChimney--;
        DisplayGiftHitChimneyCount();
        audioSource.PlayOneShot(deepBeep);
    }

    public void SpawnNewBackground() {
        Instantiate(backGround, GetBackgroundSpawnPosition(), Quaternion.identity);
    }

    public int getHits() {
        return giftHitChimney;
    }

}
