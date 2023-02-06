using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5;
    [SerializeField] Rigidbody objectRb;

    private float zBound = 24;

    void Start()
    {

        objectRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //objectRb.AddForce(Vector3.down.normalized * speed*Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(transform.position.z > zBound)
        {
            Destroy(gameObject);
        }
    }
}
