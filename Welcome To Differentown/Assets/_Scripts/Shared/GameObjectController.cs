using UnityEngine;

//Esse script é chamado dentro de animações quando precisa ativar ou desativar objetos no meio da animação
public class GameObjectController : MonoBehaviour {

	public GameObject gameObject;
    public GameObject map;
    public GameObject end;

    public bool isMap;
    public bool isEnd;

    public void SetActive()
    {
        gameObject.SetActive(true);
    }

    public void SetInactive()
    {
        if(isMap)
        {
            map.SetActive(false);
        }
        if(isEnd)
        {
            end.SetActive(true);
            gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
