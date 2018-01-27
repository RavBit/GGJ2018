using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTutorial : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
