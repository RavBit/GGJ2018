using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour {
    void OnCollisionStay2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player") {
            Debug.Log("Collision");
            coll.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
    }
}