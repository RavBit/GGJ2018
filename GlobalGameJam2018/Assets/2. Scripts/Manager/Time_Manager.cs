using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour {

    public void Start() {
        Event_Manager.TimeChange += Change_Time;
    }
    public void TimeChange(int number) {
        switch(number) {
            case (-2):
                Change_Time(Time_States.FastBack);
                break;
            case (-1):
                Change_Time(Time_States.Back);
                break;
            case (0):
                Change_Time(Time_States.Normal);
                break;
            case (1):
                Change_Time(Time_States.Forward);
                break;
            case (2):
                Change_Time(Time_States.FastForward);
                break;
        }
    }
    void Change_Time(Time_States _ts) {
        switch (_ts) {
            case (Time_States.Back):
                Time.timeScale = 0.5f;
                break;
        }
    }

}

public enum Time_States {
    FastBack,
    Back,
    Normal,
    Forward,
    FastForward
}