using simple_math_3_game;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject game;
    [SerializeField] Text scoresText;
    private void Awake()
    {
        Manager.OnGameFinsihed += () =>
        {
            Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("screen").transform).SetData(scoresText.text, () =>
            {
                Manager.Instance.SetDifficult(0);
                Manager.Instance.Start_Game();
            });
        };

        LoadingGO.OnLoadingStarted += () =>
        {
            game.SetActive(false);
        };

        LoadingGO.OnLoadingFinished += () =>
        {
            game.SetActive(true);

            Manager.Instance.SetDifficult(0);
            Manager.Instance.Start_Game();
        };
    }
}
