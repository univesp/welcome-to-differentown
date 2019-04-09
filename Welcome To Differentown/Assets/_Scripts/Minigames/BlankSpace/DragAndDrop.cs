using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    private bool isDragging;
    public Camera main; //Nunca usar Camera.main, essa função consome mais memória para ser executada. É melhor referenciar a câmera direto no inspector

    private void Update()
    {
        //Se o jogador clicar no objeto contendo esse script e manter o botão pressionado, o objeto vai seguir as coordenadas do mouse
        if(isDragging)
        {
            transform.position = new Vector3(main.ScreenToWorldPoint(Input.mousePosition).x, main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
