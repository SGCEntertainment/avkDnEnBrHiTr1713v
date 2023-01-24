using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private bool IsStarted { get; set; }
    private int bulletId;

    private GameObject EnemyPrefab { get; set; }
    private Transform EnemyParent { get; set; }

    [SerializeField] GameObject game;
    [SerializeField] GameObject result;
    [SerializeField] GameObject taptostart;

    [Space(10)]
    [SerializeField] Transform bullets;

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
        bulletId = bullets.childCount - 1;

        foreach(Transform t in bullets)
        {
            t.gameObject.SetActive(true);
        }

        game.SetActive(true);
        taptostart.SetActive(false);

        StartCoroutine(nameof(EnemySpawning));
    }

    public void Shoot()
    {
        bullets.GetChild(bulletId).gameObject.SetActive(false);

        bulletId--;
        if(bulletId <=0)
        {
            GameOver();
            return;
        }
    }

    private void GameOver()
    {
        foreach(Enemy enemy in FindObjectsOfType<Enemy>())
        {
            Destroy(enemy.gameObject);
        }

        game.SetActive(false);
        result.SetActive(true);
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
