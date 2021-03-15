using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameManager.WorldColour team = GameManager.WorldColour.White;
    public bool passiveBool;
    public float movementSpeed;
    public float losDistance;
    public int damageValue = 1;
    public bool inPursuit;
    public bool retreating;
    Animator animator;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    private Vector3 startPursuitLocation;
    private Vector3 endPursuitLocation;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        startPursuitLocation = transform.position;
        int randomizedTeamNum = Random.Range(1, 4);
        if (randomizedTeamNum == 1)
        {
            team = GameManager.WorldColour.Red;
        }
        else if (randomizedTeamNum == 2)
        {
            team = GameManager.WorldColour.Green;
        }
        else
        {
            team = GameManager.WorldColour.Blue;
        }
        if (team == GameManager.WorldColour.White)
        {
            skinnedMeshRenderer.material.color = Color.white;
        }
        else if (team == GameManager.WorldColour.Red)
        {
            skinnedMeshRenderer.material.color = Color.red;
        }
        else if (team == GameManager.WorldColour.Green)
        {
            skinnedMeshRenderer.material.color = Color.green;
        }
        else if (team == GameManager.WorldColour.Blue)
        {
            skinnedMeshRenderer.material.color = Color.blue;
        }
    }

    void PlayerDetection()
    {
        int layerMask = 1 << 6;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), losDistance, layerMask) && !retreating)
        {
            //Debug.Log("Did Hit");
            if (team != GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentColour)
            {
                inPursuit = true;
                endPursuitLocation = GameObject.FindWithTag("Player").transform.position;
            }
        }
    }

    void Update()
    {
        if (!GameObject.FindWithTag("GameManager").GetComponent<GameManager>().IsPaused())
        {
            animator.SetBool("isRunning", true);
            if (inPursuit || retreating)
            {
                animator.SetBool("isRunning", true);
            }
            else if (!inPursuit && !retreating)
            {
                animator.SetBool("isRunning", false);
            }
            PlayerDetection();
            if (GameObject.FindWithTag("GameManager") != null)
            {
                if (inPursuit && team != GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentColour)
                {
                    transform.position = Vector3.MoveTowards(transform.position, endPursuitLocation, movementSpeed);
                    if (transform.position == endPursuitLocation)
                    {
                        inPursuit = false;
                        retreating = true;
                    }
                }
            }
            else if (retreating)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPursuitLocation, movementSpeed);
                if (transform.position.x == startPursuitLocation.x && transform.position.y == startPursuitLocation.y)
                {
                    retreating = false;
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damageValue);
            inPursuit = false;
            retreating = true;
        }
    }
}
