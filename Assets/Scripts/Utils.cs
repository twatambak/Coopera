using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//===================================================================================================
// A classe Utils contém alguns métodos de uso geral utilizados por classes distintas.
//===================================================================================================
public class Utils : MonoBehaviour {

    List<TrackedBlocks> arduinoData = new List<TrackedBlocks>();

    /* ----------------------------------------------------------------------------------------------
     * Construtor
     --------------------------------------------------------------------------------------------- */
    public Utils() {}

    /* ----------------------------------------------------------------------------------------------
     * public int leArquivoConfig(int id)
     * A função leArquivoConfig(int id) é utilizada para retornar um valor de configuração presente
     * no CSV de configurações. As configurações do CSV estão ligadas tanto a propriedades da fase
     * quanto da conexão com o arduino. Ao se escolher a posição referente ao valor de configuração
     * lembrar-se que o id está sendo decrementado no início da função. Isso é feito para que a
     * primeira posição relacionada aos valores seja 1. Os valores de configuração estão sempre
     * dispostos em posições pares exceto 0.
     --------------------------------------------------------------------------------------------- */
     public string leArquivoConfig(int id) {
        id--;
        System.IO.StreamReader stream = new System.IO.StreamReader(@"config.txt");
        string linha = null;
        string[] linhaSeparada = null;
        List<string> dados = new List<string>();

        while ((linha = stream.ReadLine()) != null) {
            linhaSeparada = linha.Split('|');
            foreach (var item in linhaSeparada) {
                dados.Add(item);
            }
        }
        return dados[id];
     }


    /* ----------------------------------------------------------------------------------------------
     * public int leArquivoConfig(int id)
     * A função leArquivoConfig(int id) é utilizada para retornar um valor de configuração presente
     * no CSV de configurações. As configurações do CSV estão ligadas tanto a propriedades da fase
     * quanto da conexão com o arduino. Ao se escolher a posição referente ao valor de configuração
     * lembrar-se que o id está sendo decrementado no início da função. Isso é feito para que a
     * primeira posição relacionada aos valores seja 1. Os valores de configuração estão sempre
     * dispostos em posições pares exceto 0.
     --------------------------------------------------------------------------------------------- */
    public int toInt(string texto) {
        return System.Int32.Parse(texto);
    }

    public void goToScene(string scene){
      SceneManager.LoadScene(scene);
    }
}
