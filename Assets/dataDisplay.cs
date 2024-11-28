using UnityEngine;
using TMPro; // Para usar TextMeshPro
using System.IO; // Para leitura de arquivos

public class CSVDisplay : MonoBehaviour
{
    private TextMeshPro displayText; // Referência automática ao componente filho
    public string fileName = "output.csv"; // Nome do arquivo CSV

    // Esta função será chamada quando o botão 3D enviar a mensagem
    public void Activate()
    {
        ShowCSVContent();
    }

    void Start()
    {
        // Procura o componente TextMeshPro no objeto filho
        displayText = GetComponentInChildren<TextMeshPro>();

        if (displayText == null)
        {
            Debug.LogError("TextMeshPro não encontrado como filho do DisplayObject!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ShowCSVContent();
        }
    }

    void ShowCSVContent()
    {
        string filePath = $"Assets/{fileName}";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            string content = "";

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                for (int j = 0; j < data.Length; j++)
                {
                    if (i == 0)
                        content += $"<b>{data[j]}</b>     "; // Cabeçalho em negrito
                    else
                        content += $"{data[j] ?? "\t\t\t"}     ";  // Adiciona tabulação e trata valores nulos
                }
                content += "\n"; // Quebra de linha ao final de cada linha
            }

            displayText.text = content;
            Debug.Log("Conteúdo do arquivo exibido.");
        }
        else
        {
            Debug.LogError($"Arquivo {fileName} não encontrado em: {filePath}");
            displayText.text = "Arquivo não encontrado.";
        }
    }
}
