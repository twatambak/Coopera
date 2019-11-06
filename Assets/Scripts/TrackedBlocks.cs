using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************************************************************
    A classe TrackedBlocks está ligada ao gerenciamento dos objetos reconhecidos pela PixyCam.

    -={ ATRIBUTOS }=-
        -> int index = o ID do objeto rastreado.
        -> int signature = a assinatura do objeto rastreado (a cor dele).
        -> int x = a posição X do objeto.
        -> int y = a posição Y do objeto.
        -> int width = a largura do objeto.
        -> int height = a altura do objeto.

    -={ MÉTODOS }=-
        -> int GetIndex()
        -> int GetSignature()
        -> int GetX()
        -> int GetY()
        -> int GetWidth()
        -> int GetHeight()
        -> override string ToString()
*****************************************************************************************************************/
public class TrackedBlocks {
    int index;
    int signature;
    int x;
    int y;
    int width;
    int height;

    //============================================================================================================
    // public TrackedBlocks(int index, int signature, int x, int y, int width, int height)
    //
    // Construtor da classe de objetos rastreados.
    //============================================================================================================
    public TrackedBlocks(int index, int signature, int x, int y, int width, int height) {
        this.index = index;
        this.signature = signature;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    //============================================================================================================
    // public int GetIndex()
    // 
    // Retorna o ID do objeto rastreado.
    //============================================================================================================
    public int GetIndex() {
        return index;
    }

    //============================================================================================================
    // public int GetSignature()
    //
    // Retorna a assinatura de cor do objeto rastreado.
    //============================================================================================================
    public int GetSignature() {
        return signature;
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
    // public int GetWidth()
    //
    // Retorna o largura do objeto rastreado.
    //============================================================================================================
    public int GetWidth() {
        return width;
    }

    //============================================================================================================
    // public int GetHeight()
    //
    // Retorna a altura do objeto rastreado.
    //============================================================================================================
    public int GetHeight() {
        return height;
    }

    //============================================================================================================
    // public override string ToString()
    //
    // Exibe as informações da classe de objeto rastreado.
    //============================================================================================================
    public override string ToString() {
        string text = "ID: " + index + "| Sig: " + signature + "| X: " + x + "| Y: " + y + "| Width: " + width + "| Height: " + height;
        return text;
    }
}
