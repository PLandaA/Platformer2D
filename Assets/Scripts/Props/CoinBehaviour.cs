using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    [SerializeField] GameObject popCoinPrefab;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void popCoin () {
        Instantiate(popCoinPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
