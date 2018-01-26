using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manager : MonoBehaviour {
    public delegate void Time_Changed(Time_States timestate);
    public static event Time_Changed TimeChange;
    public static void Time_Change(Time_States _timestate) {
        TimeChange(_timestate);
        }
}
