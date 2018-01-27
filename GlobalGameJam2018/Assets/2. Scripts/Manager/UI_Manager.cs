using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UI_Manager : MonoBehaviour {
    [Header("Gear GameObjects")]
    public GameObject GearInteraction;
    public GameObject GearSpeed;
    public GameObject GearGravity;

    [Header("Transforms for Interaction")]
    public Transform StartInteraction;
    public Transform StopInteraction;
    public void Start() {
        Event_Manager.TimeChange += Rotate_Wheel;
        Event_Manager.ClockWheelChange += ToggleInteraction;
        Event_Manager.GetButton += GetButton;
        Event_Manager.WheelsMalfunction += DisableButtons;
        Event_Manager.WheelsOperate += EnableButtons;
    }
    public Button GetButton() {
        return GearInteraction.GetComponent<Button>();
    }
    public void Rotate_Wheel(Time_States _ts) {
        switch (_ts) {
            case (Time_States.Speed):
                Game_Manager.instance.Speed -= 0.1f;
                Game_Manager.instance.WheelSpeed += 0.25f;
                Event_Manager.Music_Change();
                break;
            case (Time_States.Gravity):
                Game_Manager.instance.Gravity -= 0.1f;
                Game_Manager.instance.WheelGravity += 0.25f;
                break;
        }
    }
    private void Update() {
        float speed = Game_Manager.instance.WheelSpeed;
        if (Game_Manager.instance.WheelSpeed == 1) {
            speed = -1;
        }
        float speed2 = Game_Manager.instance.WheelGravity;
        if (Game_Manager.instance.WheelGravity == 1) {
            speed2 = -1;
        }
        GearSpeed.transform.Rotate(0, 0, Game_Manager.instance.Malfunction * 20 * speed * Time.deltaTime);
        GearGravity.transform.Rotate(0, 0, 20 * Game_Manager.instance.Malfunction * speed2 * Time.deltaTime);
        GearInteraction.transform.Rotate(0, 0, 20 * -5 * Time.deltaTime);
    }
    public void ToggleInteraction(ClockWheelState cws) {
        switch (cws) {
            case (ClockWheelState.Start):
                GearInteraction.transform.DOMove(StartInteraction.transform.position, 2);
                break;
            case (ClockWheelState.Stop):
                GearInteraction.transform.DOMove(StopInteraction.transform.position, 2);
                break;
        }
    }

    public void DisableButtons() {
        GearSpeed.GetComponent<Button>().interactable = false;
        GearGravity.GetComponent<Button>().interactable = false;
    }
    public void EnableButtons() {
        GearSpeed.GetComponent<Button>().interactable = true;
        GearGravity.GetComponent<Button>().interactable = true;
    }
}
