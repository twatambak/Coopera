using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===================================================================================================
// A classe Main é responsável pelo funcionamento geral do jogo.
//===================================================================================================
public class Main : MonoBehaviour {
    public Utils utils;

    public GameObject forma;
    public GameObject obj;

    public static int quantiaAtual;
    int quantiaMaxima;

    Material material;

    public static int pontosAmarelo;
    public static int pontosVerde;

    /* ----------------------------------------------------------------------------------------------
     * void Start()
     * Start() é chamada antes do update do primeiro frame.
     * Ao ser chamada, a função carrega os valores contidos no CSV de configurações e realiza a
     * definição para as variáveis correspondentes a quantidade de formas na fase, além de chamar
     * uma função que faz a criação de clones do prefab Forma.
    ---------------------------------------------------------------------------------------------- */
    void Start() {
        esperar(5);
        quantiaMaxima = utils.toInt(utils.leArquivoConfig(2));
    }


    /* ----------------------------------------------------------------------------------------------
     * void Update()
     * Update() é chamada no início de cada novo frame.
     * Nada por enquanto;
    ---------------------------------------------------------------------------------------------- */
    void Update() {
        print("" + quantiaAtual);
        criaFormas();
    }


    /* ----------------------------------------------------------------------------------------------
     * void criaFormas()
     * A função criaFormas() é utlizada para fazer a criação das formas presentes na cena utilizando
     * o prefab de Forma. É verificada a quantia de formas presentes na cena e caso a quantidade for
     * menor do que o máximo estipulado (e carregado para variável através do arquivo CSV) novas
     * formas são criadas. A posição das formas é gerada aleatoriamente, assim como sua cor.
    ---------------------------------------------------------------------------------------------- */
    void criaFormas() {    
        if(quantiaAtual < quantiaMaxima) {
            for (int i = 0; i < quantiaMaxima; i++) {
                StartCoroutine(esperar(10));
                if (quantiaAtual < quantiaMaxima) {
                    Color novaCor = new Vector4(Random.value, Random.value, Random.value);
                    obj = Instantiate(forma) as GameObject;
                    obj.transform.position = new Vector2 (Random.Range(-7,7), Random.Range(-3, 3));
                    material = obj.GetComponent<Renderer>().material;
                    material.color = novaCor;
                    quantiaAtual++;
                }
            }
        }
    }

    IEnumerator esperar(int tempo) {
        yield return new WaitForSeconds(tempo);
    }
}
