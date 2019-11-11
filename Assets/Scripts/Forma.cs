using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************************************************************/
 /// <summary>
 /// A classe Forma é responsável por definir as variáveis e comportamentos das formas presentes nas fases.
 /// </summary>
/************************************************************************************************************/
public class Forma : MonoBehaviour {
    /// <summary> Instância de utils  </summary>
    static InterfaceUtils instance = Utils.GetInstance();
    /// <summary> Partículas de destruição </summary>
    public GameObject particulas;
    /// <summary> Direção de movimentação no eixo X </summary>
    float dirX = 0.1f; // 
    /// <summary> Direção de movimentação no eixo Y </summary>
    float dirY = 0.1f; // 
    /// <summary> Velocidade de movimentação </summary>
    float vel = 0; // 
    /// <summary> Tamanho da Forma </summary>
    float tam = 1f;

    //==========================================================================================================//
    // void Start()
    //==========================================================================================================//
    void Start() {}


    //==========================================================================================================//
    // void Update()
    //==========================================================================================================//
    void Update() {
        Movimentar();
    }

    //==========================================================================================================//
     /// <summary>
     /// Responsável por gerenciar o movimento da forma.
     /// </summary>
    //==========================================================================================================//
    public void Movimentar() {
        transform.Translate(Vector2.right * (dirX * vel) * Time.deltaTime); // Movimenta o quadrado na horizontal.
        transform.Translate(Vector2.up * (dirY * vel) * Time.deltaTime); // Movimenta o quadrado na vertical.
    }

    //==========================================================================================================//
    // void DestroiForma(GameObject forma)
    //
    // Recebe uma Forma e a destrói.
    //==========================================================================================================//
    public void DestroiForma(GameObject forma) {
        if(Utils.quantiaAtual > 0) {
            Destroy(forma);
            instance.RemoveListaFormas(forma);
            instance.RemoveQuantiaAtual();
            instance.AddPontosAmarelos(1);
        }
    }

    //============================================================================================================
    // void DestroiForma()
    //
    // Destrói a forma atual.
    //============================================================================================================
    public void DestroiForma() {
        if(Utils.quantiaAtual > 0){
            Destroy(this.gameObject);
            instance.RemoveListaFormas(this.gameObject);
            instance.RemoveQuantiaAtual();
            instance.AddPontosAmarelos(1);
        }
    }

    //==========================================================================================================//
    // void OnCollisionEnter(Collision outro)
    //
    // OnCollisionEnter(Collision outro) é chamada quando há colisão entre objetos.
    // A função verifica a tag do objeto com o qual está havendo colisão. Dependendo do objeto, é
    // aplicada a direção inversa ao eixo relacionado a essa colisão. Quando a colisão acontece com
    // um GameObject com a tag "Vertical" a direção X é invertida, quando a colisão acontece com um
    // GameObject com a tag "Horizontal" a direção de Y é invertida, e quando a colisão acontece com
    // outra Forma ambas as direções são invertidas.
    //==========================================================================================================//
    void OnCollisionEnter(Collision outro) {
        if(outro.gameObject.tag == "Vertical") {
            dirX *= -1;
        } else if(outro.gameObject.tag == "Horizontal") {
            dirY *= -1;
        } else if(outro.gameObject.tag == "Forma"){
            dirX *= -1;
            dirY *= -1;
        }
    }


    //==========================================================================================================//
    // void OnMouseDown()
    // OnMouseDown() é chamada quando o objeto é clicado.
    // A função verifica a quantia de elementos na cena e caso essa quantia seja maior do que 0, o
    // objeto que foi clicado é destruído.
    //==========================================================================================================//
    void OnMouseDown() {
        if(instance.GetQuantiaAtualFormas() > 0) {
            Destroy(this.gameObject);
            //particulas.GetComponent<ParticleSystem>().startColor = this.GetComponent<Renderer>().material.color;
            //Instantiate(particulas, this.transform.position, this.transform.rotation);
            instance.RemoveListaFormas(this.gameObject);
            instance.RemoveQuantiaAtual();
            instance.AddPontosAmarelos(1);
        }
    }
}
