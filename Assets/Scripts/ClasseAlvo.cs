using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasseAlvo {
    /// <summary> A instância de Utils. Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados. </summary>
    static InterfaceUtils instance = Utils.GetInstance();
    /// <summary> Objeto base para o alvo. </summary>
    GameObject objetoBase;
    /// <summary> Ponto X da posição de origem. </summary>
    float x;
    /// <summary> Ponto Y da posição de origem. </summary>
    float y;
    /// <summary> Tamanho do alvo </summary>
    float tam;
    /// <summary> Tamanho do alvo. </summary>
    Vector2 pontoOrigem;
    /// <summary> Posição inicial do viewport (localizada no canto esquerdo inferior do objeto). </summary>
    Vector2 pontoInicial;
    /// <summary> Posição final do viewport (localizada no canto direito superior do objeto). </summary>
    Vector2 pontoFinal;
    /// <summary> Direção de movimentação no eixo X </summary>
    float dirX;
    /// <summary> Direção de movimentação no eixo Y </summary>
    float dirY = 0.1f;
    /// <summary> Velocidade de movimentação </summary>
    float vel;
    /// <summary> Velocidade de movimentação </summary>
    Color cor;

    //============================================================================================================
     /// <summary>
     /// Construtor da classe para o alvo.
     /// </summary>
     /// <param name="objetoBase"> O objeto a ser usado de base para criação do alvo. </param>
    //============================================================================================================
    public ClasseAlvo(GameObject objetoBase) {
        this.objetoBase = objetoBase;
        x = objetoBase.transform.localPosition.x;
        y = objetoBase.transform.localPosition.y;
        pontoOrigem = new Vector2(x, y);
        tam = instance.CSVGetTamanhoAlvos();
        vel = instance.CSVGetVelocidadeAlvos();
        dirX = 0.1f;
        dirY = 0.1f;
        cor = objetoBase.GetComponent<Renderer>().material.color;
        pontoInicial = PontoInicial();
        pontoFinal = PontoFinal();
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o objeto base que cria o alvo. 
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public GameObject GetObjetoBase() {
        return objetoBase;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ponto central X original do alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetX() {
        return x;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ponto central Y original do alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetY() {
        return y;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o tamanho do alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetTam() {
        return tam;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a posição central original do alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public Vector2 GetPontoOrigem() {
        return pontoOrigem;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ponto inicial do viewport do alvo. O ponto é localizado no canto esquerdo inferior.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public Vector2 GetPontoInicial() {
        return pontoInicial;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ponto final do viewport do alvo. O ponto é localizado no canto direito superior.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public Vector2 GetPontoFinal() {
        return pontoFinal;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a direção de movimento no eixo X do alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetDirX() {
        return dirX;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a direção de movimento no eixo X do alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetDirY() {
        return dirY;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a velocidade de movimento do alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetVel() {
        return vel;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto X central do alvo (localizado no canto superior direito da alvo).
     /// </summary>
     /// <param name="alvo"> O alvo a ser reconhecido o ponto central X. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector2 PontoInicial() {
        Vector2 pos = new Vector2((x / 2) - tam, (y / 2) + tam);
        return pos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto Y central do alvo (localizado no canto inferior esquerdo do alvo).
     /// </summary>
     /// <param name="alvo"> O alvo a ser reconhecido o ponto central Y. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector2 PontoFinal() {
        Vector2 pos = new Vector2((x / 2) + tam, (y / 2) - tam);
        return pos;
    }

    //==========================================================================================================//
     /// <summary>
     /// ToString
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public override string ToString() {
        string texto = "ALVO => Posição Original(" + GetPontoOrigem().x + " | " + GetPontoOrigem().y + ") => Posição Inicial(" + GetPontoInicial().x + " | " + GetPontoInicial().y + ") => Posição Final(" + GetPontoFinal().x + " | " + GetPontoFinal().y + ")";
        return texto;
    }
}
