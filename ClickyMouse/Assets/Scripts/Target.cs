using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    public GameManager gameManager;
    public Rigidbody targetRb;
    public ParticleSystem targetParticle;
    public int updateScore;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(3, 8), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), 6);

        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);


    }


    void Update()
    {
        if (targetRb.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(targetParticle, transform.position, targetParticle.transform.rotation);
            gameManager.UpdateScore(updateScore);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }


    public Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    public float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    public Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
