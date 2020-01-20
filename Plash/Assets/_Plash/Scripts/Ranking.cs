using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    /// <summary>
    /// Lista que armazena as pontuações
    /// </summary>
    public static List<int> scores = new List<int>();

    /// <summary>
    /// Texto para exibir a pontuação
    /// </summary>
    public Text[] rank;

    private void Update()
    {
        rank[0].text = PlayerPrefs.GetInt("1", 0).ToString();
        rank[1].text = PlayerPrefs.GetInt("2", 0).ToString();
        rank[2].text = PlayerPrefs.GetInt("3", 0).ToString();
    }

    /// <summary>
    /// Adiciona um novo valor a lista de pontuações
    /// </summary>
    /// <param name="value"></param>
    public static void UpdadeRank(int value)
    {
        scores = SetDefault();
        scores.Add(value);
        Save();
    }

    /// <summary>
    /// Set os valores salvos no PC do usuário na lista
    /// </summary>
    public static List<int> SetDefault()
    {
        var aux = new List<int>();

        aux.Add(PlayerPrefs.GetInt("1", 0));
        aux.Add(PlayerPrefs.GetInt("2", 0));
        aux.Add(PlayerPrefs.GetInt("2", 0));

        return aux;
    }

    /// <summary>
    /// Salva os valores na máquina do usuário
    /// </summary>
    public static void Save()
    {
        var aux = GetRanking();

        for (var i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt((i + 1).ToString(), aux[i]);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Ordena a lista de forma decrescente
    /// </summary>
    /// <returns>Retorna a lista de maneira ordenada</returns>
    private static List<int> GetRanking()
    {
        return scores.OrderByDescending(x => x).ToList();
    }
}
