using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float respawnDelay = 2f;
    private bool isGameEnding = false;
    private int score;
    public Text scoreText;
    public Text winText;
    public GameObject WinnerUI;

    void Start()
    {
        playerController = Object.FindFirstObjectByType<PlayerController>();
    }


    public void RespawnPlayer()
    {
        if (isGameEnding == false)
        {
            isGameEnding = true;
            StartCoroutine(RespawnCoroutine());
        }
    }

    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //playerController.transform.position = playerController.respawnPoint;
        //playerController.gameObject.SetActive(true);
        isGameEnding = false;
    }

    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text = score.ToString();
    }


    public void LevelUp()
    {
        WinnerUI.SetActive(true);
        Invoke("NextLevel", respawnDelay);
        winText.text = "Seviye Tamamlandı! Toplam puan " + score;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
