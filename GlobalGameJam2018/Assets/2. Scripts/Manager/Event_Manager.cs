using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Manager : MonoBehaviour {
    public delegate void Time_Changed(Time_States timestate);
    public static event Time_Changed TimeChange;
    public delegate void Music_Changed();
    public static event Music_Changed MusicChange;
    public delegate void ClockWheel_UI(ClockWheelState CWS);
    public static event ClockWheel_UI ClockWheelChange;
    public delegate Button Button_Get_Button();
    public static event Button_Get_Button GetButton;
    public delegate void Malfunct();
    public static event Malfunct WheelsMalfunction;
    public static event Malfunct WheelsOperate;
    public delegate GameObject HeadGet();
    public static event HeadGet GetHead;
    public delegate void SetMalfunction(bool state);
    public static event SetMalfunction MalfunctionSet;
    public delegate void HeadSet(GameObject head);
    public static event HeadSet SetHead;
    public static void Time_Change(Time_States _timestate) {
        if (Game_Manager.instance.Speed <= 0.1f)
            return;
        if (Game_Manager.instance.Gravity <= 0.5f)
            return;
        TimeChange(_timestate);
    }
    public static void Music_Change() {
        MusicChange();
    }
    public static void ClockWheel_Change(ClockWheelState CWS) {
        ClockWheelChange(CWS);
    }
    public static Button Get_Button() {
        return GetButton();
    }
    public static void Malfunction_Set(bool state) {
        MalfunctionSet(state);
    }
    public static GameObject Get_Head() {
        return GetHead();
    }
    public static void Set_Head(GameObject head) {
        SetHead(head);
    }
    public static void Wheels_Malfunction() {
        WheelsMalfunction();
    }
    public static void Wheels_Operate() {
        WheelsOperate();
    }
}
