using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClockWheel_Controller : MonoBehaviour {
    public bool Triggered = false;
    public Transform EndPosition;
    public GameObject Head;

    private void Start() {
    }
    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("col " + coll.gameObject.name);
        if (coll.gameObject.tag == "Player") {
            Event_Manager.ClockWheel_Change(ClockWheelState.Start);
            Button btn = Event_Manager.Get_Button();
            if (!Triggered) {
                btn.onClick.AddListener(DoAnim);
                Triggered = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D coll) {
        Debug.Log("col " + coll.gameObject.name);
        if (coll.gameObject.tag == "Player") {
            RemoveButton();
            Triggered = false;
        }
    }
    void RemoveButton() {
        Event_Manager.ClockWheel_Change(ClockWheelState.Stop);
        Button btn = Event_Manager.Get_Button();
        btn.onClick.RemoveAllListeners();
    }

    void DoAnim() {
        RemoveButton();
        gameObject.GetComponent<Collider2D>().enabled = false;
        Head.transform.parent = EndPosition;
        Head.transform.DOMove(EndPosition.position, 3);
    }

}
public enum ClockWheelState {
    Start,
    Stop
}
