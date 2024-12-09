using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
