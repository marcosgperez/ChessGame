using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    private void Start()
    {
        SceneController sceneController = SceneController.Instance;
        sceneController.UpdateSceneFlow();
        SceneController.SceneType[] sceneTypes = System.Enum.GetValues(typeof(SceneController.SceneType)) as SceneController.SceneType[];
        int currentIndex = System.Array.IndexOf(sceneTypes, sceneController.currentSceneType);
        if (currentIndex >= 0 && currentIndex < sceneTypes.Length - 1)
        {
            sceneController.SetNextSceneType(sceneTypes[currentIndex + 1]);
        }
        else
        {
            sceneController.SetNextSceneType(SceneController.SceneType.Menu);
        }
        sceneController.LoadNextSceneWithDelay();
    }
}