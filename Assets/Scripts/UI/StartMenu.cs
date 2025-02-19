using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private UIDocument _startMenuUIDocument;
    
    private VisualElement _rootVisualElement;
    private Button _playButton;
    private Button _quitButton;

    private void Awake()
    {
        _rootVisualElement = _startMenuUIDocument.rootVisualElement;
        
        _playButton = _rootVisualElement.Q<Button>("PlayButton");
        _quitButton = _rootVisualElement.Q<Button>("QuitButton");
        
        _playButton.RegisterCallback<ClickEvent>(OnPlayButtonClick);
        _quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClick);
    }

    private void OnPlayButtonClick(ClickEvent clickEvent)
    {
        SceneManager.LoadSceneAsync(sceneBuildIndex: 1);
    }
    
    private void OnQuitButtonClick(ClickEvent clickEvent)
    {
        Application.Quit();
    }
}
