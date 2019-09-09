using System.Collections;
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
        var direcao = new List<int> { -1, 1 };
        System.Random x = new System.Random();
        int dir = x.Next(direcao.Count);
        dirX *= direcao[dir];
        dirY *= direcao[dir];
        transform.Translate(Vector2.right * (dirX * vel) * Time.deltaTime); // Movimenta o quadrado na horizontal. Caso a velocidade varie de máquina para máquina: ( * Time.deltaTime)
        transform.Translate(Vector2.up * (dirY * vel) * Time.deltaTime); // Movimenta o quadrado na vertical. Caso a velocidade varie de máquina para máquina: ( * Time.deltaTime)
    }

    // A função Update() é chamada em loop a cada frame
    void Update() {

        //-------------------------------------------------------------------------------------------------
        // Definição de colisão com as bordas
        //-------------------------------------------------------------------------------------------------
        if ((transform.position.x < -8) || (transform.position.x > 8)) { // Verifica as bordas do eixo X
            dirX *= -1; // Multiplica a direção por -1 para que a forma vá para direção contrária
        }

        if ((transform.position.y < -4) || (transform.position.y > 3.5)) { // Verifica as bordas do eixo Y
            dirY *= -1; // Multiplica a direção por -1 para que a forma vá para direção contrária
        }

        if ((transform.position.z < -4) || (transform.position.z > -1)) { // Verifica as bordas do eixo Z
            dirZ *= -1; // Multiplica a direção por -1 para que a forma vá para direção contrária
        }
        //-------------------------------------------------------------------------------------------------

        //transform.Rotate(new Vector3(rotX, 0, 0)); // Realiza a rotação da forma

        //-------------------------------------------------------------------------------------------------
        // Movimentação da forma
        //-------------------------------------------------------------------------------------------------
        transform.Translate(Vector2.right * (dirX * vel) * Time.deltaTime); // Movimenta o quadrado na horizontal. Caso a velocidade varie de máquina para máquina: ( * Time.deltaTime)
        transform.Translate(Vector2.up * (dirY * vel) * Time.deltaTime); // Movimenta o quadrado na vertical. Caso a velocidade varie de máquina para máquina: ( * Time.deltaTime)
        //-------------------------------------------------------------------------------------------------
    }

    // Define o comportamento ao haver colisão
    void OnTriggerEnter(Collider outro) {
        print(outro.name);
        dirX *= -1;
        dirY *= -1;
    }
}
