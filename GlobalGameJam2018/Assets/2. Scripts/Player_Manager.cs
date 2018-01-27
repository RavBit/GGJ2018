using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player_Manager : MonoBehaviour {
    public GameObject Head;
    public Transform HeadLocation;
    public Transform EndPosition;

    private Vector2 startPos;
    public Rigidbody2D RB;
    private void Start() {
        Event_Manager.GetHead += GetHead;
        Event_Manager.SetHead += SetHead;

        startPos = gameObject.transform.position;
       
    }
    void Update() {
        RB.mass = Game_Manager.instance.Gravity;
        float speed = Game_Manager.instance.Speed;
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
        head.transform.parent = HeadLocation;
        head.transform.DOMove(EndPosition.position, 1);
        Head = head;
        Invoke("FixHead", 3);
    }

    public void FixHead() {
        Head.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f);
    }
}
