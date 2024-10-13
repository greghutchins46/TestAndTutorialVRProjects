using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private Vector3 gravityDirection = new Vector3(0, -9.81f, 0);
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float launchForce;
    [SerializeField] private float gravityMultiplier;
    [SerializeField] private float destroyAfterSeconds;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * launchForce; // Constant velocity forward
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    void FixedUpdate()
    {  // use FixedUpdate for physics stuff
        rb.AddForce(gravityDirection * gravityMultiplier); // I'm applying a custom gravity on this one object
    }
}
