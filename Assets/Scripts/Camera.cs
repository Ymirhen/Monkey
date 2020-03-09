using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject target;
    public Vector3 offset;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
