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
    public float chaseThreshold = 30;
    public float chaseMinimum = 4;
    private GameObject targetObject;
    public float jumpCooldown = 2;

    [Header("Stats as percentages")]
    public float enemySpeed = 30;
    public float jumpSpeed = 250;
    public float maxJumpHeight = 2;

    [Header("AI performance settings")]
    public float checkDelay = 0.1f; 

    private bool isChasing;
    private bool isJumping;
    [SerializeField]
    private bool isGrounded;

    //constants
    private static float ENEMY_SPEED = 0.1f;
    private static float JUMP_THRESHOLD = 0.2f;
    [SerializeField]
    private LayerMask groundLayermask;
    private Transform groundedChecker;
    
    enum cooldowns
    {
        jump
    }


	// Use this for initialization
	void Start () {
        groundedChecker = transform.Find("GroundedCheck");
        StartCoroutine(grabReferences());

	}
	
    //we delay starting the enemy to give the singleton time to launch
    private IEnumerator grabReferences()
    {
        yield return new WaitForSeconds(2f);
        targetObject = Game_Manager.instance.playerObject;

        SanitizeInput();
        StartCoroutine(checkForPlayer());
    }
    //checks some input and throws warnings at the user 
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
	void FixedUpdate () {
        isGrounded = false;
        //if we are chasing - decided by a coroutine that checks distance 
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundedChecker.position, 0.2f , groundLayermask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }

        if (isChasing)
        {
            ChaseEnemy();
        }

    }

    //we start chasing the player once he is within reach (chaseThreshold) but stops in front of the target (chaseMinimum)
    private IEnumerator checkForPlayer()
    {

        float distance = Vector2.Distance(gameObject.transform.position, targetObject.transform.position);
        if (distance < chaseThreshold)
        {
            if (distance > chaseMinimum)
            {
                isChasing = true;

                float heightDif = targetObject.transform.position.y - gameObject.transform.position.y;
      
                if (!isJumping && heightDif > JUMP_THRESHOLD && isGrounded)
                {
                    isJumping = true;
                    Jump(heightDif, 0);
                }

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


    void Jump(float heightDifference, float widthDifference)
    {
        if (heightDifference > maxJumpHeight) { heightDifference = maxJumpHeight; }

        gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * heightDifference * (jumpSpeed/100));
        StartCoroutine(Cooldown(cooldowns.jump));
    }

    void ChaseEnemy()
    {
        if (!Physics.Linecast(transform.position, targetObject.transform.position))
        {
            //it's possible to look at target
            Vector2 chaseTransform = Vector2.MoveTowards(transform.position, targetObject.transform.position, ENEMY_SPEED * (enemySpeed / 100));
            transform.position = new Vector2(chaseTransform.x, gameObject.transform.position.y);
        }
    }

    //all enemy cooldowns
    private IEnumerator Cooldown(cooldowns cd)
    {
        if(cd == cooldowns.jump)
        {
            yield return new WaitForSeconds(jumpCooldown);
            isJumping = false;
        }

    }

 
}
