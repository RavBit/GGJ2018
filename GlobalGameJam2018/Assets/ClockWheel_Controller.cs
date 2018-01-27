using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockWheel_Controller : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("col " + coll.gameObject.name);
        if (coll.gameObject.tag == "Player")
            Debug.Log("COLLISION");
    }
    }
