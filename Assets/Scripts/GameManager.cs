using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : Singleton<GameManager> {
    [SerializeField] private HouseSet houseSet;
    [SerializeField] private GameObject[] houses;
    [SerializeField] private GameObject[] gifts; 
    [SerializeField] private float[] giftSpawnPosition;
    [SerializeField] Text giftHitDisplay;
    [SerializeField] float endOfScreen;

    private int giftHitChimney;

    void Awake() {
        giftHitChimney = 0;
    }

    void Start() {
        
    }

    void Update() {
        
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

    public void GiftHitChimney() {
        giftHitChimney++;
        DisplayGiftHitChimneyCount();
    }

    private void DisplayGiftHitChimneyCount() {
        giftHitDisplay.text = giftHitChimney.ToString();
    }

    public float GetEndOfScreen() {
        return endOfScreen;
    }

    public void SpawnNewHouses() {
        Instantiate(houseSet, new Vector3(endOfScreen+5f, -1.3f, 0), Quaternion.identity);
        // HouseSet newHouseSet = Instantiate(houseSet) as HouseSet;
        // GameObject[] randomHouseSprites = new GameObject[3];
        // randomHouseSprites[0] = houses[0];
        // randomHouseSprites[1] = houses[0];
        // randomHouseSprites[2] = houses[0];
        // newHouseSet.ChangeHouses(randomHouseSprites);
        // Instantiate(newHouseSet, new Vector3(endOfScreen, 0f, 0f), Quaternion.identity);
    }
}
