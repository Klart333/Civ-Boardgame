using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoadScene : MonoBehaviour
{
    [SerializeField]
    private int sceneIndexToLoad = 0;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
