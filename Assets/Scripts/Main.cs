using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===================================================================================================
// A classe Main é responsável pelo funcionamento geral do jogo.
//===================================================================================================
public class Main : MonoBehaviour {

    public Utils utils; // Repositório de funções

    public GameObject forma; // O GameObject relacionado a Forma
    public GameObject obj; // Instância GameObject de Forma

    public static int quantiaAtual; // A quantia atual de formas na tela
    int quantiaMaxima; // A quantia máxima de formas na tela

    Material material; // O material relacionado a Forma

    public static int pontosAmarelo; // Pontos do time Amarelo
    public static int pontosVerde;// Pontos do time Verde

    public static Color novaCor; // Nova cor a ser integrada ao material da forma criada
    public static bool game = false; // Condição de funcionamento do jogo

    /* ----------------------------------------------------------------------------------------------
     * void Start()
     * Start() é chamada antes do update do primeiro frame.
     * Ao ser chamada, a função carrega os valores contidos no CSV de configurações e realiza a
     * definição para as variáveis correspondentes a quantidade de formas na fase, além de chamar
     * uma função que faz a criação de clones do prefab Forma.
    ---------------------------------------------------------------------------------------------- */
    void Start() {
        wait(5);
        quantiaMaxima = utils.toInt(utils.leArquivoConfig(2));
    }


    /* ----------------------------------------------------------------------------------------------
     * void Update()
     * Update() é chamada no início de cada novo frame.
     * Nada por enquanto;
    ---------------------------------------------------------------------------------------------- */
    void Update() {
        if (game) {
            criaFormas();
        }
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
                StartCoroutine(wait(10));
                if (quantiaAtual < quantiaMaxima) {
                    novaCor = new Vector4(Random.value, Random.value, Random.value);
                    obj = Instantiate(forma) as GameObject;
                    obj.transform.position = new Vector2 (Random.Range(-7,7), Random.Range(-3, 3));
                    material = obj.GetComponent<Renderer>().material;
                    material.color = novaCor;
                    quantiaAtual++;
                }
            }
        }
    }


    /* ----------------------------------------------------------------------------------------------
     * IEnumerator esperar(int tempo) 
     * Faz com que o programa tenha um delay relativo ao tempo informado na chamada da função.
    ---------------------------------------------------------------------------------------------- */
    IEnumerator wait(int tempo) {
        yield return new WaitForSeconds(tempo);
    }


    /* ----------------------------------------------------------------------------------------------
     * OnGUI()
     * OnGUI() é chamada para gerenciamento de objetos GUI.
     * Gerencia o início do jogo através das condições de ativamento de um botão e cria as labels
     * de informação de pontos.
    ---------------------------------------------------------------------------------------------- */
    void OnGUI() {
        if (!game) {
            if (GUI.Button(new Rect(220, 150, 200, 50), "JOGAR")) {
                game = true;
            }
        }
        GUI.Label(new Rect(10, 5, 100, 100), "PONTOS");
        GUI.Label(new Rect(100, 5, 100, 100), pontosAmarelo.ToString());

        GUI.Label(new Rect(580, 5, 100, 100), "PONTOS");
        GUI.Label(new Rect(540, 5, 100, 100), pontosVerde.ToString());
    }


    /* ----------------------------------------------------------------------------------------------
     * void limparTela()
     * A função é chamada para destruir todas as formas presentes na cena e assim limpar a tela.
    ---------------------------------------------------------------------------------------------- */
    void limparTela() {
        for (int i = quantiaMaxima; i < quantiaMaxima; i--) {
            Destroy(this.gameObject);
        }
    }
}
