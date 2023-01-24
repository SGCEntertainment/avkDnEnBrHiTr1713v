using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool IsStarted { get; set; }

    private GameObject EnemyPrefab { get; set; }
    private Transform EnemyParent { get; set; }

    [SerializeField] GameObject game;
    [SerializeField] GameObject result;
    [SerializeField] GameObject taptostart;

    private void Awake()
    {
        game.SetActive(false);
        result.SetActive(false);

        EnemyPrefab = Resources.Load<GameObject>("enemy");
        EnemyParent = GameObject.Find("Environment").transform;
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

        StartCoroutine(nameof(EnemySpawning));
    }

    private IEnumerator EnemySpawning()
    {
        while(true)
        {
            Instantiate(EnemyPrefab, EnemyParent);
            yield return new WaitForSeconds(Random.Range(0.25f, 1.25f));
        }
    }
}
