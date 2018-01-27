using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Regrow : MonoBehaviour {
    public GameObject Head;

    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("col " + coll.gameObject.name);
        if (coll.gameObject.tag == "Player") {
            Event_Manager.Set_Head(Head);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
        
    }
}
