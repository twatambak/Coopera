using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************************************************************/
 /// <summary>
 /// A classe ObjetosRastreados está ligada ao gerenciamento dos objetos reconhecidos pela PixyCam.
 /// </summary>
/************************************************************************************************************/
public class ObjetosRastreados {
    /// <summary> ID do objeto rastreado. </summary>
    int id;
    /// <summary> Assinatura de cor do objeto rastreado. </summary>
    int assinatura;
    /// <summary> Posição X do objeto rastreado. </summary>
    int x;
    /// <summary> Posição Y do objeto rastreado. </summary>
    int y;
    /// <summary> Largura do objeto rastreado. </summary>
    int largura;
    /// <summary> Altura do objeto rastreado. </summary>
    int altura;
    /// <summary> A idade em frames do objeto rastreado. </summary>
    int idade;

    //============================================================================================================
     /// <summary>
     /// Construtor da classe de objetos rastreados.
     /// </summary>
     /// <param name="id"> ID do objeto rastreado identificado pela PixyCam. </param>
     /// <param name="assinatura"> Assinatura de cor do objeto rastreado identificado pela PixyCam. </param>
     /// <param name="x"> Posição X do objeto rastreado identificado pela PixyCam. </param>
     /// <param name="y"> Posição Y do objeto rastreado identificado pela PixyCam. </param>
     /// <param name="largura"> Largura do objeto rastreado identificado pela PixyCam. </param>
     /// <param name="altura"> Altura do objeto rastreado identificado pela PixyCam. </param>
    //============================================================================================================
    public ObjetosRastreados(int id, int assinatura, int x, int y, int largura, int altura, int idade) {
        this.id = id;
        this.assinatura = assinatura;
        this.x = x;
        this.y = y;
        this.largura = largura;
        this.altura = altura;
        this.idade = idade;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ID do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public int GetID() {
        return id;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a assinatura de cor do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public int GetAssinatura() {
        return assinatura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a posição X do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public int GetX() {
        return x;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a posição Y do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public int GetY() {
        return y;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a largura do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public int GetLargura() {
        return largura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a altura do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public int GetAltura() {
        return altura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a idade do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public int GetIdade() {
        return idade;
    }

    //============================================================================================================
     /// <summary>
     /// Exibe as informações da classe de objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public override string ToString() {
        string texto = "ID: " + id + "| Assinatura: " + assinatura + "| X: " + x + "| Y: " + y + "| Width: " + largura + "| Height: " + altura + "| Age: " + idade;
        return texto;
    }
}
