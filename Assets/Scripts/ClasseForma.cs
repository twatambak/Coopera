using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasseForma {
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

    //============================================================================================================
    //============================================================================================================
    public ClasseForma(GameObject objetoBase) {
        this.objetoBase = objetoBase;
        x = objetoBase.transform.localPosition.x;
        y = objetoBase.transform.localPosition.y;
        pontoOrigem = new Vector2(x, y);
        tam = instance.GetTamanhoFormas();
        vel = instance.GetVelocidadeFormas();
        dirX = 0.1f;
        dirY = 0.1f;
    }

    //============================================================================================================
    //============================================================================================================
    public GameObject GetObjetoBase() {
        return objetoBase;
    }

    //============================================================================================================
    //============================================================================================================
    public float GetX() {
        return x;
    }

    //============================================================================================================
    //============================================================================================================
    public float GetY() {
        return y;
    }

    //============================================================================================================
    //============================================================================================================
    public float GetTam() {
        return tam;
    }

    //============================================================================================================
    //============================================================================================================
    public Vector2 GetPontoOrigem() {
        return pontoOrigem;
    }

    //============================================================================================================
    //============================================================================================================
    public Vector2 GetPontoInicial() {
        return pontoInicial;
    }

    //============================================================================================================
    //============================================================================================================
    public Vector2 GetPontoFinal() {
        return pontoFinal;
    }

    //============================================================================================================
    //============================================================================================================
    public float GetDirX() {
        return dirX;
    }

    //============================================================================================================
    //============================================================================================================
    public float GetDirY() {
        return dirY;
    }

    //============================================================================================================
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
    public Vector2 PontoInicialForma() {
        Vector2 pos = new Vector2(((x / 2) + (x / 2)), ((y / 2) - (y / 2)));
        return pos;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto Y central da forma (localizado no canto inferior esquerdo da forma).
     /// </summary>
     /// <param name="forma"> A forma a ser reconhecido o ponto central Y. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector2 PontoFinalForma() {
        Vector2 pos = new Vector2(((x / 2) - (x / 2)), ((y / 2) + (y / 2)));
        return pos;
    }
}
