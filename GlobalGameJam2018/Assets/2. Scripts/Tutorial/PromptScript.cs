using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptScript : MonoBehaviour {
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }
}
