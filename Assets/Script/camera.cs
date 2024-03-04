using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
    }
}