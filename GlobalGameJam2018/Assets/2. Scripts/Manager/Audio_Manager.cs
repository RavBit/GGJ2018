using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Audio_Manager : MonoBehaviour {
    [Header("Audio Sources")]
    public AudioSource Background_Music;
    public void Start() {
        Event_Manager.MusicChange += Change_Music;
    }
    
    public void Change_Music() {
                Background_Music.DOPitch(Game_Manager.instance.Speed, 0.1f);
    }
}
