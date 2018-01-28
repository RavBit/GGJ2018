using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour {
    public bool Malfunction = false;

    private void Start() {
        Event_Manager.WheelsMalfunction += StartCoolDown;
        Event_Manager.MalfunctionSet += SetMalfunction;
        StartCoroutine("Regenerate");
    }
    WaitForSeconds waitForSeconds = new WaitForSeconds(5f);

    IEnumerator Regenerate() {
        while (true) {
            Game_Manager.instance.ResetGravity();
            Game_Manager.instance.ResetSpeed();
            yield return waitForSeconds;
        }
    }
    public void SetMalfunction(bool state) {
        Malfunction = state;
    }
    public void TimeChange(int number) {
        if ((Game_Manager.instance.Speed <= 0.1f && !Malfunction || Game_Manager.instance.Gravity <= 0.5f && !Malfunction))
        {
            Event_Manager.Wheels_Malfunction();
            Game_Manager.instance.Lives--;
            Malfunction = true;
        }
        if (Malfunction)
            return;
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

    void StartCoolDown() {
        Game_Manager.instance.Malfunction = 0;
        Handheld.Vibrate();
        Invoke("CoolDown", 4 * Game_Manager.instance.Speed);
    }

    void CoolDown() {
        Game_Manager.instance.Malfunction = 1;
        Event_Manager.Malfunction_Set(false);
        Game_Manager.instance.ResetGravity();
        Game_Manager.instance.ResetSpeed();
        Event_Manager.Wheels_Operate();
        
    }

}

public enum Time_States {
    Gravity,
    Speed,
}