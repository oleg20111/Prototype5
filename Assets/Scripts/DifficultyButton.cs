using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public GameObject titleScreen;
    public int difficulty;

    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").gameObject.GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        titleScreen.SetActive(false);
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}
