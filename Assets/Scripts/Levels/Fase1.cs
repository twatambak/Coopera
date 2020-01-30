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
    /// <summary> Teste. </summary>
    public Button botao;
    /// <summary> Teste. </summary>
    public int quantAlvos;
    /// <summary> Teste. </summary>
    public int tamListaAlvos;
    /// <summary> Teste. </summary>s
    public int tamListaIdentificadores;

    //============================================================================================================
    //============================================================================================================
    void Start() {
        game = false;
    }

    //============================================================================================================
    //============================================================================================================
    void Update() {
        if(game) {
            instance.CriarAlvo(baseAlvo);
            quantAlvos = instance.GetQuantidadeAlvos();
            tamListaAlvos = instance.GetTamanhoListaAlvos();
            tamListaIdentificadores = instance.GetTamanhoListaIdentificadores();

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
     /// 
     /// </summary>
     /// <returns></returns>
    //===================================================================================================
    public bool Botao() {
        return true;
    }
}
