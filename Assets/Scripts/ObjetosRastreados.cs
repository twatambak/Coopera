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
    float id;
    /// <summary> Assinatura de cor do objeto rastreado. </summary>
    float assinatura;
    /// <summary> Posição X do objeto rastreado. </summary>
    float x;
    /// <summary> Posição Y do objeto rastreado. </summary>
    float y;
    /// <summary> Vetor de posição de origem original do objeto rastreado. </summary>
    Vector2 pontoOrigem;
    /// <summary> Vetor de posição do início da BoundingBox (posição localizada no canto inferior esquerdo). </summary>
    Vector2 pontoInicial;
    /// <summary> Vetor de posição do final da BoundingBox (posição localizada no canto superior direito). </summary>
    Vector2 pontoFinal;
    /// <summary> Largura do objeto rastreado. </summary>
    float largura;
    /// <summary> Altura do objeto rastreado. </summary>
    float altura;
    /// <summary> A idade em frames do objeto rastreado. </summary>
    float idade;

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
    public ObjetosRastreados(float id, float assinatura, float x, float y, float largura, float altura, float idade) {
        this.id = id;
        this.assinatura = assinatura;
        this.x = x;
        this.y = y;
        this.largura = largura;
        this.altura = altura;
        this.idade = idade;
        pontoOrigem = new Vector2(x, y);
        pontoInicial = PontoInicial();
        pontoFinal = PontoFinal();
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ID do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetID() {
        return id;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a assinatura de cor do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetAssinatura() {
        return assinatura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a posição X do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetX() {
        return x;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a posição Y do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetY() {
        return y;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a largura do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetLargura() {
        return largura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a altura do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetAltura() {
        return altura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a idade do objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetIdade() {
        return idade;
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public Vector2 GetPontoOrigem() {
        return pontoOrigem;
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public Vector2 GetPontoInicial() {
        return pontoInicial;
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public Vector2 GetPontoFinal() {
        return pontoFinal;
    }
    
    //==========================================================================================================//
     /// <summary>
     /// Converte o ponto X (localizado dentro do sistema de coordenadas da PixyCam) para o sistema de coordendas
     /// do jogo.
     /// </summary>
     /// <param name="x"> O ponto X do objeto rastreado. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public float ConverteX(float x) {
        float convX = ((x * 16) / 300) - 8;
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
    public float ConverteY(float y) {
        float convY = ((7 * ((215 - y) / 215)) - 4);
        return convY;
    }

    //==========================================================================================================//
     /// <summary>
     /// Realiza a conversão do vetor recebido para o sistema de coordenadas do jogo.
     /// </summary>
     /// <param name="conv"> O vetor a ser convertido. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector2 ConverteVetor(Vector2 conv) {
        Vector2 converte = new Vector2(ConverteX(conv.x), ConverteY(conv.y));
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
    public Vector2 PontoInicial() {
        Vector2 pos = new Vector2((x + largura), y);
        Vector2 conversao = ConverteVetor(pos);
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
    public Vector2 PontoFinal() {
        Vector2 pos = new Vector2(x, (y + altura));
        Vector2 conversao = ConverteVetor(pos);
        return conversao;
    }

    //============================================================================================================
     /// <summary>
     /// Exibe as informações da classe de objeto rastreado.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public override string ToString() {
        string texto = "OBJETO RASTREADO (ID " + id + ") => " + "Assinatura: " + assinatura + " | X: " + x + " | Y: " + y + " | Largura: " + largura + " | Altura: " + altura + "| Frames: " + idade;
        return texto;
    }
}
