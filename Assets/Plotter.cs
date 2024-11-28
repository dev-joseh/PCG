using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Para ler arquivos
using TMPro; // Para exibir texto com TextMeshPro
using System.Globalization; // Para garantir que o ponto seja usado como separador decimal
using System.Linq;


public class Plotter : MonoBehaviour
{
    public GameObject spherePrefab; // O prefab da esfera
    public float scale;
    public string csvFilePath = "Assets/data.csv"; // Caminho do arquivo CSV

    void Start()
    {
        LoadCSVAndPlot();
    }

    void LoadCSVAndPlot()
    {
        // Verifica se o arquivo CSV existe
        if (!File.Exists(csvFilePath))
        {
            Debug.LogError("Arquivo CSV não encontrado: " + csvFilePath);
            return;
        }

        // Lê todas as linhas do CSV
        string[] lines = File.ReadAllLines(csvFilePath);

        // Inicializar os arrays com o tamanho correto
        float[] xList = new float[lines.Length - 1];
        float[] yList = new float[lines.Length - 1];
        float[] zList = new float[lines.Length - 1];

        for (int i = 1; i < lines.Length; i++) // Começar em 1 para pular o cabeçalho
        {
            string[] data = lines[i].Split(',');

            // Tentar converter os valores para float
            bool parseX = float.TryParse(data[1], NumberStyles.Float, CultureInfo.InvariantCulture, out xList[i - 1]);
            bool parseY = float.TryParse(data[2], NumberStyles.Float, CultureInfo.InvariantCulture, out yList[i - 1]);
            bool parseZ = float.TryParse(data[3], NumberStyles.Float, CultureInfo.InvariantCulture, out zList[i - 1]);
        }

        // Encontra os valores máximos para normalizar o gráfico
        float scaleX = scale / xList.Max();
        float scaleY = scale / yList.Max();
        float scaleZ = scale / zList.Max();


        // Ignora a primeira linha (cabeçalho)
        for (int i = 1; i < lines.Length; i++)
        {
            // Instancia a esfera na posição correta na escala adequada
            Vector3 position = new Vector3(xList[i] * scaleX, yList[i] * scaleY, zList[i] * scaleZ);
            GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);

            // Adiciona uma etiqueta de texto para mostrar a classe do item
            GameObject textObject = new GameObject("Label"); // Cria um GameObject para o texto
            textObject.transform.position = position + new Vector3(9.7f,-2f,0); // Define a posição do texto

            // Adiciona o componente TextMeshPro ao GameObject
            TextMeshPro textMesh = textObject.AddComponent<TextMeshPro>();
            
            textMesh.text = $"{xList[i]}|{yList[i]}|{zList[i]}"; // Define o texto como a classe do item
            textMesh.fontSize = 1; // Ajuste o tamanho da fonte
            textMesh.color = Color.black; // Defina a cor da fonte

            // Faz o texto se mover junto com a esfera
            textObject.transform.SetParent(sphere.transform);
        }
    }
}
