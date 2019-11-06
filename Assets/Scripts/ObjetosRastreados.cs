using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************************************************************
    A classe ObjetosRastreados está ligada ao gerenciamento dos objetos reconhecidos pela PixyCam.

    -={ ATRIBUTOS }=-
        -> int id = o ID do objeto rastreado.
        -> int assinatura = a assinatura do objeto rastreado (a cor dele).
        -> int x = a posição X do objeto.
        -> int y = a posição Y do objeto.
        -> int largura = a largura do objeto.
        -> int altura = a altura do objeto.

    -={ MÉTODOS }=-
        -> int GetID()
        -> int GetAssinatura()
        -> int GetX()
        -> int GetY()
        -> int GetLargura()
        -> int GetHeight()
        -> override string ToString()
*****************************************************************************************************************/
public class ObjetosRastreados {
    int id;
    int assinatura;
    int x;
    int y;
    int largura;
    int altura;

    //============================================================================================================
    // public ObjetosRastreados(int id, int assinatura, int x, int y, int largura, int altura)
    //
    // Construtor da classe de objetos rastreados.
    //============================================================================================================
    public ObjetosRastreados(int id, int assinatura, int x, int y, int largura, int altura) {
        this.id = id;
        this.assinatura = assinatura;
        this.x = x;
        this.y = y;
        this.largura = largura;
        this.altura = altura;
    }

    //============================================================================================================
    // public int GetID()
    // 
    // Retorna o ID do objeto rastreado.
    //============================================================================================================
    public int GetID() {
        return id;
    }

    //============================================================================================================
    // public int GetAssinatura()
    //
    // Retorna a assinatura de cor do objeto rastreado.
    //============================================================================================================
    public int GetAssinatura() {
        return assinatura;
    }

    //============================================================================================================
    // public int GetX()
    //
    // Retorna a posição X do objeto rastreado.
    //============================================================================================================
    public int GetX() {
        return x;
    }

    //============================================================================================================
    // public int GetY()
    //
    // Reotrna a posição Y do objeto rastreado.
    //============================================================================================================
    public int GetY() {
        return y;
    }

    //============================================================================================================
    // public int GetLargura()
    //
    // Retorna o largura do objeto rastreado.
    //============================================================================================================
    public int GetLargura() {
        return largura;
    }

    //============================================================================================================
    // public int GetHeight()
    //
    // Retorna a altura do objeto rastreado.
    //============================================================================================================
    public int GetAltura() {
        return altura;
    }

    //============================================================================================================
    // public override string ToString()
    //
    // Exibe as informações da classe de objeto rastreado.
    //============================================================================================================
    public override string ToString() {
        string texto = "ID: " + id + "| Assinatura: " + assinatura + "| X: " + x + "| Y: " + y + "| Width: " + largura + "| Height: " + altura;
        return texto;
    }
}
