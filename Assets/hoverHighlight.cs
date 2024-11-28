using UnityEngine;

public class ButtonHoverEffect : MonoBehaviour
{
    private Renderer buttonRenderer;
    private Color originalColor;
    public Color hoverColor = Color.yellow;

    private void Start()
    {
        // Obtém o Renderer para alterar a cor do material
        buttonRenderer = GetComponent<Renderer>();
        originalColor = buttonRenderer.material.color; // Salva a cor original
    }

    private void OnMouseEnter()
    {
        // Altera para a cor de "hover"
        buttonRenderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        // Restaura a cor original quando o mouse sai do botão
        buttonRenderer.material.color = originalColor;
    }
}
