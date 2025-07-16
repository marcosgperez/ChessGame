using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
    public enum SceneType
    {
        Intro,
        Transition,
        Menu,
        LevelSelect,
        Battle
    }

    private static SceneController instance;
    private Dictionary<SceneType, string> sceneMap;
    public SceneType currentSceneType;
    private SceneType nextSceneType;
    public float transitionDelay = 2f;

    public void SetNextSceneType(SceneType nextScene)
    {
        nextSceneType = nextScene;
    }

    public static SceneController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneController>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("SceneController");
                    instance = obj.AddComponent<SceneController>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSceneMap();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeSceneMap()
    {
        sceneMap = new Dictionary<SceneType, string>();
        sceneMap[SceneType.Intro] = "IntroScene";
        sceneMap[SceneType.Transition] = "TransitionScene";
        sceneMap[SceneType.Menu] = "MenuScene";
        sceneMap[SceneType.LevelSelect] = "LevelSelectScene";
        sceneMap[SceneType.Battle] = "BattleScene";
    }

    public void SetSceneFlow(SceneType[] flow)
    {
        if (flow.Length == 0) return;
        currentSceneType = flow[0];
        nextSceneType = flow.Length > 1 ? flow[1] : SceneType.Menu;
    }

    public void LoadNextScene()
    {
        if (sceneMap.TryGetValue(nextSceneType, out string sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void LoadNextSceneWithDelay()
    {
        StartCoroutine(DelayedLoad());
    }

    IEnumerator DelayedLoad()
    {
        yield return new WaitForSeconds(transitionDelay);
        LoadNextScene();
    }

    public void UpdateSceneFlow()
    {
        currentSceneType = nextSceneType;
    }
}
