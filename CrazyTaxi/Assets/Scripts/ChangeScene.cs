using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
  public string SceneName;

    public void ChangeScenes()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Quit()
    {
        Debug.Log("Cierra");
        Application.Quit();
    }
}
