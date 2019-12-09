using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSet : MonoBehaviour
{
    [SerializeField] private GameObject house1;
    [SerializeField] private GameObject house2;
    [SerializeField] private GameObject house3;

    public void ChangeHouses(GameObject[] newHouses) {
        house1 = newHouses[0];
        house2 = newHouses[1];
        house3 = newHouses[2];
    }
}
