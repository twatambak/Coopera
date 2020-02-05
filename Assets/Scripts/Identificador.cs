using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************************************************************/
 /// <summary>
 /// A classe ObjetosRastreados está ligada ao gerenciamento dos objetos reconhecidos pela PixyCam.
 /// </summary>
/************************************************************************************************************/
public class Identificador : MonoBehaviour {

    /// <summary> A instância de Utils. Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados. </summary>
    static InterfaceUtils instance = Utils.GetInstance();

    /// <summary> Assinatura de cor do objeto rastreado. </summary>
    public float assinatura;

    /// <summary> Posição X do objeto rastreado. </summary>
    public float x;

    /// <summary> Posição Y do objeto rastreado. </summary>
    public float y;

    /// <summary> Vetor de posição de origem original do objeto rastreado. </summary>
    public Vector2 pontoOrigem;

    /// <summary> Vetor de posição de origem original do objeto rastreado. </summary>
    public Vector2 pontoOrigemConvertido;

    /// <summary> Vetor de posição do início da BoundingBox (posição localizada no canto inferior esquerdo). </summary>
    public Vector2 pontoInicial;

    /// <summary> Vetor de posição do final da BoundingBox (posição localizada no canto superior direito). </summary>
    public Vector2 pontoFinal;

    /// <summary> Largura do objeto rastreado. </summary>
    public float largura;

    /// <summary> Largura do objeto rastreado. </summary>
    public float larguraConvertida;

    /// <summary> Altura do objeto rastreado. </summary>
    public float altura;

    /// <summary> Altura do objeto rastreado. </summary>
    public float alturaConvertida;

    //============================================================================================================
    /// <summary>
    /// Atualiza as informações do GameObject do identificador. Caso o objeto já exista dentro da lista de
    /// identificadores ele atualiza as informações do objeto já inserido com os novos dados. Caso o objeto não
    /// exista ele adiciona este novo elemento na lista.
    /// </summary>
    //============================================================================================================
    void Update() {
        x = this.transform.localPosition.x;
        y = this.transform.localPosition.y;
        SetPontoInicial();
        SetPontoFinal();
        SetPontoOrigem();
    }    

    //============================================================================================================
     /// <summary>
     /// Define os dados da bola.
     /// </summary>
     /// <param name="assinatura"> A assinatura da bola. </param>
     /// <param name="x"> O ponto x da bola. </param>
     /// <param name="y"> O ponto y da bola. </param>
    //============================================================================================================
    public void Bola(float assinatura, float x, float y, float largura, float altura) {
        this.assinatura = assinatura;
        this.x = x;
        this.y = y;
        this.largura = largura;
        this.altura = altura;
        pontoOrigem = new Vector2(x, y);
        pontoInicial = PontoInicial();
        pontoFinal = PontoFinal();
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a assinatura de cor da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetAssinatura() {
        return assinatura;
    }

    //============================================================================================================
     /// <summary>
     /// Define a assinatura do identificador como a nova assinatura passada como parâmetro.
     /// </summary>
     /// <param name="assinatura"> A nova assinatura a ser definida para o identificador. </param>
    //============================================================================================================
    public void SetAssinatura(float assinatura) {
        this.assinatura = assinatura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a posição X da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetX() {
        return x;
    }

    //============================================================================================================
     /// <summary>
     /// Define o ponto x do identificador como o novo ponto x passado como parâmetro.
     /// </summary>
     /// <param name="x"> O novo ponto x a ser definido para o identificador. </param>
    //============================================================================================================
    public void SetX(float x) {
        this.x = x;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a posição Y da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetY() {
        return y;
    }

    //============================================================================================================
     /// <summary>
     /// Define o ponto y do identificador como o novo ponto y passado como parâmetro.
     /// </summary>
     /// <param name="y"> O novo ponto y a ser definido para o identificador. </param>
    //============================================================================================================
    public void SetY(float y) {
        this.y = y;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a largura da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetLargura() {
        return largura;
    }

    //============================================================================================================
     /// <summary>
     /// Define a largura do identificador como a nova largura passada como parâmetro.
     /// </summary>
     /// <param name="largura"> A nova largura a ser definida para o identificador. </param>
    //============================================================================================================
    public void SetLargura(float largura) {
        this.largura = largura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a largura convertida da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetLarguraConvertida() {
        SetLarguraConvertida();
        return larguraConvertida;
    }

    //============================================================================================================
     /// <summary>
     /// Define a largura do identificador como sendo o ponto final no eixo x menos o ponto inicial do eixo x.
     /// </summary>
    //============================================================================================================
    public void SetLarguraConvertida() {
        this.larguraConvertida = pontoFinal.x - pontoInicial.x;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a altura da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetAltura() {
        return altura;
    }

    //============================================================================================================
     /// <summary>
     /// Define a altura do identificador como a nova altura passada como parâmetro.
     /// </summary>
     /// <param name="altura"> A nova altura a ser definida para o identificador. </param>
    //============================================================================================================
    public void SetAltura(float altura) {
        this.altura = altura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a altura convertida da bola.
     /// </summary>
     /// <returns> A altura convertida. </returns>
    //============================================================================================================
    public float GetAlturaConvertida() {
        SetAlturaConvertida();
        return alturaConvertida;
    }

    //============================================================================================================
     /// <summary>
     /// Define a altura do identificador como sendo o ponto final no eixo y menos o ponto inicial do eixo y.
     /// </summary>
    //============================================================================================================
    public void SetAlturaConvertida() {
        this.alturaConvertida = pontoFinal.y - pontoInicial.y;
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto de origem da bola.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector2 GetPontoOrigem() {
        return pontoOrigem;
    }

    //==========================================================================================================//
     /// <summary>
     /// Define o ponto de origem do identificador como sendo um vetor com o ponto x e y de origem da bola.
     /// </summary>
    //==========================================================================================================//
    public void SetPontoOrigem() {
        pontoOrigem = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y);
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto de origem convertido da bola.
     /// </summary>
     /// <returns> O vetor de origem convertido da bola. </returns>
    //==========================================================================================================//
    public Vector2 GetPontoOrigemConvertido() {
        SetPontoOrigemConvertido();
        return pontoOrigemConvertido;
    }

    //==========================================================================================================//
     /// <summary>
     /// Define o ponto de origem convertido chamando a função de conversão de vetor passando o ponto de origem
     /// como parâmetro.
     /// </summary>
    //==========================================================================================================//
    public void SetPontoOrigemConvertido() {
        this.pontoOrigemConvertido = ConverteVetor(pontoOrigem);
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto inicial da bola.
     /// </summary>
     /// <returns> O vetor do ponto inicial do viewport da bola. </returns>
    //==========================================================================================================//
    public Vector2 GetPontoInicial() {
        return pontoInicial;
    }

    //==========================================================================================================//
     /// <summary>
     /// Define o ponto inicial chamando a função que define o ponto inicial fazendo a conversão dos valores para
     /// o viewport.
     /// </summary>
    //==========================================================================================================//
    public void SetPontoInicial() {
        this.pontoInicial = PontoInicial();
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto final da bola.
     /// </summary>
     /// <returns> O vetor do ponto final do viewport da bola. </returns>
    //==========================================================================================================//
    public Vector2 GetPontoFinal() {
        return pontoFinal;
    }
 
    //==========================================================================================================//
     /// <summary>
     /// Define o ponto final chamando a função que define o ponto final fazendo a conversão dos valores para o
     /// viewport.
     /// </summary>
    //==========================================================================================================//
    public void SetPontoFinal() {
        this.pontoFinal = PontoFinal();
    }

    //==========================================================================================================//
     /// <summary>
     /// Converte o ponto X (localizado dentro do sistema de coordenadas da PixyCam) para o sistema de coordendas
     /// do jogo.
     /// </summary>
     /// <param name="x"> O ponto X da bola. </param>
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
     /// <param name="y"> O ponto y da bola </param>
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
     /// direito) da bola rastreada pela PixyCam para o sistema de coordenadas do jogo.
     /// </summary>
     /// <param name="objeto"> O objeto ao qual deseja-se ser feito o viewport. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector2 PontoInicial() {
        Vector2 pos = new Vector2(x, (y + altura));
        Vector2 conversao = ConverteVetor(pos);
        return conversao;
    }

    //==========================================================================================================//
     /// <summary>
     /// Realiza o Viewport (o porte das coordenadas) para o BoundingBox do ponto Y (localizado no canto superior
     /// direito) da bola rastreada pela PixyCam para o sistema de coordenadas do jogo.
     /// </summary>
     /// <param name="objeto"> O objeto ao qual deseja-se ser feito o viewport. </param>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector2 PontoFinal() {
        Vector2 pos = new Vector2((x + largura), y);
        Vector2 conversao = ConverteVetor(pos);
        return conversao;
    }

    //============================================================================================================
     /// <summary>
     /// Destrói o GameObject do identificador chamando a função que tanto destrói quanto remove o objeto da lista.
     /// </summary>
    //============================================================================================================
    public void Destroi() {
        Destroy(this.gameObject);
        //instance.RemoveIdentificador(this.gameObject);
    }

    //============================================================================================================
     /// <summary>
     /// Exibe as informações da classe da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public string Texto() {
        string texto = "BOLA => Posição Original(" + GetPontoOrigem().x + " | " + GetPontoOrigem().y + ") => Posição Inicial(" + GetPontoInicial().x + " | " + GetPontoInicial().y + ") => Posição Final(" + GetPontoFinal().x + " | " + GetPontoFinal().y + ")";
        return texto;
    }
}
