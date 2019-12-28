using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    [SerializeField] private GameObject[] houses;
    [SerializeField] private GameObject[] gifts; 
    [SerializeField] private GameObject backGround;
    [SerializeField] private GameObject pavement;
    [SerializeField] private GameObject booster;
    [SerializeField] private float[] giftSpawnPosition;
    [SerializeField] private float[] houseSpawnPosition;
    [SerializeField] private float[] backgroundSpawnPosition;
    [SerializeField] Text giftHitDisplay;
    [SerializeField] Text timerDisplay;
    [SerializeField] float startOfScreen;
    [SerializeField] float endOfScreen;
    [SerializeField] private AudioClip beep;
    [SerializeField] private AudioClip deepBeep;
    [SerializeField] private float time = 60f; // 1 minute

    private int giftHitChimney;
    private AudioSource audioSource;
    private bool gameover = false;

    private float timeFromLastBooster = 0f;

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

        timeFromLastBooster += Time.deltaTime;
        Boost();
    }

    public void restart() {
        giftHitChimney = 0;
        time = 60f;
        gameover = false;    
        SceneManager.LoadScene("Game");
        Destroy(this.gameObject);
    }

    private void Boost() {
        if (timeFromLastBooster > 15f) {
            if (Random.Range(0, 10) % 3 == 0) {
                Instantiate(booster, new Vector3(3.33f, -3.33f, -55f), Quaternion.identity);
                timeFromLastBooster = 0;
            }
        }
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

    public Vector3 GetHouseSpawnPosition(GameObject house) {
        float width = house.GetComponent<SpriteRenderer>().bounds.size.x;
        float height = house.GetComponent<SpriteRenderer>().bounds.size.y;

        Vector3 position = new Vector3(
            houseSpawnPosition[0] + width/2,
            houseSpawnPosition[1] + height/2.9f,
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
        Vector3 position = GetHouseSpawnPosition(randomHouse);
        Instantiate(randomHouse, position, Quaternion.identity);
    }

    public void SpawnNewPavement() {
        float width = pavement.GetComponent<SpriteRenderer>().bounds.size.x;
        Vector3 position = new Vector3(endOfScreen + width/2 - 0.1f, -4.6f, -4f);
        Instantiate(pavement, position, Quaternion.identity);
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

    public void ActivateBooster() {
        time += 10f;
    }

}
