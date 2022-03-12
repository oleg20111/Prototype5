using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float XRange = 4;
    private float ySpawnPos = -6;
    private GameManager gameManager;
    public ParticleSystem explouionParticle;

    private void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque(){
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-XRange,XRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        gameManager.UpdateScore(pointValue);
        Instantiate(explouionParticle, transform.position, explouionParticle.transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);
    }
}
