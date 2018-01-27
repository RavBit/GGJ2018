using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour {
    public GameObject Head;
    public Rigidbody2D RB;
    private void Start() {
        Event_Manager.GetHead += GetHead;
    }
    void Update() {
        RB.mass = Game_Manager.instance.Gravity;
        Head.transform.Rotate(0, 0, 20 * -5 * Time.deltaTime);
    }

    public GameObject GetHead() {
        return Head;
    }
}
