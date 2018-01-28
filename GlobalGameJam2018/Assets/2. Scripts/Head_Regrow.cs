using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Head_Regrow : MonoBehaviour {
    public GameObject Head;

    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("col " + coll.gameObject.name);
        if (coll.gameObject.tag == "Player") {
            coll.gameObject.GetComponent<Platformer2DUserControl>().enabled = false;
            Event_Manager.Set_Head(Head);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
        
    }
}
