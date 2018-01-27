using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player_Manager : MonoBehaviour {
    public GameObject Head;
    public Transform HeadLocation;
    public Rigidbody2D RB;
    private void Start() {
        Event_Manager.GetHead += GetHead;
        Event_Manager.SetHead += SetHead;
    }
    void Update() {
        RB.mass = Game_Manager.instance.Gravity;
        Head.transform.Rotate(0, 0, 20 * -5 * Time.deltaTime);
    }

    public GameObject GetHead() {
        return Head;
    }

    public void SetHead(GameObject head) {
        head.transform.parent = HeadLocation;
        head.transform.DOMove(new Vector3(0, 0, 0), 3);
        Head = head;
        Invoke("FixHead", 3);
    }

    public void FixHead() {
        Head.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f);
        Debug.Log("Position");
    }
}
