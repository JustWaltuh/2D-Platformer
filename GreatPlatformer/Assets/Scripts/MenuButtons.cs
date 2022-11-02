using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _controlsBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private Button _ruleBtn;

    [SerializeField] private Button _toMenuBtn;
    [SerializeField] private GameObject _toMenuGM;

    [SerializeField] private GameObject _controlsMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _ruleMenu;





    private void Awake()
    {
        _startBtn.onClick.AddListener(() => StartGame());
        _exitBtn.onClick.AddListener(() => ExitGame());
        _controlsBtn.onClick.AddListener(() => ShowControls());
        _toMenuBtn.onClick.AddListener(() => ShowMenu());
        _ruleBtn.onClick.AddListener(() => ShowRules());
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void ShowControls()
    {
        _toMenuGM.SetActive(true);
        _controlsMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }

    private void ShowMenu()
    {
        _toMenuGM.SetActive(false);
        _mainMenu.SetActive(true);
        _controlsMenu.SetActive(false);
        _ruleMenu.SetActive(false);
    }

    private void ShowRules()
    {
        _toMenuGM.SetActive(true);
        _ruleMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }
}
