using UnityEngine;

public class Destroyer : MonoBehaviour {
	
    //Esse script serve para deletar o objeto do mapa quando o jogo reinicia
	void Start () {
        Destroy(GameObject.FindGameObjectWithTag("MainMap"));
	}	
}
