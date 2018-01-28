using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityEngine.UI;
using DG.Tweening;

public class PromptScript1 : MonoBehaviour {
    private bool promptUsed;
    private static float promptTime = 5f;
    public GameObject test;
    public Sprite cutscene2;
    public Sprite logo;
    public AudioSource background;
    public AudioSource cutcene;
    void Start()
    {
        test.GetComponent<Image>().DOFade(0, 0.01f);
        test.GetComponentInChildren<Text>().text = "";
        test.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && !promptUsed)
        {
            promptUsed = true;
            col.gameObject.GetComponent<PlatformerCharacter2D>().isMobile = false;
            test.SetActive(true);
            background.DOFade(0, 1);
            cutcene.Play();
            cutcene.DOFade(1, 1);
            test.GetComponent<Image>().DOFade(1, 2f);
            test.GetComponentInChildren<Text>().DOText("Try to escape from this dead robot by winding your gear",2);
            StartCoroutine(mobilityTimer(col.gameObject));
        }
    }


    private IEnumerator mobilityTimer(GameObject playerObj)
    {
        yield return new WaitForSeconds(3);
        test.GetComponentInChildren<Text>().DOText("To be continued", 1);
        test.GetComponent<Image>().sprite = cutscene2;
        yield return new WaitForSeconds(2);
        test.GetComponentInChildren<Text>().DOText("", 1);
        test.GetComponent<Image>().sprite = logo;
    }
}
