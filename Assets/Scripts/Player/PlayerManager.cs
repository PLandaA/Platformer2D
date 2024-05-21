using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour {

    int coinCount;
    PlayerSoundEffects soundEffects;
    void Start () {
        coinCount = 0;
        soundEffects = GetComponent<PlayerSoundEffects>();
    }

    void Update () {
        if ((coinCount >= 10)) {
            GameManager.gameManager.puzzle1 = true;
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Coin")) {
            collision.gameObject.GetComponent<CoinBehaviour>().popCoin();
            coinCount++;
            soundEffects.getCoinSound();
        } else if (collision.gameObject.name.Equals("Key")) {
            GameManager.gameManager.puzzle2 = true;
            collision.gameObject.GetComponent<CoinBehaviour>().popCoin();
            soundEffects.getCoinSound();

        } else if (collision.gameObject.name.Equals("buttonOff")) {
            GameManager.gameManager.puzzle3 = true;
            soundEffects.pressedButtonSound();

        } else if (collision.gameObject.name.Equals("TriggerMenu")) {
            SceneManager.LoadScene("MainMenuScene");
            

        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.name.Equals("CloseDoorEnterA2") && GameManager.gameManager.puzzle2) {
            GameManager.gameManager.openDoor2();
        }
    }
}
