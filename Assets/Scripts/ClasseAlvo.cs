using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasseAlvo {
    /// <summary> A instância de Utils. Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados. </summary>
    static InterfaceUtils instance = Utils.GetInstance();
    /// <summary> Objeto base para a forma alvo. </summary>
    GameObject objetoBase;
    /// <summary> Ponto X da posição de origem. </summary>
    float x;
    /// <summary> Ponto Y da posição de origem. </summary>
    float y;
    /// <summary> Tamanho da Forma </summary>
    float tam;
    /// <summary> Tamanho da Forma </summary>
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
    /// <summary> ID de identificação. </summary>
    int id;

    //============================================================================================================
     /// <summary>
     /// Construtor da classe para a forma-alvo.
     /// </summary>
     /// <param name="objetoBase"> O objeto a ser usado de base para criação da forma-alvo. </param>
    //============================================================================================================
    public ClasseAlvo(GameObject objetoBase) {
        this.objetoBase = objetoBase;
        x = objetoBase.transform.localPosition.x;
        y = objetoBase.transform.localPosition.y;
        pontoOrigem = new Vector2(x, y);
        tam = instance.GetTamanhoFormas();
        vel = instance.GetVelocidadeFormas();
        dirX = 0.1f;
        dirY = 0.1f;
        cor = objetoBase.GetComponent<Renderer>().material.color;
        pontoInicial = PontoInicial();
        pontoFinal = PontoFinal();
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o objeto base que cria a forma-alvo. 
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public GameObject GetObjetoBase() {
        return objetoBase;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ponto central X original da forma-alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetX() {
        return x;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ponto central Y original da forma-alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetY() {
        return y;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o tamanho da forma-alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetTam() {
        return tam;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a posição central original da forma-alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public Vector2 GetPontoOrigem() {
        return pontoOrigem;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ponto inicial do viewport da forma-alvo. O ponto é localizado no canto esquerdo inferior.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public Vector2 GetPontoInicial() {
        return pontoInicial;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ponto final do viewport da forma-alvo. O ponto é localizado no canto direito superior.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public Vector2 GetPontoFinal() {
        return pontoFinal;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a direção de movimento no eixo X da forma-alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetDirX() {
        return dirX;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a direção de movimento no eixo X da forma-alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetDirY() {
        return dirY;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a velocidade de movimento da forma-alvo.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetVel() {
        return vel;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto X central da forma (localizado no canto superior direito da forma).
     /// </summary>
     /// <param name="forma"> A forma a ser reconhecido o ponto central X. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector2 PontoInicial() {
        Vector2 pos = new Vector2((x / 2) - tam, (y / 2) + tam);
        return pos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto Y central da forma (localizado no canto inferior esquerdo da forma).
     /// </summary>
     /// <param name="forma"> A forma a ser reconhecido o ponto central Y. </param>
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
        string texto = "FORMA-ALVO => Posição Original(" + GetPontoOrigem().x + " | " + GetPontoOrigem().y + ") => Posição Inicial(" + GetPontoInicial().x + " | " + GetPontoInicial().y + ") => Posição Final(" + GetPontoFinal().x + " | " + GetPontoFinal().y + ")";
        return texto;
    }
}
