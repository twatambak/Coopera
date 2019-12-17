﻿using System;
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
     /// Retorna a quantidade máxima de formas possíveis. Essa informação está disponível na posição 1 (com o vetor
     /// iniciando em 0) do arquvio CSV.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int GetMaximoFormas() {
        return (ToInt(LoadCSV(2)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna a velocidade das formas. Essa informação está disponível na posição 3 (com o vetor iniciando em 0)
     /// do arquvio CSV.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public int GetVelocidadeFormas() {
        return (ToInt(LoadCSV(4)));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho das formas. Essa informação está disponível na posição 5 (com o vetor iniciando em 0)
     /// do arquvio CSV. 
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
     /// A função recebe uma lista de ObjetosRastreados, refente aos objetos rastreados. A lista (listaRastreados) 
     /// dentro da classe atual (Utils), armazena todos os blocos rastreados. Essa lista é atualizada com as 
     /// informações recebidas por essa função.
     /// </summary>
     /// <param name="dados"> Lista de dados de objetos rastreados. </param>
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
     /// Adiciona o objeto passado à lista de objetos rastreados.
     /// </summary>
     /// <param name="rastreado"></param>
    //==========================================================================================================//
    public void AddListaRastreados(ObjetosRastreados rastreado) {
        listaRastreados.Add(rastreado);
        Debug.Log("Tam: " + GetListaRastreados().Count);
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove o objeto passado da lista de objetos rastreados.s
     /// </summary>
     /// <param name="rastreado"></param>
    //==========================================================================================================//
    public void RemoveListaRastreados(ObjetosRastreados rastreado) {
        listaRastreados.Remove(rastreado);
        Debug.Log("Tam: " + GetListaRastreados().Count);
    }

    //==========================================================================================================//
     /// <summary>
     /// Remove os objetos rastreados antigos que tenham uma idade maior do que 30 frames.
     /// </summary>
    //==========================================================================================================//
    public void RemoveRastreadosAntigos() {
        for (int i = 0; i < listaRastreados.Count; i++) {
            if(listaRastreados[i].GetIdade() > 500) {
                RemoveListaRastreados(listaRastreados[i]);
            }
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Limpa os objetos rastreados pela PixyCam.
     /// </summary>
    //==========================================================================================================//
    public void LimparRastreados() {
        listaRastreados.Clear();
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

    //==========================================================================================================//
     /// <summary>
     /// Converte o ponto X (localizado dentro do sistema de coordenadas da PixyCam) para o sistema de coordendas
     /// do jogo.
     /// </summary>
     /// <param name="x"> O ponto X do objeto rastreado. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public float ViewportPixyJogo_ConverteX(float x) {
        float convX = ((16 * (300 - x)) / 300) - 8;
        return convX;
    }

    //==========================================================================================================//
     /// <summary>
     /// Converte o ponto Y (localizado dentro do sistema de coordenadas da PixyCam) para o sistema de coordendas
     /// do jogo.
     /// </summary>
     /// <param name="y"> O ponto y central do objeto rastreado. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public float ViewportPixyJogo_ConverteY(float y) {
        float convY = ((8 * (200 - y)) / 200) - 4;
        return convY;
    }

    //==========================================================================================================//
     /// <summary>
     /// Realiza a conversão do vetor recebido para o sistema de coordenadas do jogo.
     /// </summary>
     /// <param name="conv"> O vetor a ser convertido. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector3 ViewportPixyJogo_Vetor(Vector3 conv) {
        Vector3 converte = new Vector3(ViewportPixyJogo_ConverteX(conv.x), ViewportPixyJogo_ConverteY(conv.y), conv.z);
        return converte;
    }

    //==========================================================================================================//
     /// <summary>
     /// Realiza o Viewport (o porte das coordenadas) para o BoundingBox do ponto X (localizado no canto superior
     /// direito) do objeto rastreado pela PixyCam para o sistema de coordenadas do jogo.
     /// </summary>
     /// <param name="objeto"> O objeto ao qual deseja-se ser feito o viewport. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector3 ViewportPixyJogo_PontoDireita(ObjetosRastreados objeto) {
        Vector3 posX = PontoDireitaRastreado(objeto);
        Vector3 conversao = ViewportPixyJogo_Vetor(posX);
        //Vector3 conv = ViewportPixyJogo_Vetor(RetornaVetorRastreio(objeto));
        //Vector3 conversao = PontoDireitaRastreado(conv, objeto.GetAltura());
        return conversao;
    }

    //==========================================================================================================//
     /// <summary>
     /// Realiza o Viewport (o porte das coordenadas) para o BoundingBox do ponto Y (localizado no canto superior
     /// direito) do objeto rastreado pela PixyCam para o sistema de coordenadas do jogo.
     /// </summary>
     /// <param name="objeto"> O objeto ao qual deseja-se ser feito o viewport. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector3 ViewportPixyJogo_PontoEsquerda(ObjetosRastreados objeto) {
        Vector3 posY = PontoEsquerdaRastreado(objeto);
        Vector3 conversao = ViewportPixyJogo_Vetor(posY);
        //Vector3 conv = ViewportPixyJogo_Vetor(RetornaVetorRastreio(objeto));
        //Vector3 conversao = PontoEsquerdaRastreado(conv, objeto.GetAltura());
        return conversao;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto X central da forma (localizado no canto superior direito da forma).
     /// </summary>
     /// <param name="forma"> A forma a ser reconhecido o ponto central X. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector3 PontoDireitaForma(GameObject forma) {
        Vector3 pos = new Vector3(((forma.transform.localPosition.x / 2) + (forma.transform.localScale.x / 2)), ((forma.transform.localPosition.y / 2) - (forma.transform.localScale.y / 2)), forma.transform.localPosition.z);
        return pos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto Y central da forma (localizado no canto inferior esquerdo da forma).
     /// </summary>
     /// <param name="forma"> A forma a ser reconhecido o ponto central Y. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector3 PontoEsquerdaForma(GameObject forma) {
        Vector3 pos = new Vector3(((forma.transform.localPosition.x / 2) - (forma.transform.localScale.x / 2)), ((forma.transform.localPosition.y / 2) + (forma.transform.localScale.y / 2)), forma.transform.localPosition.z);
        return pos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto X central do objeto rastreado (localizado no canto superior direito do objeto rastreado).
     /// </summary>
     /// <param name="rastreio"> O objeto rastreado ao qual se deseja saber o ponto central X. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector3 PontoDireitaRastreado(ObjetosRastreados rastreio) {
        Vector3 pos = new Vector3((rastreio.GetX() + rastreio.GetLargura()), (rastreio.GetY() - rastreio.GetAltura()), 0);
        return pos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto Y central do objeto rastreado (localizado no canto inferior esquerdo do objeto rastreado).
     /// </summary>
     /// <param name="rastreio"> O objeto rastreado ao qual se deseja saber o ponto central Y. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector3 PontoEsquerdaRastreado(ObjetosRastreados rastreio) {
        Vector3 pos = new Vector3((rastreio.GetX() - rastreio.GetLargura()), (rastreio.GetY() + rastreio.GetAltura()), 0);
        return pos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto X central do objeto rastreado (localizado no canto superior direito do objeto rastreado).
     /// </summary>
     /// <param name="conv"></param>
     /// <param name="tam"></param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector3 PontoDireitaRastreado(Vector3 conv, float tam) {
        Vector3 pos = new Vector3((conv.x + tam), conv.y, conv.z);
        return pos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto Y central do objeto rastreado (localizado no canto inferior esquerdo do objeto rastreado).
     /// </summary>
     /// <param name="conv"></param>
     /// <param name="tam"></param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector3 PontoEsquerdaRastreado(Vector3 conv, float tam) {
        Vector3 pos = new Vector3((conv.x + tam), conv.y, conv.z);
        return pos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna se houve colisão entre dois objetos. Para tal, ele utiliza dos vetores que compõem a BoundingBox
     /// dos dois objetos.
     /// </summary>
     /// <param name="rastreioEsq"> O ponto a esquerda da BoundingBox do objeto rastreado. </param>
     /// <param name="rastreioDir"> O ponto a direita da BoundingBox do objeto rastreado. </param>
     /// <param name="formaEsq"> O ponto a esquerda da BoundingBox da forma.</param>
     /// <param name="formaDir"> O ponto a direita da BoundingBox da forma.</param>
     /// <returns></returns>
    //==========================================================================================================//
    public Boolean VerificaColisao(Vector3 rastreioEsq, Vector3 rastreioDir, Vector3 formaEsq, Vector3 formaDir) {
        if (rastreioDir.x < formaEsq.x || formaDir.x < rastreioEsq.x || rastreioDir.y < formaEsq.y || formaDir.y < rastreioEsq.y) { // Não há colisão
            return false;
        } else {
            return true;
        }
    }

    //==========================================================================================================//
    /// <summary>
    /// Verifica a colisão entre dois objetos passados como parâmetros. Para tal ele utiliza da função
    /// <seealso cref="VerificaColisao(Vector3, Vector3, Vector3, Vector3)"/> para realizar essa verificação.
    /// </summary>
    /// <param name="forma"> A forma que deseja ser verificada se houve colisão. </param>
    /// <param name="rastreio"> O objeti rastreado que deseja ser verificado se houve colisão. </param>
    /// <returns> Booleano indicando se houve ou não colisão. </returns>
    //==========================================================================================================//
    public Boolean VerificaColisao(GameObject forma, ObjetosRastreados rastreio) {
        Vector3 rastreioPontoDir = ViewportPixyJogo_PontoDireita(rastreio);
        Vector3 rastreioPontoEsq = ViewportPixyJogo_PontoEsquerda(rastreio);
        Vector3 formaPontoDir = PontoDireitaForma(forma);
        Vector3 formaPontoEsq = PontoEsquerdaForma(forma);
        return (VerificaColisao(rastreioPontoDir, rastreioPontoEsq, formaPontoDir, formaPontoEsq));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o vetor da posição central do objeto rastreado.
     /// </summary>
     /// <param name="rastreio"> O objeto rastreado ao qual se deseja retornar o vetor da posição central. </param>
     /// <returns> Vetor da posição central do objeto rastreado. </returns>
    //==========================================================================================================//
    public Vector3 RetornaVetorRastreio(ObjetosRastreados rastreio) {
        return (new Vector3(rastreio.GetX(), rastreio.GetY(), 0));
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o vetor da posição central da forma.
     /// </summary>
     /// <param name="forma"> A forma ao qual se deseja retornar o vetor da posição central. </param>
     /// <returns> Vetor da posição central da forma. </returns>
    //==========================================================================================================//
    public Vector3 RetornaVetorForma(GameObject forma) {
        return forma.transform.localPosition;
    }
}
