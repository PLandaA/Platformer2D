using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour {
    [SerializeField] GameObject cmVCam;

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
            cmVCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
            cmVCam.SetActive(false);
        }
    }
}
