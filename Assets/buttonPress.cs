using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject currentBall;
    public classSphere currentSphere;

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f); // Reduz o tamanho
        // Dispara o evento configurado no Inspector
        targetObject.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
        

        if (currentSphere != null) {
            currentSphere.DestroySphere();
            Destroy(currentBall);
        }

        // Create a new GameObject and add the classSphere component
        GameObject sphereObject = new GameObject("SphereObject");
        classSphere sphere = sphereObject.AddComponent<classSphere>();
        

        // Initialize the sphere with label and position
        Vector3 position = transform.position + new Vector3(2, 0, 0); // Position to the side of the button
        sphere.Initialize("AULA MUITO LEGAL", position);

        currentSphere = sphere;
        currentBall = sphereObject;
    }

    private void OnMouseUp()
    {
        transform.localScale = Vector3.one; // Volta ao tamanho original
    }
}