using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    public int scoreValue;

    public AudioSource coinSound;
    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(scoreValue);
            coinSound.Play();
            Destroy(this.gameObject);
        }

    }
}
