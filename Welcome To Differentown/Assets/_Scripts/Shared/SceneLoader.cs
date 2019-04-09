using UnityEngine;
using UnityEngine.SceneManagement;

//Esse script carrega as cenas no decorrer do jogo
public class SceneLoader : MonoBehaviour {

    public bool loadOnStart;
    public bool isEnding;

    private void Start()
    {
        if(loadOnStart)
        {
            LoadScene(1);
        }

        if(isEnding)
        {
            LoadScene(0);
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
