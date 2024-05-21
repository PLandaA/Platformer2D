using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //Singleton
    public static GameManager gameManager;

    [SerializeField] GameObject door1, closedDoorA2, openDoorA2, buttonOn, buttonOff, terrain;
    [SerializeField] float doorSpeed;


    public bool puzzle1, puzzle2, puzzle3;

    void Start () {
        gameManager = this;
        puzzle1 = false;
        puzzle2 = false;
        puzzle3 = false;
    }

    // Update is called once per frame
    void Update () {
        if (puzzle1) {
            openDoor1();
        } if (puzzle2) {
            openDoor2();
        } if (puzzle3) {
            PressedButton();
        }
    }
    void openDoor1 () {
        Vector3 doorPos = door1.transform.position;
        if (doorPos.y > -8) {
            door1.transform.position = new Vector3(doorPos.x, doorPos.y - doorSpeed, doorPos.z);

        } 
    }
    public void openDoor2 () {
        closedDoorA2.SetActive(false);
        openDoorA2.SetActive(true);

    }

    public void PressedButton () {
        buttonOff.SetActive(false);
        buttonOn.SetActive(true);
        terrain.SetActive(true);

    }
}
