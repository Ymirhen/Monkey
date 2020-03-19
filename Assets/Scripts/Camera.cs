using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
   
    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
