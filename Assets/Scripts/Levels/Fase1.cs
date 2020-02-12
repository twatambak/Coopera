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
    public Text textoPontosAmarelos;

    /// <summary> Booleano que define o funcionamento do jogo. </summary>
    public bool game;

    /// <summary> HUD referente ao time amarelo. </summary>
    public GameObject amareloHUD;

    /// <summary> HUD referente ao time verde. </summary>
    public GameObject verdeHUD;

    /// <summary> A <see cref="Alvo"/> base para criação das alvos de alvo. </summary>
    public GameObject baseAlvo;

    /// <summary> Objeto de base para o identificador da alvo de identificação dos objetos rastreados. </summary>
    public GameObject identificador;

    /// <summary> Objeto do botão de início de jogo (não está implementado). </summary>
    public Button botao;

    /// <summary> Quantidade de alvos. </summary>
    public int quantAlvos;

    /// <summary> Tamanho da lista de alvos. </summary>
    public int tamListaAlvos;

    /// <summary> Tamanho da lista de identificadores. </summary>
    public int tamListaIdentificadores;

    /// <summary> Quantia de pontos do time verde. </summary>
    public GameObject baseIdentificadorAmarelo;

    /// <summary> Quantia de pontos do time verde. </summary>
    public GameObject baseIdentificadorVerde;

    //============================================================================================================
     /// <summary>
     /// No início do script o booleano que define o funcionamento do game é definido como falso.
     /// </summary>
    //============================================================================================================
    void Start() {
        game = false;
    }

    //============================================================================================================
     /// <summary>
     /// A cada novo frame a função de criação dos alvos é chamada para garantir que a quantidade de alvos na tela
     /// seja a mesma informada no arquivo CSV e as variáveis de informação são atualizadas.
     /// </summary>
    //============================================================================================================
    void Update() {
        if(game) {
            Alvo.CriarAlvo(baseAlvo);
            quantAlvos = instance.GetQuantidadeAlvos();
            tamListaAlvos = instance.GetTamanhoListaAlvos();
            //tamListaIdentificadores = instance.GetTamanhoListaIdentificadores();
        }
    }

    //============================================================================================================
     /// <summary>
     /// Gerencia o início do jogo através das condições de ativamento de um botão e cria as labels
     /// de informação de pontos.
     /// </summary>
    //============================================================================================================
    void OnGUI() {
        if(!game) {
            if(Botao()) {
                game = true;
            }
        }
        textoPontosAmarelos.text = "Pontos: " + Utils.pontosTimeAmarelo;
        textoPontosVerdes.text = "Pontos: " + Utils.pontosTimeVerde;
    }

    //===================================================================================================
     /// <summary>
     /// Uso do botão.
     /// </summary>
     /// <returns></returns>
    //===================================================================================================
    public bool Botao() {
        return true;
    }
}
