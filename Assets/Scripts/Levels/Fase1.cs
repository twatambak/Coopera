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
    /// <summary> Quantia máxima de alvos. Seu valor é carregado pela função de leitura <see cref="Utils.LoadCSV(int)"/> do arquivo de configuração. </summary>
    int maxAlvos;
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
    /// <summary> Câmera do jogo. </summary>
    public Camera cam;
    /// <summary> Teste. </summary>
    public Button botao;
    
    //============================================================================================================
     /// <summary>
     /// Start() é chamada antes do update do primeiro frame.
     /// Ao ser chamada, a função carrega os valores contidos no CSV de configurações e realiza a
     /// definição para as variáveis correspondentes a quantidade de alvos na fase, além de chamar
     /// uma função que faz a criação de clones do prefab Alvo.
     /// </summary>
    //============================================================================================================
    void Start() {
        game = false;
        // Recebe a quantidade máxima de alvos possíveis.
        maxAlvos = instance.CSVGetMaximoAlvos();
    }


    //============================================================================================================
     /// <summary>
     /// Responsável por atualizar o jogo a cada novo frame.
     /// </summary>
    //============================================================================================================
    void Update() {
        // "Game" é uma variável que define o funcionamento do jogo. Caso ela esteja setada como FALSE o jogo não prossegue.
        if (game) {
            // Chama a função de criação das alvos passando a alvo base pública passada na engine.
            instance.CriarAlvos(baseAlvo);
            // Chama a função para comparar as posições da alvo-alvo e da bola rastreada.
            CompararPosicao();
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

    //============================================================================================================
     /// <summary>
     /// Confere a posição dos objetos.
     /// </summary>
     /// <returns></returns>
    //============================================================================================================
    public bool VerificarAcerto(GameObject alvo, Bola bola) {
        if (instance.VerificaColisao(alvo, bola)) {
            Debug.Log("ACERTOU");
            Debug.Log(alvo);
            Debug.Log(bola);
            Debug.Log("------------------------------------------------------------------------------");
            return true;
        } else {
            Debug.Log("NÃO ACERTOU");
            Debug.Log(alvo);
            Debug.Log(bola);
            Debug.Log("------------------------------------------------------------------------------");
            return false;
        }
    }

    //===================================================================================================
     /// <summary>
     /// Realiza a comparação de posição dos objetos rastreados com as alvos presentes na tela. Caso a
     /// posição seja a mesma a alvo é destruída. A comparação é feita caso a posição seja maior.
     /// (Atualmente o controle de comparação é realizado utilizando a posição fornecida pela Unity.
     /// Precisa ser alterado).
     /// </summary>
    //===================================================================================================
    public void CompararPosicao() {
        List<Bola> listaBolas = instance.GetListaBolas(); // A lista de objetos rastreados
        List<GameObject> listaAlvos = instance.GetListaAlvos(); // A lista de objetos rastreados
        if(listaBolas != null && listaAlvos != null) {
            for (int i = 0; i < listaBolas.Count; i++) { // Estrutura que percorre todos os elementos da lista de objetos rastreados
                for(int j = 0; j < listaAlvos.Count; j++) { 
                    if(VerificarAcerto(listaAlvos[j], listaBolas[i])) { 
                        if(listaBolas[i].GetAssinatura() == 2) {
                            listaAlvos[j].GetComponent<Alvo>().DestroiAlvo();
                            instance.AddPontosAmarelos(1);
                            listaAlvos.RemoveAt(j);
                        }

                        if(listaBolas[i].GetAssinatura() == 3) {
                            instance.AddPontosVerdes(1);
                            listaAlvos[j].GetComponent<Alvo>().DestroiAlvo();
                            listaAlvos.RemoveAt(j);
                        }
                    }
                }
                instance.RemoveListaBolas(listaBolas[i]);
                instance.PrintTamanhoListaBolas();
            }
        }
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
