using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityStandardAssets._2D;

public class Player_Manager : MonoBehaviour {
    public GameObject Head;
    public Transform HeadLocation;
    public Transform EndPosition;
    public GameObject _head;
    private Vector2 startPos;
    public Rigidbody2D RB;

    //Text and Images
    public Text LivesText;
    private void Start() {
        Event_Manager.GetHead += GetHead;
        Event_Manager.SetHead += SetHead;

        startPos = gameObject.transform.position;
       
    }
    void Update() {
        RB.mass = Game_Manager.instance.Gravity;
        float speed = Game_Manager.instance.Speed;
        LivesText.text = "" + Game_Manager.instance.Lives;
        if (speed >= 1)
            speed = -1;
        Head.transform.Rotate(0, 0, 20 * speed * Time.deltaTime);

        //temp respawn to same place only above platform when you fall
    if(transform.position.y < -18)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 12);
        }
    }

    public GameObject GetHead() {
        return Head;
    }

    public void SetHead(GameObject head) {
        _head = head;
        Invoke("FixHead", 2);
    }

    public void FixHead() {
        _head.transform.parent = HeadLocation;
        Head.transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
        _head.transform.DOMove(EndPosition.position, 1);
        Head = _head;
        Head.transform.localPosition = Vector3.zero;
        gameObject.GetComponent<Platformer2DUserControl>().enabled = true;
    }
}
