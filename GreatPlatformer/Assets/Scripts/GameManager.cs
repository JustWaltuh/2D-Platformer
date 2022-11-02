using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _exitBtn;

    [SerializeField] public GameObject _inGameMenu;

    private void Awake()
    {
        _exitBtn.onClick.AddListener(() => ExitGame());
        _restartBtn.onClick.AddListener(() => RestartLevel());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) InGameMenuShow();
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void InGameMenuShow()
    {
        if (!_inGameMenu.activeSelf) _inGameMenu.SetActive(true);
        else _inGameMenu.SetActive(false);
    }
}
