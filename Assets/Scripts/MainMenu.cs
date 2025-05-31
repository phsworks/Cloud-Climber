using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public static bool isRestarted = false;
    [SerializeField] private UIDocument mainMenuDocument;
    [SerializeField] private UIDocument controlsMenuDocument;
    [SerializeField] private UIDocument endScreenDocument;
    [SerializeField] private GameObject gameRoot;

    private Button ControlsButton;
    private Button PlayButton;
    private Button ControlsMenuButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (isRestarted)
        {
            mainMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
            controlsMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
            endScreenDocument.rootVisualElement.style.display = DisplayStyle.None;
            gameRoot.SetActive(true);
            return;
        }

        VisualElement root = mainMenuDocument.rootVisualElement;
        VisualElement controlsRoot = controlsMenuDocument.rootVisualElement;
        endScreenDocument.rootVisualElement.style.display = DisplayStyle.None;

        PlayButton = root.Q<Button>("PlayButton");
        ControlsButton = root.Q<Button>("ControlsButton");
        ControlsMenuButton = controlsRoot.Q<Button>("ControlsMenuButton");


        PlayButton.clickable.clicked += PlayGame;
        ControlsButton.clickable.clicked += ShowControlsMenu;
        ControlsMenuButton.clickable.clicked += ShowMainMenu;

    }

    private void ShowControlsMenu()
    {
        mainMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
        endScreenDocument.rootVisualElement.style.display = DisplayStyle.None;
        controlsMenuDocument.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    private void ShowMainMenu()
    {
        mainMenuDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        endScreenDocument.rootVisualElement.style.display = DisplayStyle.None;
    }


    private void PlayGame()
    {


        gameRoot.SetActive(true);
        isRestarted = true;

        mainMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
        controlsMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
        endScreenDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
}
