using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/************************************************************************************************************/
 /// <summary>
 /// A classe Distracao é responsável por definir as variáveis e comportamentos das distrações presentes nas fases.
 /// </summary>
/************************************************************************************************************/
public class Distracao : MonoBehaviour {

    /// <summary> A instância de Utils. Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados. </summary>
    static InterfaceUtils instance = Utils.GetInstance();

    /// <summary> Ponto X da posição de origem. </summary>
    public float x;

    /// <summary> Ponto Y da posição de origem. </summary>
    public float y;

    /// <summary> Ponto de origem do alvo. </summary>
    public Vector2 pontoOrigem;

    /// <summary> Direção de movimentação no eixo X </summary>
    public float dirX;  

    /// <summary> Direção de movimentação no eixo Y </summary>
    public float dirY;

    /// <summary> Velocidade de movimentação </summary>
    public float vel;

    /// <summary> Tamanho da Alvo </summary>
    public float tam;

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
        vel = instance.CSV_GetVelocidadeAlvos();
        tam = instance.CSV_GetTamanhoAlvos();
        cor = Color.red;
        SerializedObject halo = new SerializedObject(GetComponent("Halo"));
        halo.FindProperty("m_Size").floatValue = 0.8f;
        halo.FindProperty("m_Enabled").boolValue = true;
        halo.FindProperty("m_Color").colorValue = Color.red;
        halo.ApplyModifiedProperties();
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
    }

    //==========================================================================================================//
     /// <summary>
     /// Cria os alvos a serem acertados pelo jogador.
     /// </summary>
     /// <param name="baseDistracao"> A GameObject de referência para criação dos alvos. </param>
    //==========================================================================================================//
    public static void CriarDistracao(GameObject baseDistracao) {
        Color novaCor;
        GameObject novaDistracao;
        Material material;
        if(instance.GetTamanhoListaDistracoes() < instance.CSV_GetMaximoDistracoes() & instance.GetQuantidadeDistracoes() < instance.CSV_GetMaximoDistracoes()) {
            for(int i = 0; i < instance.CSV_GetMaximoDistracoes(); i++) {
                if(instance.GetTamanhoListaDistracoes() < instance.CSV_GetMaximoDistracoes() & instance.GetQuantidadeDistracoes() < instance.CSV_GetMaximoDistracoes()) {
                    novaCor = Color.red;
                    novaDistracao = Instantiate(baseDistracao) as GameObject;
                    novaDistracao.transform.position = new Vector2(UnityEngine.Random.Range(-7, 7), UnityEngine.Random.Range(-3, 3));
                    novaDistracao.transform.localScale = new Vector3(instance.CSV_GetTamanhoAlvos(), instance.CSV_GetTamanhoAlvos(), 0.001f);
                    material = novaDistracao.GetComponent<Renderer>().material;
                    material.color = novaCor;
                    instance.AddDistracao(novaDistracao);
                }
            }
        }
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ponto central x original do alvo.
     /// </summary>
     /// <returns> O ponto x da posição central original do alvo. </returns>
    //============================================================================================================
    public float GetX() {
        return x;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna o ponto central y original do alvo.
     /// </summary>
     /// <returns> O ponto y da posição central original do alvo. </returns>
    //============================================================================================================
    public float GetY() {
        return y;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a posição central original do alvo.
     /// </summary>
     /// <returns> Retorna o vetor de posição de origem do alvo. </returns>
    //============================================================================================================
    public Vector2 GetPontoOrigem() {
        return pontoOrigem;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a direção de movimento no eixo x do alvo.
     /// </summary>
     /// <returns> O valor que representa o eixo x de movimentação. </returns>
    //============================================================================================================
    public float GetDirX() {
        return dirX;
    }

    //============================================================================================================
     /// <summary>
     /// Retorna a direção de movimento no eixo y do alvo.
     /// </summary>
     /// <returns> O valor que representa o eixo y de movimentação. </returns>
    //============================================================================================================
    public float GetDirY() {
        return dirY;
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

    //============================================================================================================
     /// <summary>
     /// Retorna o tamanho do alvo.
     /// </summary>
     /// <returns> O tamanho do alvo. </returns>
    //============================================================================================================
    public float GetTam() {
        return tam;
    }
          
    //============================================================================================================
     /// <summary>
     /// Retorna a velocidade de movimento do alvo.
     /// </summary>
     /// <returns> A velocidade de movimento do alvo. </returns>
    //============================================================================================================
    public float GetVel() {
        return vel;
    }

    //==========================================================================================================//
     /// <summary>
     /// Recebe uma alvo e a destrói.
     /// </summary>
     /// <param name="alvo"> O alvo a ser destruído. </param>
    //==========================================================================================================//
    public void Destroi(GameObject alvo) {
        Destroy(alvo);
        instance.RemoveAlvo(alvo);
    }

    //============================================================================================================
     /// <summary>
     ///  Destrói a alvo atual.
     /// </summary>
    //============================================================================================================
    public void Destroi() {
        Destroy(this.gameObject);
        instance.RemoveAlvo(this.gameObject);
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
    void OnCollisionEnter2D(Collision2D outro) {
        if(outro.gameObject.tag == "Vertical") {
            dirX *= -1;
        } else if(outro.gameObject.tag == "Horizontal") {
            dirY *= -1;
        } else if(outro.gameObject.tag == "Forma") {
            dirX *= -1;
            dirY *= -1;
        } else if (outro.gameObject.tag == "Identificador") {
            this.Destroi();
            outro.gameObject.transform.position = new Vector3(2000, 2000, 1);
            if(outro.gameObject.GetComponent<Identificador>().GetAssinatura() == instance.CSV_GetAssinaturaAmarela()) {
                instance.AddPontosAmarelos(-1);
            } else if(outro.gameObject.GetComponent<Identificador>().GetAssinatura() == instance.CSV_GetAssinaturaVerde()){
                instance.AddPontosVerdes(-1);
            }
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
}
