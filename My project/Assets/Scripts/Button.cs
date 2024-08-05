using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public List<string> Scene = new List<string>();

    public void OnButton(int num)
    {
        //SceneManager.LoadScene(Scene[num]);
    }
}
