using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    /// <summary> Lista de GameObjects criados a partir dos objetos rastreados pela PixyCam. Armazena os objetos que são utilizados para a criação dos GameObjects para a análise de colisão. </summary>
    public static List<GameObject> listaIdentificadores = new List<GameObject>();

    /// <summary> Lista de alvos geradas pelo jogo. </summary>
    public static List<GameObject> listaAlvos = new List<GameObject>();

    /// <summary> Quantidade atual de alvos presentes na tela. </summary>
    public static int qtdAlvos;

    /// <summary> Quantia de pontos do time amarelo. </summary>
    public static int pontosTimeAmarelo;

    /// <summary> Quantia de pontos do time verde. </summary>
    public static int pontosTimeVerde;

    /// <summary> Cores dos novos alvos. </summary>
    public static Color novaCor;

    /// <summary> Material de base utilizado para alterar a cor das alvos conforme elas são criadas. </summary>
    Material material;

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
     /// <summary>
     /// Retorna a quantidade máxima de alvos possíveis. Essa informação está disponível na posição 1 (com o vetor
     /// iniciando em 0) do arquivo CSV. Como decrementamos um valor na função de leitura do CSV passamos o ID 2. 
     /// </summary>
     /// <returns> A quantidade máxima possível para os alvos. </returns>
    //==========================================================================================================//
    public int CSV_GetMaximoAlvos() {
        return (ToInt(LoadCSV(2)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a velocidade dos alvos. Essa informação está disponível na posição 3 (com o vetor iniciando em 0)
     /// do arquivo CSV. Como decrementamos um valor na função de leitura do CSV passamos o ID 4. 
     /// </summary>
     /// <returns> A velocidade de movimento dos alvos. </returns>
    //==========================================================================================================//
    public int CSV_GetVelocidadeAlvos() {
        return (ToInt(LoadCSV(4)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho dos alvos. Essa informação está disponível na posição 5 (com o vetor iniciando em 0)
     /// do arquivo CSV. Como decrementamos um valor na função de leitura do CSV passamos o ID 6. 
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    public int CSV_GetTamanhoAlvos() {
        return (ToInt(LoadCSV(6)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o valor de assinatura que representa a cor amarela (ou cor do time 1) da Pixy. Essa informação 
     /// está disponível na posição 7 (com o vetor iniciando em 0) do arquivo CSV.  Como decrementamos um valor
     /// na função de leitura do CSV passamos o ID 8.
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    public int CSV_GetAssinaturaAmarela() {
        return (ToInt(LoadCSV(8)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o valor de assinatura que representa a cor amarela (ou cor do time 1) da Pixy. Essa informação 
     /// está disponível na posição 9 (com o vetor iniciando em 0) do arquivo CSV.  Como decrementamos um valor
     /// na função de leitura do CSV passamos o ID 10.
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    public int CSV_GetAssinaturaVerde() {
        return (ToInt(LoadCSV(10)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de GameObjects criados a partir dos objetos rastreados pela Pixy. Os elementos dessa
     /// lista servem de base para analisar se bola acertou o alvo.
     /// </summary>
     /// <returns> A lista de GameObjects de identificação de posição da bola rastreada pela Pixy. </returns>
    //==========================================================================================================//
    public List<GameObject> GetListaIdentificadores() {
        return listaIdentificadores;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho da lista de identificadores.
     /// </summary>
     /// <returns> O tamanho da lista de identificadores. </returns>
    //==========================================================================================================//
    public int GetTamanhoListaIdentificadores() {
        return listaIdentificadores.Count;
    }

    //==========================================================================================================//
    /// <summary>
    /// Adiciona o GameObject passado na lista de identificadores dos objetos rastreados pela Pixy.
    /// </summary>
    /// <param name="identificador"> O GameObject a ser adicionado na lista de identificadores. </param>
    //==========================================================================================================//
    public bool AddIdentificador(GameObject identificador) {
        List<GameObject> identificadores = GetListaIdentificadores();
        for (int i = 0; i < identificadores.Count; i++) { 
            if (identificadores[i].GetComponent<Identificador>().GetID() == identificador.GetComponent<Identificador>().GetID()) {
                listaIdentificadores[i] = identificador;
                return true;
            }
        }
        listaIdentificadores.Add(identificador);
        return false;
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove o GameObject passado da lista de identificadores dos objetos rastreados pela Pixy.
     /// </summary>
     /// <param name="identificador"> O GameObject a ser removido na lista de identificadores. </param>
    //==========================================================================================================//
    public void RemoveIdentificador(GameObject identificador) {
        listaIdentificadores.Remove(identificador);
        Destroy(identificador);
    }

    //==========================================================================================================//
     /// <summary>
     /// Cria um novo identificador com base nos dados coletados dos objetos rastreados pela Pixy. Todas as
     /// informações do objeto rastreado são aplicadas em dados correspondentes em um script aplicado no
     /// GameObject base dos identificadores. Essas informações são posteriormente acessadas utilizando os Gets()
     /// específicos através do GetComponent() para o identificador.
     /// </summary>
     /// <param name="baseIdenti"> O GameObject base usado para a criação dos identificadores. </param>
     /// <param name="id"> O ID do objeto rastreado pela Pixy. </param>
     /// <param name="assinatura"> A assinatura de cor do objeto rastreado pela Pixy. </param>
     /// <param name="x"> A posição X do objeto rastreado pela Pixy. </param>
     /// <param name="y"> A posição y do objeto rastreado pela Pixy. </param>
     /// <param name="largura"> A largura do objeto rastreado pela Pixy. </param>
     /// <param name="altura"> A altura do objeto rastreado pela Pixy. </param>
     /// <param name="idade"> A idade (quanto tempo foi rastreado) do objeto rastreado pela Pixy. </param>
    //==========================================================================================================//
    public void CriarIdentificadores(GameObject baseIdenti, float id, float assinatura, float x, float y, float largura, float altura, float idade) {
        GameObject novoIdenti;
        novoIdenti = baseIdenti; // Para caso queira ser só um
        //novoIdenti = Instantiate(baseIdenti) as GameObject;
        novoIdenti.GetComponent<Identificador>().Bola(id, assinatura, x, y, largura, altura, idade);
        novoIdenti.transform.position = novoIdenti.GetComponent<Identificador>().GetPontoOrigemConvertido();
        novoIdenti.transform.localScale = new Vector3(novoIdenti.GetComponent<Identificador>().GetLarguraConvertida(), novoIdenti.GetComponent<Identificador>().GetAlturaConvertida(), 1);
        bool teste = AddIdentificador(novoIdenti);
    }

    //==========================================================================================================//
     /// <summary>
     /// Limpa (remove todos os elementos) da lista de identificadores.
     /// </summary>
    //==========================================================================================================//
    public void LimparIdentificadores() {
        for(int i = 0; i < GetTamanhoListaIdentificadores(); i++) {
            RemoveIdentificador(listaIdentificadores[i]);
        }
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
            Destroy(alvo);
            qtdAlvos--;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Cria os alvos a serem acertados pelo jogador.
     /// </summary>
     /// <param name="baseAlvo"> A GameObject de referência para criação dos alvos. </param>
    //==========================================================================================================//
    public void CriarAlvo(GameObject baseAlvo) {
        GameObject novoAlvo;
        if (GetTamanhoListaAlvos() < CSV_GetMaximoAlvos() & GetQuantidadeAlvos() < CSV_GetMaximoAlvos()) {
            for(int i = 0; i < CSV_GetMaximoAlvos(); i++) {
                if(GetTamanhoListaAlvos() < CSV_GetMaximoAlvos() & GetQuantidadeAlvos() < CSV_GetMaximoAlvos()) {
                    novaCor = new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
                    novoAlvo = Instantiate(baseAlvo) as GameObject;
                    novoAlvo.transform.position = new Vector2(UnityEngine.Random.Range(-7, 7), UnityEngine.Random.Range(-3, 3));
                    novoAlvo.transform.localScale = new Vector3(CSV_GetTamanhoAlvos(), CSV_GetTamanhoAlvos(), 1);
                    material = novoAlvo.GetComponent<Renderer>().material;
                    material.color = novaCor;
                    AddAlvo(novoAlvo);
                }
            }
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
     /// Adiciona o valor passado aos pontos do time amarelo.
     /// </summary>
     /// <param name="pontos"> Valor a ser adicionado aos pontos do time amarelo. </param>
    //==========================================================================================================//
    public void AddPontosAmarelos(int pontos) {
        pontosTimeAmarelo += pontos;
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
