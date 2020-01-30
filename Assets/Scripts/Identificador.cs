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
    /// <summary> ID do objeto rastreado. </summary>
    public float id;
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
    /// <summary> A idade em frames do objeto rastreado. </summary>
    public float idade;

    //============================================================================================================
    //============================================================================================================
    void Update() {
        List<GameObject> identificadores = instance.GetListaIdentificadores();
        for (int i = 0; i < identificadores.Count; i++) {
            if(identificadores[i].GetComponent<Identificador>().GetID() == this.GetID()) {
                identificadores[i] = this.gameObject;
                identificadores[i].GetComponent<Identificador>().Bola(this.id, this.assinatura, this.x, this.y, this.largura, this.altura, this.idade);
            } else {
                x = this.transform.localPosition.x;
                y = this.transform.localPosition.y;
                SetPontoInicial();
                SetPontoFinal();
                SetPontoOrigem();
            }
        }
    }    

    //============================================================================================================
    //============================================================================================================
    public void Bola(float id, float assinatura, float x, float y, float largura, float altura, float idade) {
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
     /// Retorna o ID da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetID() {
        return id;
    }

    //============================================================================================================
    //============================================================================================================
    public void SetID(float id) {
        this.id = id;
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
    //============================================================================================================
    public void SetLargura(float largura) {
        this.largura = largura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a largura da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetLarguraConvertida() {
        SetLarguraConvertida();
        return larguraConvertida;
    }

    //============================================================================================================
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
    //============================================================================================================
    public void SetAltura(float altura) {
        this.altura = altura;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a altura da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetAlturaConvertida() {
        SetAlturaConvertida();
        return alturaConvertida;
    }

    //============================================================================================================
    //============================================================================================================
    public void SetAlturaConvertida() {
        this.alturaConvertida = pontoFinal.y - pontoInicial.y;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a idade (tempo que está sendo rastreada) da bola.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public float GetIdade() {
        return idade;
    }

    //============================================================================================================
    //============================================================================================================
    public void SetIdade(float idade) {
        this.idade = idade;
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
    //==========================================================================================================//
    public void SetPontoOrigem() {
        pontoOrigem = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y);
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public Vector2 GetPontoOrigemConvertido() {
        SetPontoOrigemConvertido();
        return pontoOrigemConvertido;
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public void SetPontoOrigemConvertido() {
        this.pontoOrigemConvertido = ConverteVetor(pontoOrigem);
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto inicial da bola.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector2 GetPontoInicial() {
        return pontoInicial;
    }

    //==========================================================================================================//
    //==========================================================================================================//
    public void SetPontoInicial() {
        this.pontoInicial = PontoInicial();
    }

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto final da bola.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public Vector2 GetPontoFinal() {
        return pontoFinal;
    }
 
    //==========================================================================================================//
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
    //============================================================================================================
    public void Destroi() {
        instance.RemoveIdentificador(this.gameObject);
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
