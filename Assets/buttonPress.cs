using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public GameObject targetObject;

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f); // Reduz o tamanho
        // Dispara o evento configurado no Inspector
        targetObject.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
    }

    private void OnMouseUp()
    {
        transform.localScale = Vector3.one; // Volta ao tamanho original
    }

}
