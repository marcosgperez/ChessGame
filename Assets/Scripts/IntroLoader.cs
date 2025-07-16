using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLoader : MonoBehaviour {
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneController.Instance.SetSceneFlow(
                new SceneController.SceneType[] {
                    SceneController.SceneType.Intro,
                    SceneController.SceneType.Transition,
                    SceneController.SceneType.Menu,
                }
            );
            SceneController.Instance.LoadNextSceneWithDelay();
        }
    }
}
