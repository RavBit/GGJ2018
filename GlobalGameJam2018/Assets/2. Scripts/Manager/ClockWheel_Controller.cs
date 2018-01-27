using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClockWheel_Controller : MonoBehaviour {
    public bool Triggered = false;
    public Transform EndPosition;
    public GameObject Head;
    public GameObject[] gearsToTurn; //gears to turn on addinghead

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
        Head = Event_Manager.Get_Head();
        RemoveButton();
        gameObject.GetComponent<Collider2D>().enabled = false;
        Head.transform.parent = EndPosition;
        Head.transform.DOMove(EndPosition.position, 3);
        StartCoroutine(OnGearAdded()); //start rotation after x seconds on the now connected gear
    }
    private IEnumerator OnGearAdded()
    {
        yield return new WaitForSeconds(2f);
        for (int i =0;i < gearsToTurn.Length; i++)
        {
            gearsToTurn[i].GetComponent<TurnGearScript>().isActive = true;
        }
    }

}
public enum ClockWheelState {
    Start,
    Stop
}
