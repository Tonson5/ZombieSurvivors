using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerController;
    public NavMeshAgent ai;
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ai.SetDestination(player.transform.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.health -= 1;
        }
    }
}
