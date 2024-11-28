using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public float altura;
    public GameObject MyCamera;
     
    // Start is called before the first frame update
    void Start()
    {
        MyCamera.transform.position = new Vector3(0f,altura,0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveJogador();
    }

    private void MoveJogador() 
    {
        // Calcula o movimento com base na entrada do jogador
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Pega a direção no plano XZ relativa à câmera
        Vector3 forward = MyCamera.transform.forward; // Direção "frontal" da câmera
        Vector3 right = MyCamera.transform.right;    // Direção "lateral" da câmera

        // Elimina qualquer componente vertical das direções
        forward.y = 0;
        right.y = 0;

        // Normaliza as direções para evitar alterações na velocidade
        forward.Normalize();
        right.Normalize();

        // Calcula a direção final do movimento
        Vector3 moveDirection = (forward * moveVertical) + (right * moveHorizontal);

        // Aplica o movimento ao objeto
        MyCamera.transform.position += moveDirection;
    }
}
