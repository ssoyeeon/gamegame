using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public List<SceneData> sceneDatas;
    private void LoadScene(string sceneName, int sceneIndex = 0)
    {

    }
}

[System.Serializable]
public class SceneData
{
    public string sceneName;
    public int sceneIndex;
}
