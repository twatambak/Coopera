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
    /// <summary> Lista das bolas rastreadas pela PixyCam. </summary>
    public static List<Bola> listaBolas = new List<Bola>();
    /// <summary> Lista de alvos geradas pelo jogo. </summary>
    public static List<GameObject> listaAlvos = new List<GameObject>();
    /// <summary> Lista de identificadores das bolas rastreadas. </summary>
    public static List<GameObject> listaIdentificadores = new List<GameObject>();
    /// <summary> Quantidade atual de alvos presentes na tela. </summary>
    public static int qtdAlvos;
    /// <summary> Quantia de pontos do time amarelo. </summary>
    public static int pontosTimeAmarelo;
    /// <summary> Quantia de pontos do time verde. </summary>
    public static int pontosTimeVerde;
    /// <summary> Identificador de posição da bola rastreada. </summary>
    public GameObject identificadores;
    /// <summary> Cores dos novos alvos. </summary>
    public static Color novaCor;
    /// <summary> Velocidade das alvos. Valor obtido através do CSV de configuração. Posição (4) a ser chamada pela função <see cref="LoadCSV(int)"/>. </summary>
    int vel;
    /// <summary> Tamanho das alvos. Valor obtido através do CSV de configuração. Posição (6) a ser chamada pela função <see cref="LoadCSV(int)"/>. </summary>
    int tam;
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
     /// iniciando em 0) do arquivo CSV.
     /// </summary>
     /// <returns> A quantidade máxima possível para os alvos. </returns>
    //==========================================================================================================//
    public int CSVGetMaximoAlvos() {
        return (ToInt(LoadCSV(2)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a velocidade dos alvos. Essa informação está disponível na posição 3 (com o vetor iniciando em 0)
     /// do arquivo CSV.
     /// </summary>
     /// <returns> A velocidade de movimento dos alvos. </returns>
    //==========================================================================================================//
    public int CSVGetVelocidadeAlvos() {
        return (ToInt(LoadCSV(4)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho dos alvos. Essa informação está disponível na posição 5 (com o vetor iniciando em 0)
     /// do arquivo CSV. 
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    public int CSVGetTamanhoAlvos() {
        return (ToInt(LoadCSV(6)));
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
     /// Retorna a lista de bolas.
     /// </summary>
     /// <returns> A lista de bolas rastreadas pela PixyCam. </returns>
    //==========================================================================================================//
    public List<Bola> GetListaBolas() {
        return listaBolas;
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
     /// Retorna o tamanho da lista de bolas.
     /// </summary>
     /// <returns> O tamanho da lista de bolas. Atua também como a quantidade atual de bolas. </returns>
    //==========================================================================================================//
    public int GetTamanhoListaBolas() {
        return listaBolas.Count;
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
    public void GoToScene(string scene){
      SceneManager.LoadScene(scene);
    }

    //==========================================================================================================//
     /// <summary>
     /// Cria os alvos. a serem acertadas pelo jogador.
     /// </summary>
     /// <param name="baseAlvo"> A GameObject de referência para criação dos alvos. </param>
    //==========================================================================================================//
    public void CriarAlvos(GameObject baseAlvo) {
        GameObject novoAlvo;
        int maxAlvos = CSVGetMaximoAlvos();
        qtdAlvos = GetQuantidadeAlvos();
        vel = CSVGetVelocidadeAlvos();
        tam = CSVGetTamanhoAlvos();
        if (qtdAlvos < maxAlvos) {
            for(int i = 0; i < maxAlvos; i++) {
                if(qtdAlvos < maxAlvos) {
                    novaCor = new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
                    novoAlvo = Instantiate(baseAlvo) as GameObject;
                    novoAlvo.transform.position = new Vector2(UnityEngine.Random.Range(-7, 7), UnityEngine.Random.Range(-3, 3));
                    novoAlvo.transform.localScale = new Vector3(tam, tam, tam);
                    material = novoAlvo.GetComponent<Renderer>().material;
                    material.color = novaCor;
                    AddListaAlvos(novoAlvo);
                }
            }
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o alvo recebido na lista de alvos.
     /// </summary>
     /// <param name="alvo"> O alvo a ser adicionado na respectiva lista. </param>
    //==========================================================================================================//
    public void AddListaAlvos(GameObject alvo) {
        listaAlvos.Add(alvo);
        AddQuantidadeAlvos();
    }

    //==========================================================================================================//
    /// <summary>
    /// Remove o alvo recebido da lista de alvos.
    /// </summary>
    /// <param name="alvo"> O alvo a ser removido da respectiva lista. </param>
    //==========================================================================================================//
    public void RemoveListaAlvos(GameObject alvo) {
        listaAlvos.Remove(alvo);
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona a bola passada na lista de bolas.
     /// </summary>
     /// <param name="bola"> A bola rastreada pela Pixy a ser adicionada na lista. </param>
    //==========================================================================================================//
    public void AddListaBolas(Bola bola) {
        //Debug.Log(bola);
        if(listaBolas.Count > 0) {
            for(int i = 0; i < listaBolas.Count; i++) {
                if(listaBolas[i].GetID() == bola.GetID() || listaBolas[i].GetPontoOrigem() == bola.GetPontoOrigem()) {
                    listaBolas[i] = bola;
                } else {
                    listaBolas.Add(bola);
                }
            }
        } else {
            listaBolas.Add(bola);
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove a bola da lista de bolas.
     /// </summary>
     /// <param name="bola"> A bola a ser removida da lista. </param>
    //==========================================================================================================//
    public void RemoveListaBolas(Bola bola) {
        listaBolas.Remove(bola);
    }

    //==========================================================================================================//
     /// <summary>
     /// Limpa as bolas rastreadas pela PixyCam.
     /// </summary>
    //==========================================================================================================//
    public void LimpaListaBolas() {
        listaBolas.Clear();
    }

    //==========================================================================================================//
     /// <summary>
     /// Aumenta em 1 a quantidade de alvos.
     /// </summary>
    //==========================================================================================================//
    public void AddQuantidadeAlvos() {
        if(qtdAlvos < CSVGetMaximoAlvos()) {
            qtdAlvos++;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Subtrai em 1 a quantidade de alvos.
     /// </summary>
    //==========================================================================================================//
    public void RemoveQuantidadeAlvos() { 
        if(qtdAlvos > 0) {
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
     /// Retorna se houve colisão entre dois objetos. Para tal, ele utiliza dos vetores que compõem a BoundingBox
     /// dos dois objetos.
     /// </summary>
     /// <param name="bolaInicial"> O ponto a esquerda da BoundingBox da bola. </param>
     /// <param name="bolaFinal"> O ponto a direita da BoundingBox da bola. </param>
     /// <param name="alvoInicial"> O ponto a esquerda da BoundingBox do alvo.</param>
     /// <param name="alvoFinal"> O ponto a direita da BoundingBox do alvo.</param>
     /// <returns> Booleano indicando se houve ou não colisão. </returns>
    //==========================================================================================================//
    public Boolean VerificaColisao(Vector2 bolaInicial, Vector2 bolaFinal, Vector2 alvoInicial, Vector2 alvoFinal) {
        if (bolaFinal.x < alvoInicial.x || alvoFinal.x < bolaInicial.x || bolaFinal.y < alvoInicial.y || alvoFinal.y < bolaInicial.y) { // Não há colisão
            return false;
        } else {
            return true;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Verifica a colisão entre dois objetos passados como parâmetros. Para tal ele utiliza da função
     /// <seealso cref="VerificaColisao(Vector2, Vector2, Vector2, Vector2)"/> para realizar essa verificação.
     /// </summary>
     /// <param name="alvo"> O alvo que deseja ser verificada se houve colisão. </param>
     /// <param name="bola"> O objeto rastreado que deseja ser verificado se houve colisão. </param>
     /// <returns> Booleano indicando se houve ou não colisão. </returns>
    //==========================================================================================================//
    public Boolean VerificaColisao(GameObject alvo, Bola bola) {
        Vector2 bolaInicial = bola.GetPontoInicial();
        Vector2 bolaFinal = bola.GetPontoFinal();
        Vector2 alvoInicial = alvo.GetComponent<Alvo>().GetPontoInicial();
        Vector2 alvoFinal = alvo.GetComponent <Alvo>().GetPontoFinal();
        Boolean colidiu = VerificaColisao(bolaInicial, bolaFinal, alvoInicial, alvoFinal);
        return colidiu;
    }

    //==========================================================================================================//
     /// <summary>
     /// Cria um quadrado de identificação para a visualização da posição bola rastreada em função do jogo.
     /// </summary>
     /// <param name="bola"> A bola base para a criação do quadrado. </param>
    //==========================================================================================================//
    public void CriaQuadrado(Bola bola) {
        GameObject identificador;
        float largura = bola.GetPontoFinal().x - bola.GetPontoInicial().x;
        float altura = bola.GetPontoFinal().y - bola.GetPontoInicial().y;
        for(int i = 0; i < listaBolas.Count; i++) {
            identificador = Instantiate(identificadores) as GameObject;
            identificador.transform.position = bola.OrigemConvertida();
            identificador.transform.localScale = new Vector2(largura, altura);
            AddIdentificador(identificador);
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona um quadrado identificador à lista de identificadores.
     /// </summary>
     /// <param name="identificador"> O identificador a ser adicionado na lista. </param>
    //==========================================================================================================//
    public void AddIdentificador(GameObject identificador) {
        listaIdentificadores.Add(identificador);
    }

}
