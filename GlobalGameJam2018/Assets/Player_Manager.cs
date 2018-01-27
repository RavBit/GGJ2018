using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour {

    public Rigidbody2D RB;
	void Update () {
        RB.mass = Game_Manager.instance.Gravity;
	}
}
