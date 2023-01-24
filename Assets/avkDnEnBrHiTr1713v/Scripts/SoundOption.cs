using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    private Image Image { get; set; }

    [SerializeField] Sprite on;
    [SerializeField] Sprite off;

    private void Awake()
    {
        Image = GetComponent<Image>();
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioListener.pause = !AudioListener.pause;
            Image.sprite = AudioListener.pause ? off : on;
        });
    }
}
