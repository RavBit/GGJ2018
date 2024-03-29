﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

    public static Game_Manager instance;

    public float WheelGravity = 1;
    public float Gravity = 1;
    public float WheelSpeed = 1;
    public float Speed = 1;
    public float Malfunction = 1;
    public int Lives = 3;

    //sketchy player related stuff
    public bool playerIsMobile;


    public GameObject playerObject;


    private void Awake() {
        if (instance != null)
            Debug.LogError("More than one Game Manager in the scene");
        else
            instance = this;


    }
    private void Start()
    {
        Lives = 3;
        playerObject = GameObject.Find("Player");
    }
    private void Update() {
        Time.timeScale = Speed * 1 * .5f;
    }
    public void ResetSpeed() {
        Debug.Log("resetspeed");
        StartCoroutine("TimerSpeed");
    }
    public IEnumerator TimerSpeed() {
        while (Speed < 1 && Malfunction == 1) {
            Debug.Log("Slowing");
            Game_Manager.instance.Speed += 0.1f;
            Game_Manager.instance.WheelSpeed -= 0.25f;
            Event_Manager.Music_Change();
            yield return new WaitForSeconds(1 * Speed);
        }
       // Debug.Log("Normalized");
    }
    public void ResetGravity(){
        Debug.Log("resetspeed");
        StartCoroutine("TimerGravity");
    }
    public IEnumerator TimerGravity() {
        while (Gravity < 1) {
            Debug.Log("Slowing");
            Game_Manager.instance.Gravity += 0.1f;
            Game_Manager.instance.WheelGravity -= 0.25f;
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Normalized");
    }
}
