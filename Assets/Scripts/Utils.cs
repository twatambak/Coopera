using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

/************************************************************************************************************/
 /// <summary>
 ///  A classe Utils contém alguns métodos de uso geral utilizados por classes distintas. A Utils implementa
 ///  a interface de base das funções usadas para o Singleton;
 /// </summary>
/************************************************************************************************************/
public class Utils : MonoBehaviour, InterfaceUtils {

    /// <summary> A instância de Utils (Singleton). Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados. </summary>
    static Utils instance = null;

    /// <summary> Valor de CSV. Velocidade das alvos. Valor obtido através do CSV de configuração. Posição (4) a ser chamada pela função <see cref="LoadCSV(int)"/>. </summary>
    int CSV_Vel;

    /// <summary> Valor de CSV. Tamanho das alvos. Valor obtido através do CSV de configuração. Posição (6) a ser chamada pela função <see cref="LoadCSV(int)"/>. </summary>
    int CSV_Tam;

    /// <summary> Valor de CSV. Cores dos novos alvos. Valor obtido através do CSV de configuração. Posição (8) a ser chamada pela função <see cref="LoadCSV(int)"/>. </summary>
    int CSV_AssAmarelo;

    /// <summary> Valor de CSV. Cores dos novos alvos. Valor obtido através do CSV de configuração. Posição (10) a ser chamada pela função <see cref="LoadCSV(int)"/>. </summary>
    int CSV_AssVerde;

    /// <summary> Lista de alvos geradas pelo jogo. </summary>
    public static List<GameObject> listaAlvos = new List<GameObject>();

    /// <summary> Lista de alvos geradas pelo jogo. </summary>
    public static List<GameObject> listaDistracoes = new List<GameObject>();

    /// <summary> Quantidade atual de alvos presentes na tela. </summary>
    public static int qtdAlvos;

    /// <summary> Quantidade atual de alvos presentes na tela. </summary>
    public static int qtdDistracoes;

    /// <summary> Quantia de pontos do time amarelo. </summary>
    public static int pontosTimeAmarelo;

    /// <summary> Quantia de pontos do time verde. </summary>
    public static int pontosTimeVerde;

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
     /// A função é utilizada para retornar um valor de configuração presente no CSV de configurações. As 
     /// configurações do CSV estão ligadas tanto a propriedades da fase quanto da conexão com o arduino. Ao se 
     /// escolher a posição referente ao valor de configuração lembre que o id está sendo decrementado no início 
     /// da função. Isso é feito para que a primeira posição relacionada aos valores seja 1. Os valores de 
     /// configuração estão sempre dispostos em posições pares exceto 0.
     /// </summary>
     /// <param name="id"> O ID da informação a ser recuperada no CSV. </param>
     /// <returns> O valor de configuração obtido de retorno no CSV. </returns>
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
    //==========================================================================================================//
    public int CSV_GetTempoJogo() {
        return (ToInt(LoadCSV(2)));
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public string CSV_GetTipoAlvos() {
        return LoadCSV(4);
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public int CSV_GetMaximoAlvos() {
        return (ToInt(LoadCSV(6)));
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public int CSV_GetVelocidadeAlvos() {
        return (ToInt(LoadCSV(8)));
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public int CSV_GetTamanhoAlvos() {
        return (ToInt(LoadCSV(10)));
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public int CSV_GetMaximoDistracoes() {
        return (ToInt(LoadCSV(12)));
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public int CSV_GetVelocidadeDistracoes() {
        return (ToInt(LoadCSV(14)));
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public int CSV_GetTamanhoDistracoes() {
        return (ToInt(LoadCSV(16)));
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public string CSV_GetPortaArduino() {
        return LoadCSV(18);
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public string CSV_GetMetodoReconhecimento() {
        return LoadCSV(20);
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public int CSV_GetAssinaturaAmarela() {
        return (ToInt(LoadCSV(22)));
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public int CSV_GetAssinaturaVerde() {
        return (ToInt(LoadCSV(24)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de alvos.
     /// </summary>
     /// <returns> A lista de alvos armazenados. </returns>
    //==========================================================================================================//
    public List<GameObject> GetListaAlvos() {
        return listaAlvos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho da lista de alvos.
     /// </summary>
     /// <returns> O tamanho da lista de alvos. </returns>
    //==========================================================================================================//
    public int GetTamanhoListaAlvos() {
        return listaAlvos.Count;
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o alvo passado na lista de alvos. A adição à quantidade de alvos já é realizada.
     /// </summary>
     /// <param name="alvo"> O GameObject a ser adicionado na lista de alvos. </param>
    //==========================================================================================================//
    public void AddAlvo(GameObject alvo) {
        if(GetTamanhoListaAlvos() < CSV_GetMaximoAlvos() & GetQuantidadeAlvos() < CSV_GetMaximoAlvos()) {
            listaAlvos.Add(alvo);
            AddQuantidadeAlvos();
        }
    }

    //==========================================================================================================//
    /// <summary>
    /// Remove o alvo recebido da lista de alvos. A subtração da quantidade de alvos já é realizada.
    /// </summary>
    /// <param name="alvo"> O GameObejct a ser removido da lista de alvos. </param>
    //==========================================================================================================//
    public void RemoveAlvo(GameObject alvo) {
        if(GetTamanhoListaAlvos() > 0 & GetQuantidadeAlvos() > 0) {
            listaAlvos.Remove(alvo);
            qtdAlvos--;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Limpa os alvos da tela.
     /// </summary>
    //==========================================================================================================//
    public void LimparAlvos() {
        for (int i = GetTamanhoListaAlvos() - 1; i >= 0; i--) {
            listaAlvos[i].GetComponent<Alvo>().Destroi();
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a quantidade atual de alvos.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int GetQuantidadeAlvos() {
        return qtdAlvos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Aumenta em 1 a quantidade de alvos.
     /// </summary>
    //==========================================================================================================//
    public void AddQuantidadeAlvos() {
        if(GetQuantidadeAlvos() < CSV_GetMaximoAlvos()) {
            qtdAlvos++;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Subtrai em 1 a quantidade de alvos.
     /// </summary>
    //==========================================================================================================//
    public void RemoveQuantidadeAlvos() { 
        if(GetQuantidadeAlvos() > 0) {
            qtdAlvos--;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de distrações.
     /// </summary>
     /// <returns> A lista de distrações armazenadas. </returns>
    //==========================================================================================================//
    public List<GameObject> GetListaDistracoes() {
        return listaDistracoes;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho da lista de distrações.
     /// </summary>
     /// <returns> O tamanho da lista de distrações. </returns>
    //==========================================================================================================//
    public int GetTamanhoListaDistracoes() {
        return listaDistracoes.Count;
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona a distração passada na lista de distrações. A adição à quantidade de distrações já é realizada.
     /// </summary>
     /// <param name="distracao"> O GameObject a ser adicionado na lista de distrações. </param>
    //==========================================================================================================//
    public void AddDistracao(GameObject distracao) {
        if(GetTamanhoListaDistracoes() < CSV_GetMaximoDistracoes() & GetQuantidadeDistracoes() < CSV_GetMaximoDistracoes()) {
            listaDistracoes.Add(distracao);
            AddQuantidadeDistracoes();
        }
    }

    //==========================================================================================================//
    /// <summary>
    /// Remove a distração recebida da lista de distrações. A subtração da quantidade de distrações já é realizada.
    /// </summary>
    /// <param name="distracao"> O GameObejct a ser removido da lista de distrações. </param>
    //==========================================================================================================//
    public void RemoveDistracao(GameObject distracao) {
        if(GetTamanhoListaDistracoes() > 0 & GetQuantidadeDistracoes() > 0) {
            listaDistracoes.Remove(distracao);
            qtdDistracoes--;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Limpa as distrações da tela.
     /// </summary>
    //==========================================================================================================//
    public void LimparDistracoes() {
        for (int i = GetTamanhoListaDistracoes() - 1; i >= 0; i--) {
            listaDistracoes[i].GetComponent<Distracao>().Destroi();
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a quantidade atual de distrações.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int GetQuantidadeDistracoes() {
        return qtdDistracoes;
    }

    //==========================================================================================================//
     /// <summary>
     /// Aumenta em 1 a quantidade de distrações.
     /// </summary>
    //==========================================================================================================//
    public void AddQuantidadeDistracoes() {
        if(GetQuantidadeDistracoes() < CSV_GetMaximoDistracoes()) {
            qtdDistracoes++;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Subtrai em 1 a quantidade de distrações.
     /// </summary>
    //==========================================================================================================//
    public void RemoveQuantidadeDistracoes() { 
        if(GetQuantidadeDistracoes() > 0) {
            qtdDistracoes--;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna os pontos amarelos.
     /// </summary>
     /// <returns> Os pontos do time amarelo. </returns>
    //==========================================================================================================//
    public int GetPontosAmarelos() {
        return pontosTimeAmarelo;
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o valor passado aos pontos do time amarelo.
     /// </summary>
     /// <param name="pontos"> Valor a ser adicionado aos pontos do time amarelo. </param>
    //==========================================================================================================//
    public void AddPontosAmarelos(int pontos) {
        pontosTimeAmarelo += pontos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retornas os pontos verdes.
     /// </summary>
     /// <returns> Os pontos do time verde, </returns>
    //==========================================================================================================//
    public int GetPontosVerdes() {
        return pontosTimeVerde;
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o valor passado aos pontos do time verde.
     /// </summary>
     /// <param name="pontos"> Valor a ser adicionado aos pontos do time verde. </param>
    //==========================================================================================================//
    public void AddPontosVerdes(int pontos) {
        pontosTimeVerde += pontos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Zera os pontos.
     /// </summary>
    //==========================================================================================================//
    public void ZerarPontos() {
        pontosTimeAmarelo = 0;
        pontosTimeVerde = 0;
    }

    //==========================================================================================================//
     /// <summary>
     /// Converte uma string para int.
     /// </summary>
     /// <param name="texto"> O texto a ser convertido. </param>
     /// <returns> O resultado da conversão do texto. </returns>
    //==========================================================================================================//
    public int ToInt(string texto) {
        return System.Int32.Parse(texto);
    }

    //==========================================================================================================//
     /// <summary>
     /// Recebe o nome de uma cena e redireciona a essa cena.
     /// </summary>
     /// <param name="scene"> O nome da cena a qual se deseja ir. </param>
    //==========================================================================================================//
    public void GoToScene(string scene) {
      SceneManager.LoadScene(scene);
    }
}
