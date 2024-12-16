using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce((player.transform.position - transform.position).normalized * speed,ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(coins, transform.position, transform.rotation);
            other.gameObject.GetComponent<Money>().money += 5;
            Destroy(gameObject);
        }
    }
}
