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
    /// <summary> Lista de formas geradas pelo jogo. </summary>
    public static List<GameObject> listaAlvos = new List<GameObject>();
    /// <summary> Lista de formas geradas pelo jogo. </summary>
    public static List<ClasseAlvo> listaClasseAlvos = new List<ClasseAlvo>();
    /// <summary> Quantidade atual de formas presentes na tela. </summary>
    public static int qtdAlvos;
    /// <summary> Quantia de pontos do time amarelo. </summary>
    public static int pontosTimeAmarelo;
    /// <summary> Quantia de pontos do time verde. </summary>
    public static int pontosTimeVerde;
    /// <summary> Forma base. </summary>
    public Alvo alvo;
    /// <summary> Material de base utilizado para alterar a cor das formas conforme elas são criadas. </summary>
    Material material;
    /// <summary> Cores das novas formas. </summary>
    public static Color novaCor;
    /// <summary> Velocidade das formas. Valor obtido através do CSV de configuração. Posição (4) a ser chamada pela função <see cref="LoadCSV(int)"/>. </summary>
    int vel;
    /// <summary> Tamanho das formas. Valor obtido através do CSV de configuração. Posição (6) a ser chamada pela função <see cref="LoadCSV(int)"/>. </summary>
    int tam;

    public GameObject identificadores;
    public List<GameObject> listaIdentificadores = new List<GameObject>();

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
     /// Retorna a quantidade máxima de alvos possíveis. Essa informação está disponível na posição 1 (com o vetor
     /// iniciando em 0) do arquvio CSV.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int CSVGetMaximoAlvos() {
        return (ToInt(LoadCSV(2)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a velocidade dos alvos. Essa informação está disponível na posição 3 (com o vetor iniciando em 0)
     /// do arquvio CSV.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int CSVGetVelocidadeAlvos() {
        return (ToInt(LoadCSV(4)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho dos alvos. Essa informação está disponível na posição 5 (com o vetor iniciando em 0)
     /// do arquvio CSV. 
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int CSVGetTamanhoAlvos() {
        return (ToInt(LoadCSV(6)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de alvos.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public List<GameObject> GetListaAlvos() {
        return listaAlvos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de objetos rastreados.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public List<Bola> GetListaBolas() {
        return listaBolas;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de classes da alvo.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public List<ClasseAlvo> GetListaClasseAlvos() {
        return listaClasseAlvos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a quantidade atual de formas.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int GetQuantidadeAlvos() {
        return qtdAlvos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho da lista de rastreados.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int GetTamanhoListaRastreados() {
        return listaBolas.Count;
    }

    //==========================================================================================================//
     /// <summary>
     /// Exibe o tamanho da lista de rastreados.
     /// </summary>
    //==========================================================================================================//
    public void ExibeTamanhoListaRastreados() {
        Debug.Log("Tamanho da Lista de Rastreados: " + GetTamanhoListaRastreados());
    }

    //==========================================================================================================//
     /// <summary>
     /// A função recebe uma lista de ObjetosRastreados, refente aos objetos rastreados. A lista (listaRastreados) 
     /// dentro da classe atual (Utils), armazena todos os blocos rastreados. Essa lista é atualizada com as 
     /// informações recebidas por essa função.
     /// </summary>
     /// <param name="dados"> Lista de dados de objetos rastreados. </param>
    //==========================================================================================================//
    public void UpdateListaRastreados(List<ObjetosRastreados> dados) {
        listaBolas = dados;
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
     /// <param name="baseAlvo"></param>
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
                    ClasseAlvo classe = new ClasseAlvo(novoAlvo);
                    AddListaClasseFormas(classe);
                    AddListaAlvos(novoAlvo);
                    AddQuantidadeAlvos();
                }
            }
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o alvo recebido na lista de alvos.
     /// </summary>
     /// <param name="alvo"></param>
    //==========================================================================================================//
    public void AddListaAlvos(GameObject alvo) {
        listaAlvos.Add(alvo);
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove o alvo recebido da lista de alvos.
     /// </summary>
     /// <param name="alvo"></param>
    //==========================================================================================================//
    public void RemoveListaAlvos(GameObject alvo) {
        listaAlvos.Remove(alvo);
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona a classe alvo passada na lista de classe de alvos.
     /// </summary>
     /// <param name="alvo"></param>
    //==========================================================================================================//
    public void AddListaClasseAlvo(ClasseAlvo alvo) {
        listaClasseAlvos.Add(alvo);
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove a classe alvo passada da lista de classe de alvos.
     /// </summary>
     /// <param name="forma"></param>
    //==========================================================================================================//
    public void RemoveListaClasseAlvos(ClasseAlvo alvo) {
        listaClasseAlvos.Remove(forma);
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove a GameObject alvo passada da lista de alvos.
     /// </summary>
     /// <param name="forma"></param>
    //==========================================================================================================//
    public void RemoveListaClasseAlvos(GameObject alvo) {
        if(listaClasseAlvos.Count > 0) {
            for(int i = 0; i < listaClasseAlvos.Count; i++) { 
                if(listaClasseAlvos[i].GetObjetoBase() == alvo) {
                    listaClasseAlvos.RemoveAt(i);
                }
            }
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o objeto passado à lista de objetos rastreados.
     /// </summary>
     /// <param name="rastreado"></param>
    //==========================================================================================================//
    public void AddListaRastreados(ObjetosRastreados rastreado) {
        if(listaBolas.Count != 0) {
            for(int i = 0; i < listaBolas.Count; i++) {
                Debug.Log(rastreado);
                if(listaBolas[i].GetID() == rastreado.GetID()) {
                    listaBolas[i] = rastreado;
                    ExibeTamanhoListaRastreados();
                } else {
                    listaBolas.Add(rastreado);
                    ExibeTamanhoListaRastreados();
                }
            }
        } else {
            listaBolas.Add(rastreado);
            ExibeTamanhoListaRastreados();
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove o objeto passado da lista de objetos rastreados.s
     /// </summary>
     /// <param name="rastreado"></param>
    //==========================================================================================================//
    public void RemoveListaRastreados(ObjetosRastreados rastreado) {
        listaBolas.Remove(rastreado);
    }

    //==========================================================================================================//
     /// <summary>
     /// Limpa os objetos rastreados pela PixyCam.
     /// </summary>
    //==========================================================================================================//
    public void LimparRastreados() {
        listaBolas.Clear();
    }

    //==========================================================================================================//
     /// <summary>
     /// Acrescenta uma unidade da quantia atual de formas.
     /// </summary>
    //==========================================================================================================//
    public void AddQuantidadeAlvos() {
        if (qtdAlvos < CSVGetMaximoAlvos()) {
            qtdAlvos++;
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove uma unidade da quantia atual de alvos.
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

    //==========================================================================================================//
     /// <summary>
     /// Retorna se houve colisão entre dois objetos. Para tal, ele utiliza dos vetores que compõem a BoundingBox
     /// dos dois objetos.
     /// </summary>
     /// <param name="rastreioInicial"> O ponto a esquerda da BoundingBox do objeto rastreado. </param>
     /// <param name="rastreioFinal"> O ponto a direita da BoundingBox do objeto rastreado. </param>
     /// <param name="alvoInicial"> O ponto a esquerda da BoundingBox da alvo.</param>
     /// <param name="alvoFinal"> O ponto a direita da BoundingBox da alvo.</param>
     /// <returns></returns>
    //==========================================================================================================//
    public Boolean VerificaColisao(Vector2 rastreioInicial, Vector2 rastreioFinal, Vector2 alvoInicial, Vector2 alvoFinal) {
        if (rastreioFinal.x < alvoInicial.x || alvoFinal.x < rastreioInicial.x || rastreioFinal.y < alvoInicial.y || alvoFinal.y < rastreioInicial.y) { // Não há colisão
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
    /// <param name="alvo"> A alvo que deseja ser verificada se houve colisão. </param>
    /// <param name="rastreio"> O objeti rastreado que deseja ser verificado se houve colisão. </param>
    /// <returns> Booleano indicando se houve ou não colisão. </returns>
    //==========================================================================================================//
    public Boolean VerificaColisao(ClasseAlvo alvo, ObjetosRastreados rastreio) {
        Vector2 rastreioInicial = rastreio.GetPontoInicial();
        Vector2 rastreioFinal = rastreio.GetPontoFinal();
        Vector2 alvoInicial = alvo.GetPontoInicial();
        Vector2 alvoFinal = alvo.GetPontoFinal();
        Boolean colidiu = VerificaColisao(rastreioInicial, rastreioFinal, alvoInicial, alvoFinal);
        return colidiu;
    }

    public void CriaQuadrado(ObjetosRastreados rastreio) {
        GameObject identificador;
        float largura = rastreio.GetPontoFinal().x - rastreio.GetPontoInicial().x;
        float altura = rastreio.GetPontoFinal().y - rastreio.GetPontoInicial().y;
        for(int i = 0; i < listaBolas.Count; i++) {
            identificador = Instantiate(identificadores) as GameObject;
            identificador.transform.position = rastreio.OrigemConvertida();
            identificador.transform.localScale = new Vector2(largura, altura);
            AddIdentificador(identificador);
        }
    }
    
    public void AddIdentificador(GameObject identificador) {
        listaIdentificadores.Add(identificador);
    }
 
    public void MovimentaIdentificador() { 
    }

}
