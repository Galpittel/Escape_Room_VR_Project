using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_movement_script : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject spider;
    Vector3 AI_direction;
    Animator animator;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spider = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        ChangeMovement();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //wait();
        if (lastPosition == agent.transform.position)
        {
            ChangeMovement();
        }
        lastPosition = agent.transform.position;
        animator.SetFloat("Move",agent.velocity.magnitude);
    }
    IEnumerable wait()
    {
        yield return new WaitForSeconds(2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Walls" || collision.transform.tag == "Spiders")
        {
            //ChangeMovement();
            die();
        }
    }
    private void Movement()
    {
        agent.destination = AI_direction;
    }
    private void ChangeMovement()
    {
        AI_direction = new Vector3(Random.Range(-100, 100), agent.transform.position.y, Random.Range(-100, 100));
    }
    public void die()
    {
        animator.SetFloat("Die", 0.5f);
        wait();
        spider.SetActive(false);
    }
}
