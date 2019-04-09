using UnityEngine;

//Esse script seta o nome do jogador na tela do passaporte
public class PlayerName : MonoBehaviour {

    public string playerName;

    public void SetName(string newName)
    {
        PlayerPrefs.SetString("PlayerName", newName);
    }
}
