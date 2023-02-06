using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 0.1f;
    public Rigidbody enemyRb;
    public GameObject playerGoal;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("Player Goal");
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFaster();
        // Set enemy direction towards player goal and move there


    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }
    void EnemyFaster()
    {
        speed = speed * 1.00001f;
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);
    }

}
