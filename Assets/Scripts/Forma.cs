using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A classe Forma é responsável por definir as variáveis e comportamentos das formas presentes nas fases
public class Forma : MonoBehaviour {

    float dirX = 0.1f; // Direção de movimentação no eixo X
    float dirY = 0.1f; // Direção de movimentação no eixo Y
    
    float vel = 30f; // Velocidade de movimentação

    public Forma() {

    }

    // A função Start() é chama uma única vez no ínicio do frame
    void Start() {

    }

    // A função Update() é chamada em loop a cada frame
    void Update() {

        transform.Translate(Vector2.right * (dirX * vel) * Time.deltaTime); // Movimenta o quadrado na horizontal. Caso a velocidade varie de máquina para máquina: ( * Time.deltaTime)
        transform.Translate(Vector2.up * (dirY * vel) * Time.deltaTime); // Movimenta o quadrado na vertical. Caso a velocidade varie de máquina para máquina: ( * Time.deltaTime)
    }

    // Define o comportamento ao haver colisão
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
}
