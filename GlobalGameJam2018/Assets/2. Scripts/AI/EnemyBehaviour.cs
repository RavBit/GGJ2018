using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    /// <summary>
    /// basic 2D enemy AI template 
    /// by Frans Huntink
    /// franshuntink.nl
    /// </summary>
    /// 
    [Header("Basic enemy settings")]
    public float enemySpeed;
    public float chaseThreshold = 30;
    public float chaseMinimum = 4;
    private GameObject targetObject;

    [Header("AI performance settings")]
    public float checkDelay = 0.2f; 

    private bool isChasing;
    //constants
    private static float ENEMY_SPEED = 1f;
    

	// Use this for initialization
	void Start () {
        
        targetObject = Game_Manager.instance.playerObject;
        SanitizeInput();
        StartCoroutine(checkForPlayer());
	}
	
    //checks some input and throws some warnings at the user 
    void SanitizeInput()
    {
        if(chaseThreshold == 0)
        {
            Debug.Log("WARNING: No chase threshold set for " + gameObject.name);
        }
        if(targetObject == null)
        {
            Debug.Log("WARNING: No playerObject assigned to Game_Manager - could not retrieve target for enemy " + gameObject.name);
        }
        if(enemySpeed == 0)
        {
            Debug.Log("Speed is set to 0 for enemy: " + gameObject.name);
        }
    }

	// Update is called once per frame
	void Update () {
        Debug.Log(isChasing);
    
        //if we are chasing - decided by a coroutine that checks distance 
       if(isChasing)
        {
            ChaseEnemy();
        }
    }

    //we start chasing the player once he is within reach (chaseThreshold) but stops in front of the target (chaseMinimum)
    private IEnumerator checkForPlayer()
    {
        if (Vector2.Distance(gameObject.transform.position, targetObject.transform.position) < chaseThreshold)
        {
            if (Vector2.Distance(gameObject.transform.position, targetObject.transform.position) > chaseMinimum)
            {
                isChasing = true;
            }
            else
            {
                isChasing = false;
            }
         
        }
        else
        {
            isChasing = false;
        }
        yield return new WaitForSeconds(checkDelay);
        StartCoroutine(checkForPlayer());
    }

    void ChaseEnemy()
    {
        if (!Physics.Linecast(transform.position, targetObject.transform.position))
        {
            Vector2 chaseTransform =  Vector2.MoveTowards(transform.position, targetObject.transform.position, Game_Manager.instance.Speed * ENEMY_SPEED * (enemySpeed / 100));
            transform.position = new Vector2(chaseTransform.x, gameObject.transform.position.y);
        }

    }
}
