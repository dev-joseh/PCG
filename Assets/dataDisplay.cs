using UnityEngine;
using TMPro; // Para usar TextMeshPro
using System.IO; // Para leitura de arquivos

public class CSVDisplay : MonoBehaviour
{
    private TextMeshPro displayText;
    public GlobalData globalData;

    void Start()
    {
        displayText = GetComponentInChildren<TextMeshPro>();

        if (globalData != null)
        {
            globalData.LoadCSVContent(); // Carrega o conteúdo do CSV
            displayText.text = globalData.ShowCSVContent(); // Exibe o conteúdo no console
        }
        else
        {
            Debug.LogError("GlobalData não foi atribuído no Inspector.");
        }
    }

    void Update()
    {

    }
}
