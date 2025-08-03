using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float pushForce = 2000f;
    private float movement;

    [SerializeField]
    private float speed = 1.5f;

    public Vector3 respawnPoint;
    private GameManager gameManager;

    public AudioSource crashSound;

     void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = this.transform.position;
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }


    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.AddForce(0, 0, pushForce * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector3(movement * speed, rb.linearVelocity.y, rb.linearVelocity.z);

        fallDetector();

    }


    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Barrier"))
        {
            gameManager.RespawnPlayer();
            crashSound.Play();
        }
    }

    private void fallDetector()
    {
        if(rb.position.y < -2f){
            gameManager.RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndTrigger")){
            gameManager.LevelUp();
        }
       ;
    }
}
