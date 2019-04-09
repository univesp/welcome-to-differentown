using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    public int minigameQtd;
    public  int minigameDone;

    public GameObject map;

    public UnityEvent actions;

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "2 - Hotel")
        {
            minigameDone = 0;
        }
        AddMinigameDone();        
    }


    private void OnDisable()
    {
        map.SetActive(false);
    }

    public void AddMinigameDone()
    {
        minigameDone++;

        if(minigameDone == minigameQtd)
        {
            actions.Invoke();   
            //Chama a cena de final
        }
        else
        {
            map.SetActive(true);            
        }
    }        
}
