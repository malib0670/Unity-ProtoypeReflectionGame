using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 14;
    private float maxSpeed = 16;
    private float maxTorque = 50;
    private float xRange = 4;
    private float ySpawnPos = -4;

    public int pointValue;

    private Rigidbody targetRb;
    private GameManager gameManager; 
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        moveStart();
    }

    // Update is called once per frame
    void Update()
    {
        moveUpdate();
    }

    public void moveStart()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 

        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(randomForce(), ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), randomTorque(), randomTorque()); 

        targetRb.transform.position = randomSpawnPos();
    }

    public void moveUpdate()
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad")){ 
            gameManager.gameOver();
        }
    }

    public void OnMouseDown() 
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.updateScore(pointValue); 
            Instantiate(explosionParticle, targetRb.transform.position, explosionParticle.transform.rotation);
        }
    }

    Vector3 randomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float randomTorque()
    {
        return Random.Range(-maxTorque, maxTorque); 
    }

    Vector3 randomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
}
