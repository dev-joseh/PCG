using UnityEngine;

public class PickableObject : MonoBehaviour
{
    private bool isHeld = false; // Verifica se o objeto está sendo segurado
    private Transform playerHand; // Posição onde o objeto será "segurado"
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("O objeto precisa de um Rigidbody para ser pegável.");
        }
    }

    void Update()
    {
        if (isHeld && playerHand != null)
        {
            // Atualiza a posição do objeto para seguir a mão do jogador
            transform.position = playerHand.position;
            transform.rotation = playerHand.rotation;
        }
    }

    public void PickUp(Transform hand)
    {
        isHeld = true;
        playerHand = hand;

        if (rb != null)
        {
            rb.isKinematic = true; // Desativa física enquanto está sendo segurado
        }

        Debug.Log($"{gameObject.name} foi pego.");
    }

    public void Drop()
    {
        isHeld = false;
        playerHand = null;

        if (rb != null)
        {
            rb.isKinematic = false; // Reativa a física ao soltar
        }

        Debug.Log($"{gameObject.name} foi solto.");
    }
}
