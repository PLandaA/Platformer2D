using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffects : MonoBehaviour {

    [SerializeField] AudioClip step, jump, getCoin, pressedButton;
    AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
    public void stepSound () {
        audioSource.PlayOneShot(step);

    }
    public void jumpSound () {
        audioSource.PlayOneShot(jump);

    }
    public void getCoinSound () {
        audioSource.PlayOneShot(getCoin);

    }

    public void pressedButtonSound () {
        audioSource.PlayOneShot(pressedButton);
    }

}
