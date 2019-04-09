using UnityEngine;

public class CarSoundPlayer : MonoBehaviour {

	public void PlayCarSound()
    {
        AudioPlayerController.instance.PlaySFX_Carro();
    }
}
