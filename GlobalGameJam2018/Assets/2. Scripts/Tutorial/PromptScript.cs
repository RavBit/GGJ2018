using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PromptScript : MonoBehaviour {
    private bool promptUsed;
    private static float promptTime = 2f;
    void Start()
    {

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && !promptUsed)
        {
            promptUsed = true;
            col.gameObject.GetComponent<PlatformerCharacter2D>().isMobile = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;

            StartCoroutine(mobilityTimer(col.gameObject));
        }
    }


    private IEnumerator mobilityTimer(GameObject playerObj)
    {
        yield return new WaitForSeconds(promptTime);
        playerObj.GetComponent<PlatformerCharacter2D>().isMobile = true;
    }
}
