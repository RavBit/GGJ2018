using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour {

    public void TimeChange(int number) {
        switch(number) {
            case (0):
                Change_Time(Time_States.Speed);
                break;
            case (1):
                Change_Time(Time_States.Gravity);
                break;
        }
    }
    void Change_Time(Time_States _ts) {
        Event_Manager.Time_Change(_ts);
    }

}

public enum Time_States {
    Gravity,
    Speed,
}