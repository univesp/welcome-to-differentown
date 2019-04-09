using UnityEngine;

public class EndLevelGetter : MonoBehaviour {

    public GameObjectController endLevel;
    public int minigameDone;
    public int maxMinigameDone;

    private void Start()
    {
        endLevel = GameObject.FindGameObjectWithTag("MainMap").GetComponent< GameObjectController>();
    }

    public void EnableObject()
    {
        minigameDone++;
        AudioPlayerController.instance.PlaySFX_Fim();
        if (minigameDone == maxMinigameDone)
        {
            endLevel.SetActive();
        }
    }

    public void DestroyObject()
    {
        Destroy(endLevel);
    }
}