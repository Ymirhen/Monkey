using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Controls : MonoBehaviour
{
    private Rigidbody sphereRigidbody;

    public int velocityMultiplier = 3;
    void Start()
    {
        sphereRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        sphereRigidbody.velocity = new Vector3(
            Input.GetAxis("Horizontal") * velocityMultiplier,
            sphereRigidbody.velocity.y,
            Input.GetAxis("Vertical") * velocityMultiplier);
    }
}
