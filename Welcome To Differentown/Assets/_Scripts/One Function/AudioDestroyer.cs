using UnityEngine;

//Esse script destrói o objeto de áudio na última cena
public class AudioDestroyer : MonoBehaviour {

    public void DestroyAudioObject()
    {
        Destroy(GameObject.FindGameObjectWithTag("SoundManager"));
    }
}
