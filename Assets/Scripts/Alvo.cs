using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************************************************************/
 /// <summary>
 /// A classe Alvo é responsável por definir as variáveis e comportamentos dos alvos presentes nas fases.
 /// </summary>
/************************************************************************************************************/
public class Alvo : MonoBehaviour {
    /// <summary> A instância de Utils. Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados. </summary>
    static InterfaceUtils instance = Utils.GetInstance();
    /// <summary> Ponto X da posição de origem. </summary>
    public float x;
    /// <summary> Ponto Y da posição de origem. </summary>
    public float y;
    /// <summary> Direção de movimentação no eixo X </summary>
    public float dirX;  
    /// <summary> Direção de movimentação no eixo Y </summary>
    public float dirY;
    /// <summary> Velocidade de movimentação </summary>
    public float vel;
    /// <summary> Tamanho da Alvo </summary>
    public float tam;
    /// <summary> Ponto de origem do alvo. </summary>
    public Vector2 pontoOrigem;
    /// <summary> Posição inicial do viewport (localizada no canto esquerdo inferior do objeto). </summary>
    public Vector2 pontoInicial;
    /// <summary> Posição final do viewport (localizada no canto direito superior do objeto). </summary>
    public Vector2 pontoFinal;
    /// <summary> A cor do alvo. </summary>
    public Color cor;

    //==========================================================================================================//
     /// <summary>
     /// Define as configurações iniciais do alvo.
     /// </summary>
    //==========================================================================================================//
    void Start() {
        dirX = 0.1f;
        dirY = 0.1f;
        vel = instance.CSVGetVelocidadeAlvos();
        tam = instance.CSVGetTamanhoAlvos();
        cor = this.GetComponent<Renderer>().material.color;
    }

    //==========================================================================================================//
    /// <summary>
    /// Chamada a cada novo frame. Chama a função de movimentação da alvo <see cref="Movimentar()">.
    /// </summary>
    //==========================================================================================================//
    void Update() {
        Movimentar();
        pontoOrigem = this.transform.localPosition;
        x = this.transform.localPosition.x;
        y = this.transform.localPosition.y;
        pontoInicial = PontoInicial();
        pontoFinal = PontoFinal();
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
     /// Responsável por gerenciar o movimento do alvo.
     /// </summary>
    //==========================================================================================================//
    public void Movimentar() {
        transform.Translate(Vector2.right * (dirX * vel) * Time.deltaTime); // Movimenta o quadrado na horizontal.
        transform.Translate(Vector2.up * (dirY * vel) * Time.deltaTime); // Movimenta o quadrado na vertical.
    }

    //==========================================================================================================//
     /// <summary>
     /// Recebe uma alvo e a destrói.
     /// </summary>
     /// <param name="alvo"></param>
    //==========================================================================================================//
    public void DestroiAlvo(GameObject alvo) {
        if(instance.GetQuantidadeAlvos() > 0) {
            instance.RemoveListaAlvos(alvo);
            instance.RemoveQuantidadeAlvos();
            instance.AddPontosAmarelos(1);
            Destroy(alvo);
        }
    }

    //============================================================================================================
     /// <summary>
     ///  Destrói a alvo atual.
     /// </summary>
    //============================================================================================================
    public void Destroi() {
        if(instance.GetQuantidadeAlvos() > 0) {
            Destroy(this.gameObject);
            instance.RemoveListaAlvos(this.gameObject);
            instance.RemoveQuantidadeAlvos();
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// A função é chamada quando há colisão entre objetos.
     /// A função verifica a tag do objeto com o qual está havendo colisão. Dependendo do objeto, é
     /// aplicada a direção inversa ao eixo relacionado a essa colisão. Quando a colisão acontece com
     /// um GameObject com a tag "Vertical" a direção X é invertida, quando a colisão acontece com um
     /// GameObject com a tag "Horizontal" a direção de Y é invertida, e quando a colisão acontece com
     /// outra Alvo ambas as direções são invertidas.
     /// </summary>
     /// <param name="outro"></param>
    //==========================================================================================================//
    void OnCollisionEnter(Collision outro) {
        if(outro.gameObject.tag == "Vertical") {
            dirX *= -1;
        } else if(outro.gameObject.tag == "Horizontal") {
            dirY *= -1;
        } else if(outro.gameObject.tag == "Forma"){
            dirX *= -1;
            dirY *= -1;
        } else if (outro.gameObject.tag == "Identificador") {
            instance.AddPontosAmarelos(1);
            this.Destroi();
            outro.gameObject.GetComponent<Identificador>().Destroi();
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// É chamada quando o objeto é clicado.
     /// A função verifica a quantia de elementos na cena e caso essa quantia seja maior do que 0, o
     /// objeto que foi clicado é destruído.
     /// </summary>
    //==========================================================================================================//
    void OnMouseDown() {
        Destroi();
    }

    //==========================================================================================================//
     /// <summary>
     /// ToString
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    public string Texto() {
        string texto = "ALVO => Posição Original(" + GetPontoOrigem().x + " | " + GetPontoOrigem().y + ") => Posição Inicial(" + GetPontoInicial().x + " | " + GetPontoInicial().y + ") => Posição Final(" + GetPontoFinal().x + " | " + GetPontoFinal().y + ")";
        return texto;
    }
}
