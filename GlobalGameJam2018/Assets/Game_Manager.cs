using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

    public static Game_Manager instance;


    private void Awake() {
        if (instance != null)
            Debug.LogError("More than one Game Manager in the scene");
        else
            instance = this;
    }
}
