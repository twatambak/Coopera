using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/************************************************************************************************************/
 /// <summary>
 /// A classe Fase1 é responsável pelo funcionamento geral do jogo.
 /// </summary>
/************************************************************************************************************/
public class Fase1 : MonoBehaviour {
    /// <summary> A instância de Utils. Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados. </summary>
    static InterfaceUtils instance = Utils.GetInstance();
    /// <summary> Texto de exibição de pontos do time verde. </summary>
    public Text textoPontosVerdes;
    /// <summary> Texto de exibição de pontos do time amarelo. </summary>
    public Text textoPontosAmarelos; // Texto de exibição dos pontos do time amarelo.
    /// <summary> Quantia máxima de formas. Seu valor é carregado pela função de leitura <see cref="Utils.LoadCSV(int)"/> do arquivo de configuração. </summary>
    int quantiaMaxima;
    /// <summary> Booleano que define o funcionamento do jogo. </summary>
    bool game;
    /// <summary> HUD referente ao time amarelo. </summary>
    public GameObject amareloHUD;
    /// <summary> HUD referente ao time verde. </summary>
    public GameObject verdeHUD;
    /// <summary> A <see cref="Forma"/> base para criação das formas de alvo. </summary>
    public GameObject formaBase;

    //============================================================================================================
    /// <summary>
    /// Start() é chamada antes do update do primeiro frame.
    /// Ao ser chamada, a função carrega os valores contidos no CSV de configurações e realiza a
    /// definição para as variáveis correspondentes a quantidade de formas na fase, além de chamar
    /// uma função que faz a criação de clones do prefab Forma.
    /// </summary>
    //============================================================================================================
    void Start() {
        Esperar(5);
        quantiaMaxima = instance.GetMaximoFormas();
    }


    //============================================================================================================
     /// <summary>
     /// Responsável por atualizar o jogo a cada novo frame.
     /// </summary>
    //============================================================================================================
    void Update() {
        if (game) {
            instance.CriarFormas(formaBase);
            CompararPosicao();
        }
    }

    //============================================================================================================
     /// <summary>
     /// Faz com que o programa tenha um delay relativo ao tempo informado na chamada da função.
     /// </summary>
     /// <param name="time"></param>
     /// <returns></returns>
    //============================================================================================================
    IEnumerator Esperar(int time) {
        yield return new WaitForSeconds(time);
    }


    //============================================================================================================
     /// <summary>
     /// Gerencia o início do jogo através das condições de ativamento de um botão e cria as labels
     /// de informação de pontos.
     /// </summary>
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
     /// <summary>
     ///  A função é chamada para destruir todas as formas presentes na cena e assim limpar a tela.
     /// </summary>
    //============================================================================================================
    void LimparFormas() {
        for (int i = quantiaMaxima; i < quantiaMaxima; i--) {
            Destroy(this.gameObject);
        }
    }

    //============================================================================================================
     /// <summary>
     /// Confere a posição dos objetos.
     /// </summary>
     /// <param name="posX1"></param>
     /// <param name="posY1"></param>
     /// <param name="width1"></param>
     /// <param name="height1"></param>
     /// <param name="posX2"></param>
     /// <param name="posY2"></param>
     /// <param name="width2"></param>
     /// <param name="height2"></param>
     /// <returns></returns>
    //============================================================================================================
    public bool VerificarAcerto(int posX1, int posY1, int width1, int height1, int posX2, int posY2, int width2, int height2) {
        if(posX1 < (posX2 + (width2 / 2)) || posX2< (posX1 + (width1 / 2)) || posY1 < (posY2 + (height2 / 2)) || posY2 < (posY1 + (height1 / 2))) {
            return true;
        } else {
            return false;
        }

    }

    //===================================================================================================
     /// <summary>
     /// Realiza a comparação de posição dos objetos rastreados com as formas presentes na tela. Caso a
     /// posição seja a mesma a forma é destruída. A comparação é feita caso a posição seja maior.
     /// (Atualmente o controle de comparação é realizado utilizando a posição fornecida pela Unity.
     /// Precisa ser alterado).
     /// </summary>
    //===================================================================================================
    public void CompararPosicao() {
        List<ObjetosRastreados> listaRastreados = instance.GetListaRastreados(); // A lista de objetos rastreados
        List<GameObject> listaFormas = instance.GetListaFormas(); // A lista de objetos rastreados
        for (int i = 0; i < listaRastreados.Count; i++) { // Estrutura que percorre todos os elementos da lista de objetos rastreados
            for(int j = 0; j < Utils.listaFormas.Count; i++) { // 
                if(VerificarAcerto(listaRastreados[i].GetX(), listaRastreados[i].GetY(), listaRastreados[i].GetLargura(), listaRastreados[i].GetAltura(), 1, 2,3, 4)) {
                    if(listaRastreados[i].GetAssinatura() == 2) {
                        listaFormas[j].GetComponent<Forma>().DestroiForma();
                        amareloHUD.transform.localScale = new Vector3(9, 1.24f, 1);
                    }

                    if(listaRastreados[i].GetAssinatura() == 3) {
                        Utils.listaFormas[j].GetComponent<Forma>().DestroiForma();
                    }
                }
            }
        }
    }
}
