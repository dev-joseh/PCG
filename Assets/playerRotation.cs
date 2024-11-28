using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRotation : MonoBehaviour
{
    public float sensibilidade;
    private float x;
    private float y;
    private Vector3 rotateValue;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RotacionarJogador();
        // MoveJogador();
    }

    private void RotacionarJogador() 
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(x * sensibilidade, y * -sensibilidade, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
    }
}
