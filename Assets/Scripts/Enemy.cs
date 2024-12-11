using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerController;
    public NavMeshAgent ai;
    public float hitForce;
    public int health;
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            Die();
        }
        ai.SetDestination(player.transform.position);
    }
    public void Die()
    {
        Destroy(gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.health -= 1;
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position).normalized *hitForce ,ForceMode.VelocityChange);
        }
    }
}
