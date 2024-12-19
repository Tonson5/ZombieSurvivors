using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    public AudioSource sfx;
    public AudioClip pickup;
    public GameObject player;
    public GameObject coins;
    public Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.position = new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y, transform.position.z + Random.Range(-2f, 2f));
        rb.AddTorque(transform.up * Random.Range(-180f, 180f), ForceMode.Impulse);
        sfx = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).magnitude < 5)
        {
            rb.AddForce((player.transform.position - transform.position).normalized * speed, ForceMode.Force);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sfx.PlayOneShot(pickup);
            Instantiate(coins, transform.position, transform.rotation);
            other.gameObject.GetComponent<Money>().money += 5;
            Destroy(gameObject);
        }
    }
}
