using System.Collections;
using UnityEngine;

public class DialogueSounds : MonoBehaviour {

    public float delayTime;    

    private void Start()
    {
        StartCoroutine(PlayWithDelay(delayTime));
    }

    private void OnEnable()
    {
        StartCoroutine(PlayWithDelay(delayTime));
    }    

    private IEnumerator PlayWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioPlayerController.instance.PlaySFX_FalaSurgindo();
    }
}
