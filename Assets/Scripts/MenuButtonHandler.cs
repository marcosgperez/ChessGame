using UnityEngine;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("MenuButtonHandler initialized");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneController.Instance.SetSceneFlow(new SceneController.SceneType[]
        {
            SceneController.SceneType.LevelSelect,
            SceneController.SceneType.Transition,
            SceneController.SceneType.Battle
        });
        Debug.Log("Scene flow set: Menu -> Transition -> LevelSelect");
        SceneController.Instance.LoadNextSceneWithDelay();
        Debug.Log("LoadNextSceneWithDelay called");
        }
    }

    public void OnStartButtonClicked()
    {
        Debug.Log("Start button clicked");
        SceneController.Instance.SetSceneFlow(new SceneController.SceneType[]
        {
            SceneController.SceneType.LevelSelect,
            SceneController.SceneType.Transition,
            SceneController.SceneType.Battle
        });
        Debug.Log("Scene flow set: Menu -> Transition -> LevelSelect");
        SceneController.Instance.LoadNextSceneWithDelay();
        Debug.Log("LoadNextSceneWithDelay called");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}