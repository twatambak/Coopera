using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    int posX;
    int posY;

    //List<Color> listaCores = new List<Color> {Color.blue, Color.red };

    public GameObject forma;
    public GameObject obj;

    public static int quantiaAtual;
    int quantiaMaxima;

    Material material;

    public static int pontosAmarelo;
    public static int pontosVerde;

    public static string[] campos;

    // Start is called before the first frame update
    void Start() {
        quantiaMaxima = leArquivoConfig(2);
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
                quantiaAtual++;
            }
        }
    }

    int leArquivoConfig(int id) {
        id--;

        System.IO.StreamReader rd = new System.IO.StreamReader(@"config.txt");

        string linha = null;
        string[] linhaSeparada = null;
        List<string> linhas = new List<string>();

        // ler o conteudo da linha e add na list 
        while ((linha = rd.ReadLine()) != null) {
            linhaSeparada = linha.Split('|');                
            foreach(var item in linhaSeparada) {
                linhas.Add(item);
            }
        }

        return System.Int32.Parse(linhas[id]);
    }
}
