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
    public GameObject lookTarget;
    public Vector3 direction;
    public float lookSpeed;
    public bool canShoot;
    public float shootCoolDown;
    public bool FullAuto;
    public int amountRotatable;
    public int amountToShoot;
    public Money myMoney;
    public GameObject restartButton;
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
            restartButton.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(gameObject);
        }
        if (Input.GetButtonDown("Fire1") && !FullAuto)
        {
            Shoot();
        }
        if (Input.GetButton("Fire1") && FullAuto)
        {
            Shoot();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        lookTarget.GetComponent<Rigidbody>().AddForce(direction * lookSpeed);
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

            direction = (placeToLook - lookTarget.transform.position).normalized;
            
            transform.forward = lookTarget.transform.position - transform.position;
        }
    }
    public void Shoot()
    {
        if (canShoot)
        {
            for (int i = 0; i < amountToShoot; i++)
            {
                Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation).gameObject.GetComponent<Bullet>().amountRotatable = amountRotatable;
            }
            canShoot = false;
            Invoke("Cooldown", shootCoolDown);
        }
    }
    public void Cooldown()
    {
        canShoot = true;
    }
    public void UpgradeShooting()
    {
        if (myMoney.money >= 50)
        {
            myMoney.TakeMoney(50);
            shootCoolDown /= 1.1f;
        }
    }
    public void UpgradeFullAuto()
    {
        if (myMoney.money >= 1000)
        {
            myMoney.TakeMoney(1000);
            FullAuto = true;
        }
    }
    public void UpgradeSpread()
    {
        if (myMoney.money >= 100)
        {
            amountRotatable += 5;
            myMoney.TakeMoney(100);
        }
    }
    public void UpgradeAmountToShoot()
    {
        if (myMoney.money >= 250)
        {
            amountToShoot += 1;
            myMoney.TakeMoney(250);
        }
    }
}
