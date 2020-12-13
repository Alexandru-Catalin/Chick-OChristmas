using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed += 0.1f * Time.deltaTime;
        rb.velocity = new Vector3(0, rb.velocity.y, speed);
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);
    }
}