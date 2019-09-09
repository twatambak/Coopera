﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A classe Forma é responsável por definir as variáveis e comportamentos das formas presentes nas fases
public class Forma : MonoBehaviour {

    float dirX = 0.1f; // Direção de movimentação no eixo X
    float dirY = 0.1f; // Direção de movimentação no eixo Y
    float dirZ = 0.1f; // Direção de movimentação no eixo Z

    float vel = 30f; // Velocidade de movimentação

    float rotX = 0.5f; // Eixo de rotação em X
    float rotY = 0.5f; // Eixo de rotação em Y
    float rotZ = 1; // Eixo de rotação em Z

    public Forma() {

    }

    // A função Start() é chama uma única vez no ínicio do frame
    void Start() {

    }

    // A função Update() é chamada em loop a cada frame
    void Update() {

        /*if ((transform.position.x < -8) || (transform.position.x > 8)) { // Verifica as bordas do eixo X
            dirX *= -1; // Multiplica a direção por -1 para que a forma vá para direção contrária
        }

        if ((transform.position.y < -4) || (transform.position.y > 3.5)) { // Verifica as bordas do eixo Y
            dirY *= -1; // Multiplica a direção por -1 para que a forma vá para direção contrária
        }

        if ((transform.position.z < -4) || (transform.position.z > -1)) { // Verifica as bordas do eixo Z
            dirZ *= -1; // Multiplica a direção por -1 para que a forma vá para direção contrária
        }*/

        //transform.Rotate(new Vector3(rotX, 0, 0)); // Realiza a rotação da forma

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
