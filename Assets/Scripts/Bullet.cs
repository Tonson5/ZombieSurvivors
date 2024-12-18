using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public int damage;
    public int amountRotatable;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
        transform.Rotate(Vector3.up * Random.Range(-amountRotatable, amountRotatable));
        Invoke("Move", 0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().health -= damage;
            Destroy(gameObject);
        }
    }
    public void Move()
    {
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }
}
