using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    int posX;
    int posY;

    float distX = 1.5f;
    float distY = 1.5f;

    public GameObject forma;
    public GameObject obj;
    Vector3 pos = new Vector3();

    static public int quantiaAtual;
    int quantiaMaxima;

    static public int pontosAmarelo;
    static public int pontosVerde;

    // Start is called before the first frame update
    void Start() {
        quantiaMaxima = 5;
        criaFormas();
    }

    // Update is called once per frame
    void Update() {

    }

    void criaFormas() {    
        if(quantiaAtual < quantiaMaxima) {
            for (int i = 0; i < quantiaMaxima; i++) {
                obj = Instantiate(forma) as GameObject;
                obj.transform.position = new Vector2 (Random.RandomRange(-7,7), Random.RandomRange(-3, 3)); 
                quantiaAtual++;
            }
        }
    }
}
