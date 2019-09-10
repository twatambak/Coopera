using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    int posX;
    int posY;

    List<Color> listaCores = new List<Color> {Color.blue, Color.red };

    public GameObject forma;
    public GameObject obj;

    static public int quantiaAtual;
    int quantiaMaxima;

    Material material;

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
                Color novaCor = new Vector4(Random.value, Random.value, Random.value);
                obj = Instantiate(forma) as GameObject;
                obj.transform.position = new Vector2 (Random.Range(-7,7), Random.Range(-3, 3));
                material = obj.GetComponent<Renderer>().material;
                material.color = novaCor;
                //obj.GetComponent<Renderer>().material = material;
                quantiaAtual++;
            }
        }
    }
}
