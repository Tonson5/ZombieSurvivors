using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public float turnSpeed;
    public GameObject[] enemies;
    public int health;
    public RawImage image;
    public Texture fullHealth;
    public Texture mediumHealth;
    public Texture lowHealth;
    public GameObject bullet;
    public GameObject bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        RotatePlayer();
        if (health == 3)
        {
            image.texture = fullHealth;
        }
        else if (health == 2)
        {
            image.texture = mediumHealth;
        }
        else if(health == 1)
        {
            image.texture = lowHealth;
        }
        if (health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }
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
            Vector3 direction = placeToLook - transform.position;
            transform.forward = direction;
        }
    }
}
