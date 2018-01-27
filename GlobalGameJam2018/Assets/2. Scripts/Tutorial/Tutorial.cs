using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    private List<GameObject> tutorialPrompts = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //add all child objects to our tutorialPrompts list
    void GetAllPrompts()
    {
        foreach (Transform child in transform)
        {
            tutorialPrompts.Add(child.gameObject);
        }

    }
}
