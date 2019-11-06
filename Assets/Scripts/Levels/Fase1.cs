using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*****************************************************************************************************************
    A classe Fase1 é responsável pelo funcionamento geral do jogo.

    -={ ATRIBUTOS }=-
        -> Utils utils = extensão da classe de utilidades, contém funções auxiliares.
        -> Text textoPontosVerdes = o texto de exibição dos pontos do time verde.
        -> Text pontosTimeAmarelo = o texto de exibição dos pontos do time amarelo.
        -> GameObject forma = o GameObject de base para forma.
        -> GameObject novaForma = a nova forma que será gerada.
        -> int quantiaAtual = a quantidade atual de formas.
        -> int quantiaMaxima = a quantidade máxima de formas.
        -> List<GameObject> listaFormas = a lista de formas já criadas.
        -> Material material = o material para cor das formas.
        -> int pontosTimeAmarelo = os pontos do time amarelo.
        -> int pontosTimeVerde = os pontos do time verde.
        -> Color novaCor = a nova cor das formas.
        -> bool game = booleano representando o funcionamento do jogo.
        -> GameObject yellowHUD = o GameObject representando a barra de HUD do time amarelo.
        -> GameObject greenHUD = o GameObject representando a barra de HUD do time verde.

    -={ MÉTODOS }=-
        -> void CreateForms()
        -> IEnumerator Wait(int time)
        -> void clearScene()
        -> public bool IsColliding(int posX1, int posY1, int width1, int height1, int posX2, int posY2, int width2, int height2)
        -> public void CompareTrackedPosition() 
*****************************************************************************************************************/
public class Fase1 : MonoBehaviour {
    public Utils utils;
    public Text textoPontosVerdes;
    public Text textoPontosAmarelos;
    public GameObject forma;
    public GameObject novaForma;
    //public static int quantiaAtual; 
    int quantiaMaxima;
    //public static List<GameObject> listaFormas = new List<GameObject>();
    Material material;

    public static Color novaCor; 
    public static bool game = false;
    public GameObject yellowHUD;
    public GameObject greenHUD;

    //============================================================================================================
    // void Start()
    // Start() é chamada antes do update do primeiro frame.
    // Ao ser chamada, a função carrega os valores contidos no CSV de configurações e realiza a
    // definição para as variáveis correspondentes a quantidade de formas na fase, além de chamar
    // uma função que faz a criação de clones do prefab Forma.
    //============================================================================================================
    void Start() {
        Wait(5);
        quantiaMaxima = utils.ToInt(utils.LoadCSV(2));
    }


    //============================================================================================================
    // void Update()
    // 
    // Responsável por atualizar o jogo a cada novo frame.
    //============================================================================================================
    void Update() {
        Forma a = new Forma();
        CompareTrackedPosition();
    }


    //============================================================================================================
    // void CreateForms()
    // A função createForms() é utlizada para fazer a criação das formas presentes na cena utilizando
    // o prefab de Forma. É verificada a quantia de formas presentes na cena e caso a quantidade for
    // menor do que o máximo estipulado (e carregado para variável através do arquivo CSV) novas
    // formas são criadas. A posição das formas é gerada aleatoriamente, assim como sua cor.
    //============================================================================================================



    //============================================================================================================
    // IEnumerator Wait(int time)
    //
    // Faz com que o programa tenha um delay relativo ao tempo informado na chamada da função.
    //============================================================================================================
    IEnumerator Wait(int time) {
        yield return new WaitForSeconds(time);
    }


    //============================================================================================================
    // OnGUI()
    //
    // Gerencia o início do jogo através das condições de ativamento de um botão e cria as labels
    // de informação de pontos.
    //============================================================================================================
    void OnGUI() {
        if (!game) {
            if (GUI.Button(new Rect(220, 150, 200, 50), "JOGAR")) {
                game = true;
            }
        }

        textoPontosAmarelos.text = "Pontos: " + Utils.pontosTimeAmarelo;
        textoPontosVerdes.text = "Pontos: " + Utils.pontosTimeVerde;
    }


    //============================================================================================================
    // void clearScene()
    //
    // A função é chamada para destruir todas as formas presentes na cena e assim limpar a tela.
    //============================================================================================================
    void clearScene() {
        for (int i = quantiaMaxima; i < quantiaMaxima; i--) {
            Destroy(this.gameObject);
        }
    }

    //============================================================================================================
    // public bool IsColliding(int posX1, int posY1, int width1, int height1, int posX2, int posY2, int width2, int height2)
    //
    // Confere a posição dos objetos.
    //============================================================================================================
    public bool IsColliding(int posX1, int posY1, int width1, int height1, int posX2, int posY2, int width2, int height2) {
        if(posX1 < (posX2 + (width2 / 2)) || posX2< (posX1 + (width1 / 2)) || posY1 < (posY2 + (height2 / 2)) || posY2 < (posY1 + (height1 / 2))) {
            return true;
        } else {
            return false;
        }

    }

    //===================================================================================================
    // void CompareTrackedPosition()
    //
    // Realiza a comparação de posição dos objetos rastreados com as formas presentes na tela. Caso a
    // posição seja a mesma a forma é destruída. A comparação é feita caso a posição seja maior.
    // (Atualmente o controle de comparação é realizado utilizando a posição fornecida pela Unity.
    // Precisa ser alterado).
    //===================================================================================================
    public void CompareTrackedPosition() {
        List<ObjetosRastreados> listaRastreados = Utils.listaRastreados; // A lista de objetos rastreados
        List<GameObject> listaFormas = Utils.listaFormas; // A lista de objetos rastreados

        for (int i = 0; i < listaRastreados.Count; i++) { // Estrutura que percorre todos os elementos da lista de objetos rastreados
            for(int j = 0; j < Utils.listaFormas.Count; i++) { // 
                if(IsColliding(listaRastreados[i].GetX(), listaRastreados[i].GetY(), listaRastreados[i].GetLargura(), listaRastreados[i].GetAltura(), 1, 2,3, 4)) {
                    if(listaRastreados[i].GetAssinatura() == 2) {
                        listaFormas[j].GetComponent<Forma>().DestroiForma();
                        yellowHUD.transform.localScale = new Vector3(9, 1.24f, 1);
                    }

                    if(listaRastreados[i].GetAssinatura() == 3) {
                        Utils.listaFormas[j].GetComponent<Forma>().DestroiForma();
                    }
                }
            }
        }
    }
}
