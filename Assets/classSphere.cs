using UnityEngine;

public class classSphere : MonoBehaviour
{
    public string labelText;
    public Vector3 position;

    // Method to initialize the sphere with label and position
    public void Initialize(string labelText, Vector3 position)
    {
        this.labelText = labelText;
        this.position = position;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateSphere();
    }

    // Method to create the sphere and add a text label
    private void CreateSphere()
    {
        // Create the sphere
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;

        // Create a new GameObject for the text label
        GameObject textObject = new GameObject("TextLabel");
        textObject.transform.position = position + new Vector3(0, 1.5f, 0); // Position the label above the sphere

        // Add a TextMesh component to the textObject
        TextMesh textMesh = textObject.AddComponent<TextMesh>();
        textMesh.text = labelText;
        textMesh.characterSize = 0.25f;
        textMesh.anchor = TextAnchor.MiddleCenter;

        // Make the textObject a child of the sphere
        textObject.transform.parent = sphere.transform;

        // Ensure the text label faces the camera
        textObject.transform.rotation = Camera.main.transform.rotation;
    }
}