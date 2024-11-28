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

        // Create a new GameObject and add the classSphere component
        GameObject sphereObject = new GameObject("SphereObject");
        classSphere sphere = sphereObject.AddComponent<classSphere>();

        // Initialize the sphere with label and position
        Vector3 position = transform.position + new Vector3(2, 0, 0); // Position to the side of the button
        sphere.Initialize("AULA MUITO LEGAL", position);
    }

    private void OnMouseUp()
    {
        transform.localScale = Vector3.one; // Volta ao tamanho original
    }
}