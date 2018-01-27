using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Audio_Manager : MonoBehaviour {
    [Header("Audio Sources")]
    public AudioSource Background_Music;
    public AudioSource Destroy_Music;
    public void Start() {
        Event_Manager.MusicChange += Change_Music;
        Event_Manager.WheelsMalfunction += MalFunction;
    }
    
    public void Change_Music() {
                Background_Music.DOPitch(Game_Manager.instance.Speed, 0.1f);
    }

    public void MalFunction() {
        Destroy_Music.Play();
    }
}
