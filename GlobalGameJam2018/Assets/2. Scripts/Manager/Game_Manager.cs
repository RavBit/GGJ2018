using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

    public static Game_Manager instance;

    public float Gravity = 1;
    public float WheelSpeed = 1;
    public float Speed = 1;

    

    private void Awake() {
        if (instance != null)
            Debug.LogError("More than one Game Manager in the scene");
        else
            instance = this;
    }

    public void ResetSpeed() {
        Debug.Log("resetspeed");
        StartCoroutine("TimerSpeed");
    }
    public IEnumerator TimerSpeed() {
        yield return new WaitForSeconds(3);
        while (Speed < 1) {
            Debug.Log("Slowing");
            Game_Manager.instance.Speed += 0.1f;
            Game_Manager.instance.WheelSpeed -= 0.25f;
            Event_Manager.Music_Change();
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Normalized");
    }
}
