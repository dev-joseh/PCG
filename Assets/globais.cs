using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "GlobalData", menuName = "GlobalData")]
public class GlobalData : ScriptableObject
{
    public int[] cadeirasAtivas;
    public string[] data;
    public string fileName;
    private string[,] csvMatrix; // Matriz para armazenar o conteúdo do CSV

    /// <summary>
    /// Lê o conteúdo do CSV e armazena em uma matriz de strings.
    /// </summary>
    public void LoadCSVContent()
    {
        string filePath = $"Assets/{fileName}";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            int rows = lines.Length;
            int columns = lines[0].Split(',').Length;

            // Inicializa a matriz com o tamanho apropriado
            csvMatrix = new string[rows, columns];

            // Preenche a matriz com os valores do CSV
            for (int i = 0; i < rows; i++)
            {
                string[] data = lines[i].Split(',');
                for (int j = 0; j < columns; j++)
                {
                    csvMatrix[i, j] = data[j];
                }
            }

            Debug.Log("Arquivo CSV carregado com sucesso!");
        }
        else
        {
            Debug.LogError($"Arquivo {fileName} não encontrado em: {filePath}");
        }
    }

    /// <summary>
    /// Exibe o conteúdo do CSV armazenado na matriz.
    /// </summary>
    public string ShowCSVContent()
    {
        if (csvMatrix == null)
        {
            Debug.LogWarning("O conteúdo do CSV ainda não foi carregado. Certifique-se de chamar LoadCSVContent() primeiro.");
        }

        string content = "";

        for (int i = 0; i < csvMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < csvMatrix.GetLength(1); j++)
            {
                if (i == 0)
                    content += $"<b>{csvMatrix[i, j]}</b>     "; // Cabeçalho em negrito
                else
                    content += $"{csvMatrix[i, j] ?? "\t\t\t"}     "; // Adiciona tabulação e trata valores nulos
            }
            content += "\n"; // Quebra de linha ao final de cada linha
        }
        return content;
    }
}

