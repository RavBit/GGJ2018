using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour {

    public void Start() {
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
        Event_Manager.Time_Change(_ts);
    }

}

public enum Time_States {
    FastBack,
    Back,
    Normal,
    Forward,
    FastForward
}