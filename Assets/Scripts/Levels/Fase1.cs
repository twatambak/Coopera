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
    /// <summary> Objeto de base para o identificador da forma de identificação dos objetos rastreados. </summary>
    public GameObject identificador;
    /// <summary> Câmera do jogo. </summary>
    public Camera cam;
    /// <summary> Teste. </summary>
    public GameObject teste;
    
    //============================================================================================================
     /// <summary>
     /// Start() é chamada antes do update do primeiro frame.
     /// Ao ser chamada, a função carrega os valores contidos no CSV de configurações e realiza a
     /// definição para as variáveis correspondentes a quantidade de formas na fase, além de chamar
     /// uma função que faz a criação de clones do prefab Forma.
     /// </summary>
    //============================================================================================================
    void Start() {
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
            instance.RemoveRastreadosAntigos();
            //PrintarPosicao();
        }
    }

    //============================================================================================================
     /// <summary>
     /// Faz com que o programa tenha um delay relativo ao tempo informado na chamada da função.
     /// </summary>
     /// <param name="time"> A quantia de tempo do delay. </param>
     /// <returns> Retorna o tempo da corrotina. </returns>
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
     /// <returns></returns>
    //============================================================================================================
    public bool VerificarAcerto(GameObject forma, ObjetosRastreados rastreio) {
        Vector3 centroRastreio = instance.RetornaVetorRastreio(rastreio);
        Vector3 centroForma = instance.RetornaVetorForma(forma);
        Vector3 rastreioDir = instance.ViewportPixyJogo_PontoDireita(rastreio);
        Vector3 rastreioEsq = instance.ViewportPixyJogo_PontoEsquerda(rastreio);
        Vector3 formaDir = instance.PontoDireitaForma(forma);
        Vector3 formaEsq = instance.PontoEsquerdaForma(forma);
        if (instance.VerificaColisao(forma, rastreio)) {
            Debug.Log("ACERTOU (Base) -> Rastreio(" + centroRastreio.x + "; " + centroRastreio.y + ") | Forma(" + centroForma.x + "; " + centroForma.y + ")");
            Debug.Log("ACERTOU (Esquerda) -> Rastreio(" + rastreioEsq.x + "; " + rastreioEsq.y + ") | Forma(" + formaEsq.x + "; " + formaEsq.y + ")");
            Debug.Log("ACERTOU (Direita) -> Rastreio(" + rastreioDir.x + "; " + rastreioDir.y + ") | Forma(" + formaDir.x + "; " + formaDir.y + ")");
            Debug.Log("------------------------------------------------------------------------------");
            return true;
        } else {
            Debug.Log("NÃO ACERTOU (Base) -> Rastreio(" + centroRastreio.x + "; " + centroRastreio.y + ") | Forma(" + centroForma.x + "; " + centroForma.y + ")");
            Debug.Log("NÃO ACERTOU (Esquerda) -> Rastreio(" + rastreioEsq.x + "; " + rastreioEsq.y + ") | Forma(" + formaEsq.x + "; " + formaEsq.y + ")");
            Debug.Log("NÃO ACERTOU (Direita) -> Rastreio(" + rastreioDir.x + "; " + rastreioDir.y + ") | Forma(" + formaDir.x + "; " + formaDir.y + ")");
            Debug.Log("------------------------------------------------------------------------------");
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
        if(listaRastreados != null && listaFormas != null) {
            for (int i = 0; i < listaRastreados.Count; i++) { // Estrutura que percorre todos os elementos da lista de objetos rastreados
                for(int j = 0; j < listaFormas.Count; j++) { 
                    if(VerificarAcerto(listaFormas[j], listaRastreados[i])) { 
                        if(listaRastreados[i].GetAssinatura() == 2) {
                            listaFormas[j].GetComponent<Forma>().DestroiForma();
                        }

                        if(listaRastreados[i].GetAssinatura() == 3) {
                            listaFormas[j].GetComponent<Forma>().DestroiForma();
                        }
                    }
                }
                instance.RemoveListaRastreados(listaRastreados[i]);
            }
        }
    }


        
    void PrintarPosicao() {
        Vector3 baseTeste = new Vector3(teste.transform.localPosition.x, teste.transform.localPosition.y, teste.transform.localPosition.z);
        Vector3 testeEsq = instance.PontoEsquerdaForma(teste);
        Vector3 testeDir = instance.PontoDireitaForma(teste);
        Debug.Log("TESTE - POSIÇÃO JOGO ==> (X " + baseTeste.x + ", Y " + baseTeste.y + " )");
        Debug.Log("TESTE - POSIÇÃO VIEWPORT ESQUERDA ==> (X " + testeEsq.x + ", Y " + testeEsq.y + " )");
        Debug.Log("TESTE - POSIÇÃO VIEWPORT DIREITA ==> (X " + testeDir.x + ", Y " + testeDir.y + " )");
    }
}
