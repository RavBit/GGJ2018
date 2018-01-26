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

    public float enemySpeed;
    public float chaseThreshold;
    private GameObject targetObject;

    //constants
    private static float ENEMY_SPEED = 1f;


	// Use this for initialization
	void Start () {
        
        targetObject = Game_Manager.instance.playerObject;
        SanitizeInput();
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

       if(Vector2.Distance(gameObject.transform.position,targetObject.transform.position) < chaseThreshold)
        {
            ChaseEnemy();
        }
    }


    void ChaseEnemy()
    {
        if (!Physics.Linecast(transform.position, targetObject.transform.position))
        {
            //if there is no obstruction we start chasing
            gameObject.transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, ENEMY_SPEED * (enemySpeed/100));
        }

    }
}
