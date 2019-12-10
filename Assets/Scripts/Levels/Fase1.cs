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
            //IdentificadorRastreados();
            instance.CriarFormas(formaBase);
            CompararPosicao();
            instance.RemoveRastreadosAntigos();
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
     /// <param name="rX"> A posição X do primeiro objeto. </param>
     /// <param name="rY"> A posição Y do primeiro objeto. </param>
     /// <param name="rL"> A largura do primeiro objeto. </param> 
     /// <param name="rA"> A altura do primeiro objeto. </param>
     /// <param name="fX"> A posição X do segundo objeto. </param>
     /// <param name="fY"> A posição Y do segundo objeto. </param>
     /// <param name="fL"> A largura do segundo objeto. </param>
     /// <param name="fA"> A altura do segundo objeto. </param>
     /// <returns></returns>
    //============================================================================================================
    public bool VerificarAcerto(float rX, float rY, float rL, float rA, float fX, float fY, float fL, float fA) {
        Vector3 rastreio = new Vector3(rX, rY, 0);
        Vector3 portRastreio = instance.ViewportPixyTela(rastreio, cam); // instance.ViewportPixyParaJogo(rastreio, cam)
        Vector3 forma = new Vector3(fX, fY, 0);
        Vector3 portForma = instance.ViewportJogoTela(forma, cam);
        if(portRastreio.x < (portForma.x / 10) || portForma.x < (portRastreio.x / 10) || portRastreio.y < (portForma.y / 10) || portForma.y < (portRastreio.y / 10)) {
            Debug.Log("ACERTOU -> Rastreio(" + portRastreio.x + "; " + portRastreio.y + ") | Forma(" + portForma.x + "; " + portForma.y + ")");
            return true;
        } else {
            Debug.Log("NÃO ACERTOU -> Rastreio(" + portRastreio.x + "; " + portRastreio.y + ") | Forma(" + portForma.x + "; " + portForma.y + ")");
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
            Debug.Log("wow");
            for (int i = 0; i < listaRastreados.Count; i++) { // Estrutura que percorre todos os elementos da lista de objetos rastreados
                for(int j = 0; j < listaFormas.Count; j++) { 
                    if(VerificarAcerto(listaRastreados[i].GetX(), listaRastreados[i].GetY(), listaRastreados[i].GetLargura(), listaRastreados[i].GetAltura(), listaFormas[j].transform.position.x, listaFormas[j].transform.position.y, listaFormas[j].transform.localScale.x, listaFormas[j].transform.localScale.y)) { // listaFormas[j].transform.position.x, listaFormas[j].transform.position.y, listaFormas[j].transform.localScale.x, listaFormas[j].transform.localScale.y
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

    //===================================================================================================
     /// <summary>
     /// Desenha na tela a posição onde o objeto rastreadi está em relação a tela e ao "mundo real".
     /// </summary>
    //===================================================================================================
    public void IdentificadorRastreados() {
        List<ObjetosRastreados> listaRastreados = instance.GetListaRastreados();
        Vector3 viewPos;
        GameObject novaForma;
        Material material;
        Color novaCor;
        if(listaRastreados != null) {  
            for (int i = 0; i < listaRastreados.Count; i++) {
                Vector3 posicao = new Vector3(listaRastreados[i].GetX(), listaRastreados[i].GetY(), 0);
                viewPos = instance.ViewportPixyParaJogo(posicao, cam);
                novaForma = Instantiate(identificador) as GameObject;
                novaForma.transform.position = new Vector2(viewPos.x, viewPos.y);
                novaForma.transform.localScale = new Vector3(listaRastreados[i].GetLargura(), listaRastreados[i].GetAltura(), 1);
                novaCor = new Vector4(230, 0, 226);
                material = novaForma.GetComponent<Renderer>().material;
                material.color = novaCor;
            }
        }
    }
}
