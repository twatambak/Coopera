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
    /// <summary> Partículas de destruição </summary>
    public GameObject particulas;
    /// <summary> Direção de movimentação no eixo X </summary>
    float dirX = 0.1f;  
    /// <summary> Direção de movimentação no eixo Y </summary>
    float dirY = 0.1f; 
    /// <summary> Velocidade de movimentação </summary>
    float vel = instance.CSVGetVelocidadeAlvos(); // 
    /// <summary> Tamanho da Alvo </summary>
    float tam = instance.CSVGetTamanhoAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Chamada a cada novo frame. Chama a função de movimentação da alvo <see cref="Movimentar()">.
     /// </summary>
    //==========================================================================================================//
    void Update() {
        Movimentar();
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
    public void DestroiAlvo() {
        if(instance.GetQuantidadeAlvos() > 0){
            instance.RemoveListaAlvos(this.gameObject);
            instance.RemoveListaClasseAlvos(this.gameObject);
            instance.RemoveQuantidadeAlvos();
            instance.AddPontosAmarelos(1);
            Destroy(this.gameObject);
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
        } else if(outro.gameObject.tag == "Alvo"){
            dirX *= -1;
            dirY *= -1;
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
        DestroiAlvo();
        //Debug.Log(this);
    }
}
