using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/************************************************************************************************************/
 /// <summary>
 ///  A classe Utils contém alguns métodos de uso geral utilizados por classes distintas.
 /// </summary>
/************************************************************************************************************/
public class Utils : MonoBehaviour, InterfaceUtils {
    /// <summary> A instância de Utils. Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados. </summary>
    static Utils instance = null;
    /// <summary> Lista dos objetos rastreados pela PixyCam. </summary>
    public static List<ObjetosRastreados> listaRastreados = new List<ObjetosRastreados>();
    /// <summary> Lista de formas geradas pelo jogo. </summary>
    public static List<GameObject> listaFormas = new List<GameObject>();
    /// <summary> Quantidade atual de formas presentes na tela. </summary>
    public static int quantiaAtual;
    /// <summary> Quantia de pontos do time amarelo. </summary>
    public static int pontosTimeAmarelo;
    /// <summary> Quantia de pontos do time verde. </summary>
    public static int pontosTimeVerde;
    /// <summary> Forma base. </summary>
    public Forma forma;
    /// <summary> Material de base utilizado para alterar a cor das formas conforme elas são criadas. </summary>
    Material material;
    /// <summary> Cores das novas formas. </summary>
    public static Color novaCor;
    /// <summary> Velocidade das formas. Valor obtido através do CSV de configuração. Posição (4) a ser chamada pela função <see cref="LoadCSV(int)"/>. </summary>
    int vel;
    /// <summary> Tamanho das formas. Valor obtido através do CSV de configuração. Posição (6) a ser chamada pela função <see cref="LoadCSV(int)"/>. </summary>
    int tam;

    //==========================================================================================================//
     /// <summary>
     /// Retorna uma instância de Utils.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public static Utils GetInstance() { 
        if(instance == null) {
            return new Utils();
        } else {
            return instance;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// A função LoadCSV(int id) é utilizada para retornar um valor de configuração presente
     /// no CSV de configurações. As configurações do CSV estão ligadas tanto a propriedades da fase
     /// quanto da conexão com o arduino. Ao se escolher a posição referente ao valor de configuração
     /// lembrar-se que o id está sendo decrementado no início da função. Isso é feito para que a
     /// primeira posição relacionada aos valores seja 1. Os valores de configuração estão sempre
     /// dispostos em posições pares exceto 0.
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>
    //==========================================================================================================//
    public string LoadCSV(int id) {
        id--;
        System.IO.StreamReader stream = new System.IO.StreamReader(@"config.txt");
        string line = null;
        string[] separatedLine = null;
        List<string> data = new List<string>();

        while ((line = stream.ReadLine()) != null) {
            separatedLine = line.Split('|');
            foreach (var item in separatedLine) {
                data.Add(item);
            }
        }
        return data[id];
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a quantidade máxima de formas possíveis.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int GetMaximoFormas() {
        return (ToInt(LoadCSV(2)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a velocidade das formas.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int GetVelocidadeFormas() {
        return (ToInt(LoadCSV(4)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho das formas.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int GetTamanhoFormas() {
        return (ToInt(LoadCSV(6)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de formas.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public List<GameObject> GetListaFormas() {
        return listaFormas;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de objetos rastreados.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public List<ObjetosRastreados> GetListaRastreados() {
        return listaRastreados;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a quantidade atual de formas.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int GetQuantiaAtualFormas() {
        return quantiaAtual;
    }

    //==========================================================================================================//
     /// <summary>
     /// A função recebe uma lista de ObjetosRastreados, refente aos objetos rastreados. A lista (listaRastreados) dentro da
     /// classe atual (Utils), armazena todos os blocos rastreados. Essa lista é atualizada com as informações
     /// recebidas por essa função.
     /// </summary>
     /// <param name="dados"></param>
    //==========================================================================================================//
    public void UpdateListaRastreados(List<ObjetosRastreados> dados) {
        listaRastreados = dados;
    }

    //==========================================================================================================//
     /// <summary>
     /// Converte uma string para inteiro.
     /// </summary>
     /// <param name="texto"></param>
     /// <returns></returns>
    //==========================================================================================================//
    public int ToInt(string texto) {
        return System.Int32.Parse(texto);
    }

    //==========================================================================================================//
     /// <summary>
     /// Recebe o nome de uma cena e redireciona a essa cena.
     /// </summary>
     /// <param name="scene"></param>
    //==========================================================================================================//
    public void GoToScene(string scene){
      SceneManager.LoadScene(scene);
    }

    //==========================================================================================================//
     /// <summary>
     /// Cria as formas a serem acertadas pelo jogador.
     /// </summary>
     /// <param name="formaBase"></param>
    //==========================================================================================================//
    public void CriarFormas(GameObject formaBase) {
        GameObject novaForma;
        int quantiaMaxima = GetMaximoFormas();
        quantiaAtual = GetQuantiaAtualFormas();
        vel = GetVelocidadeFormas();
        tam = GetTamanhoFormas();
        if (quantiaAtual < quantiaMaxima) {
            for(int i = 0; i < quantiaMaxima; i++) {
                if(quantiaAtual < quantiaMaxima) {
                    novaCor = new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
                    novaForma = Instantiate(formaBase) as GameObject;
                    novaForma.transform.position = new Vector2(UnityEngine.Random.Range(-7, 7), UnityEngine.Random.Range(-3, 3));
                    novaForma.transform.localScale = new Vector3(tam, tam, tam);
                    material = novaForma.GetComponent<Renderer>().material;
                    material.color = novaCor;
                    AddListaFormas(novaForma);
                    AddQuantiaAtual();
                }
            }
        }
    }


    //==========================================================================================================//
     /// <summary>
     /// Adiciona a Forma recebida na lista de formas.
     /// </summary>
     /// <param name="forma"></param>
    //==========================================================================================================//
    public void AddListaFormas(GameObject forma) {
        listaFormas.Add(forma);
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove a Forma recebida da lista de formas.
     /// </summary>
     /// <param name="forma"></param>
    //==========================================================================================================//
    public void RemoveListaFormas(GameObject forma) {
        listaFormas.Remove(forma);
    }

    //==========================================================================================================//
     /// <summary>
     /// Acrescenta uma unidade da quantia atual de formas.
     /// </summary>
    //==========================================================================================================//
    public void AddQuantiaAtual() {
        if (quantiaAtual < GetMaximoFormas()) {
            quantiaAtual++;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove uma unidade da quantia atual de formas.
     /// </summary>
    //==========================================================================================================//
    public void RemoveQuantiaAtual() { 
        if(quantiaAtual > 0) {
            quantiaAtual--;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o valor passado aos pontos do time amarelo.
     /// </summary>
    //==========================================================================================================//
    public void AddPontosAmarelos(int pontos) {
        pontosTimeAmarelo += pontos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o valor passado aos pontos do time verde.
     /// </summary>
    //==========================================================================================================//
    public void AddPontosVerdes(int pontos) {
        pontosTimeVerde += pontos;
    }

    public Vector3 Viewport(Vector3 posicao, Camera cam) {
        cam = GetComponent<Camera>();
        Vector3 novaPosicao = cam.ViewportToWorldPoint(posicao);
        return novaPosicao;
    }
}
