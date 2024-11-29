using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform handPosition; // Posição onde o objeto será segurado
    public float interactionRange = 3f; // Alcance da interação
    private PickableObject heldObject; // Referência ao objeto atualmente segurado

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Tecla para pegar ou soltar
        {
            if (heldObject != null)
            {
                // Solta o objeto
                heldObject.Drop();
                heldObject.transform.parent = null;
                heldObject = null;
            }
            else
            {
                // Tenta pegar um novo objeto
                TryPickUp();
            }
        }
    }

    private void TryPickUp()
    {
        // Realiza um Raycast para detectar objetos
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange))
        {
            PickableObject pickable = hit.collider.GetComponent<PickableObject>();
            if (pickable != null)
            {
                // Pega o objeto
                pickable.PickUp(handPosition);

                // Calcula a nova posição antes de definir o parent
                float distance = 0.5f; // Ajuste conforme necessário
                Vector3 targetPosition = handPosition.position + handPosition.forward * distance;

                // Posiciona o objeto
                pickable.transform.position = targetPosition;

                // Só depois define o parent
                pickable.transform.parent = handPosition;

                heldObject = pickable;
            }
        }
    }

}
