using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===================================================================================================
// A classe Forma é responsável por definir as variáveis e comportamentos das formas presentes nas fases
//===================================================================================================
public class Forma : MonoBehaviour {

    public Utils utils; // Repositório de funções

    public GameObject destructionParticles;

    float dirX = 0.1f; // Direção de movimentação no eixo X
    float dirY = 0.1f; // Direção de movimentação no eixo Y

    float vel = 30f; // Velocidade de movimentação

    float size = 1f; // Tamanho da Forma

    /* ----------------------------------------------------------------------------------------------
     * void Start()
     * Start() é chamada antes do update do primeiro frame.
     * Ao ser chamada, a função carrega os valores contidos no CSV de configurações e realiza a
     * definição para as variáveis correspondentes para a velocidade e o tamanho da forma.
    ---------------------------------------------------------------------------------------------- */
    void Start() {
        vel = utils.toInt(utils.leArquivoConfig(4));
        size = utils.toInt(utils.leArquivoConfig(6));
        transform.localScale = new Vector3(size, size, size);
    }


    /* ----------------------------------------------------------------------------------------------
     * void Update()
     * Update() é chamada no início de cada novo frame.
     * Ao começar um novo frame é definido para que a Forma se movimente respeitando a direção
     * definida em dirX para o eixo X e a direção definida em dirY para o eixo Y.
    ---------------------------------------------------------------------------------------------- */
    void Update() {
        transform.Translate(Vector2.right * (dirX * vel) * Time.deltaTime); // Movimenta o quadrado na horizontal.
        transform.Translate(Vector2.up * (dirY * vel) * Time.deltaTime); // Movimenta o quadrado na vertical.
    }


    /* ----------------------------------------------------------------------------------------------
     * void OnCollisionEnter(Collision outro)
     * OnCollisionEnter(Collision outro) é chamada quando há colisão entre objetos.
     * A função verifica a tag do objeto com o qual está havendo colisão. Dependendo do objeto, é
     * aplicada a direção inversa ao eixo relacionado a essa colisão. Quando a colisão acontece com
     * um GameObject com a tag "Vertical" a direção X é invertida, quando a colisão acontece com um
     * GameObject com a tag "Horizontal" a direção de Y é invertida, e quando a colisão acontece com
     * outra Forma ambas as direções são invertidas.
    ---------------------------------------------------------------------------------------------- */
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


    /* ----------------------------------------------------------------------------------------------
     * void OnMouseDown()
     * OnMouseDown() é chamada quando o objeto é clicado.
     * A função verifica a quantia de elementos na cena e caso essa quantia seja maior do que 0, o
     * objeto que foi clicado é destruído.
    ---------------------------------------------------------------------------------------------- */
    void OnMouseDown() {
        if (Level1.currentAmount > 0) {
            Destroy(this.gameObject);
            //destructionParticles.GetComponent<ParticleSystem.Level1Module>().startColor = new ParticleSystem.MinMaxGradient(Level1.novaCor);

            Instantiate(destructionParticles, this.transform.position, this.transform.rotation);
            Level1.currentAmount--;
            Level1.yellowPoints++;
        }
    }


}
