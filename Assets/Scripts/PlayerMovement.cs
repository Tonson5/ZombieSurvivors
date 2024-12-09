using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        RotatePlayer();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }
    public void MovePlayer()
    {
        rb.AddForce((Vector3.forward * Input.GetAxisRaw("Vertical") + Vector3.right * Input.GetAxisRaw("Horizontal")).normalized * moveSpeed);
    }
    public void RotatePlayer()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            Vector3 placeToLook = enemies[0].transform.position;
            if (enemies.Length != 1)
            {
                for (int i = 0; i < enemies.Length; i++)
                {

                    if ((enemies[i].transform.position - transform.position).magnitude < (placeToLook - transform.position).magnitude)
                    {
                        placeToLook = enemies[i].transform.position;
                    }
                }
            }
            else
            {
                placeToLook = enemies[0].transform.position;
            }
            transform.forward = placeToLook - transform.position;
        }
    }
}
