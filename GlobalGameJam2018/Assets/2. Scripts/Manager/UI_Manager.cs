using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UI_Manager : MonoBehaviour {
    public GameObject Gear;
    public void Start() {
        Event_Manager.TimeChange += Rotate_Wheel;
    }

    public void Rotate_Wheel(Time_States _ts) {
        switch (_ts) {
            case (Time_States.Back):
                Game_Manager.instance.Speed -= 0.1f;
                Game_Manager.instance.WheelSpeed += 0.25f;
                Event_Manager.Music_Change();
                break;
        }
    }
    private void Update() {
        float speed = Game_Manager.instance.WheelSpeed;
        if (Game_Manager.instance.WheelSpeed == 1) {
            speed = -1;
        }
        Gear.transform.Rotate(0, 0 , 20 * speed * Time.deltaTime);
    }
}
