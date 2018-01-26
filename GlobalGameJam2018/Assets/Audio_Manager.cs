using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Audio_Manager : MonoBehaviour {
    [Header("Audio Sources")]
    public AudioSource Background_Music;
    public void Start() {
        Event_Manager.TimeChange += Change_Music;
    }
    
    public void Change_Music(Time_States _ts) {
        switch(_ts) {
            case (Time_States.Back):
                Background_Music.DOPitch(0.5F, 2);
                break;
            case (Time_States.FastBack):
                Background_Music.DOPitch(0.25F, 2);
                break;
            case (Time_States.Forward):
                Background_Music.DOPitch(1.5F, 2);
                break;
        }
    }
}
