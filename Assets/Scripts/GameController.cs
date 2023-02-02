using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //score and score text
    public TextMeshProUGUI scoreText;
    private int score;

    //score popup
    public GameObject popup;

    //player
    public GameObject mainCamera;

    //game state
    public enum GameState {
        waiting,
        playing
    }
    public static GameState currentGameState;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.waiting;

        //init score
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore()
    {
        scoreText.text = "Score: " + (++score);
    }

    public void showPopup(Vector3 position)
    {
        Destroy(Instantiate(popup, position, mainCamera.transform.rotation), 3f);
    }
}
