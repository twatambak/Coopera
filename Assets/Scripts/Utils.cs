using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===================================================================================================
// A classe Utils contém alguns métodos de uso geral utilizados por classes distintas.
//===================================================================================================
public class Utils : MonoBehaviour {

    /* ----------------------------------------------------------------------------------------------
     * void Start()
     * Start() é chamada antes do update do primeiro frame.
     * Utils não possui ligação direta com nenhum GameObject e serve como um repositório de métodos
     * logo, não possui chamada de iniciação no começo do frame.
     --------------------------------------------------------------------------------------------- */
    void Start() {  
    }
    

    /* ----------------------------------------------------------------------------------------------
     * void Update()
     * Update() é chamada no início de cada novo frame.
     * Utils não possui ligação direta com nenhum GameObject e serve como um repositório de métodos
     * logo, não possui chamada de iniciação no começo do frame.
     --------------------------------------------------------------------------------------------- */
    void Update() {   
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
     public int leArquivoConfig(int id) {
        id--;
        System.IO.StreamReader rd = new System.IO.StreamReader(@"config.txt");
        string linha = null;
        string[] linhaSeparada = null;
        List<string> linhas = new List<string>();
        while ((linha = rd.ReadLine()) != null) {
            linhaSeparada = linha.Split('|');
            foreach (var item in linhaSeparada) {
                linhas.Add(item);
            }
        }
        return System.Int32.Parse(linhas[id]);
     }
}
