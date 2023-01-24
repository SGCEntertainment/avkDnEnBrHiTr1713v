using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool IsStarted { get; set; }

    [SerializeField] GameObject game;
    [SerializeField] GameObject taptostart;

    private void Awake()
    {
        game.SetActive(false);
    }

    private void Update()
    {
        if(!IsStarted && Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        IsStarted = true;

        game.SetActive(true);
        taptostart.SetActive(false);
    }
}
