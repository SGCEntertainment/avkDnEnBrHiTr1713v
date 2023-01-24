using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(-14, Random.Range(-2.0f, 3.0f));
        transform.localScale = Vector3.one * Random.Range(0.7f, 1.35f);
    }

    private void Update()
    {
        transform.Translate(5 * Time.deltaTime * Vector2.right);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
