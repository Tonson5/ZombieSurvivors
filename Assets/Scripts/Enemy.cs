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
    public GameObject waveManager;
    void Start()
    {
        player = GameObject.Find("Player");
        waveManager = GameObject.Find("WaveManager");
        playerController = player.GetComponent<PlayerMovement>();
        health *= waveManager.GetComponent<WaveManager>().wave;
        if (health > 5)
        {
            health = 15;
        }
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
