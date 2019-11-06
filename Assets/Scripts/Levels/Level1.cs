using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*****************************************************************************************************************
    A classe Fase1 é responsável pelo funcionamento geral do jogo.

    -={ ATRIBUTOS }=-
        -> Utils utils = extensão da classe de utilidades, contém funções auxiliares.
        -> Text greenPointsText = o texto de exibição dos pontos do time verde.
        -> Text yellowPointsText = o texto de exibição dos pontos do time amarelo.
        -> GameObject form = o GameObject de base para forma.
        -> GameObject newForm = a nova forma que será gerada.
        -> int currentAmount = a quantidade atual de formas.
        -> int maxAmount = a quantidade máxima de formas.
        -> List<GameObject> formTargets = a lista de formas já criadas.
        -> Material material = o material para cor das formas.
        -> int yellowPoints = os pontos do time amarelo.
        -> int greenPoints = os pontos do time verde.
        -> Color newColor = a nova cor das formas.
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
public class Level1 : MonoBehaviour {
    public Utils utils;
    public Text greenPointsText;
    public Text yellowPointsText;
    public GameObject form;
    public GameObject newForm;
    public static int currentAmount; 
    int maxAmount;
    public static List<GameObject> formTargets = new List<GameObject>();
    Material material;
    public static int yellowPoints;
    public static int greenPoints;
    public static Color newColor; 
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
        maxAmount = utils.ToInt(utils.LoadCSV(2));
    }


    //============================================================================================================
    // void Update()
    // 
    // Responsável por atualizar o jogo a cada novo frame.
    //============================================================================================================
    void Update() {
        CreateForms();
        CompareTrackedPosition();
    }


    //============================================================================================================
    // void CreateForms()
    // A função createForms() é utlizada para fazer a criação das formas presentes na cena utilizando
    // o prefab de Forma. É verificada a quantia de formas presentes na cena e caso a quantidade for
    // menor do que o máximo estipulado (e carregado para variável através do arquivo CSV) novas
    // formas são criadas. A posição das formas é gerada aleatoriamente, assim como sua cor.
    //============================================================================================================
    void CreateForms() {
        if(currentAmount < maxAmount) {
            for (int i = 0; i < maxAmount; i++) {
                StartCoroutine(Wait(10));
                if (currentAmount < maxAmount) {
                    newColor = new Vector4(Random.value, Random.value, Random.value);
                    newForm = Instantiate(form) as GameObject;
                    newForm.transform.position = new Vector2 (Random.Range(-7,7), Random.Range(-3, 3));
                    material = newForm.GetComponent<Renderer>().material;
                    material.color = newColor;
                    formTargets.Add(newForm);
                    currentAmount++;
                }
            }
        }
    }


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

        yellowPointsText.text = "Pontos: " + yellowPoints;
        greenPointsText.text = "Pontos: " + greenPoints;
    }


    //============================================================================================================
    // void clearScene()
    //
    // A função é chamada para destruir todas as formas presentes na cena e assim limpar a tela.
    //============================================================================================================
    void clearScene() {
        for (int i = maxAmount; i < maxAmount; i--) {
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
        List<TrackedBlocks> trackedBlocks = utils.GetTrackedBlocks(); // A lista de objetos rastreados 
        for(int i = 0; i < trackedBlocks.Count; i++) { // Estrutura que percorre todos os elementos da lista de objetos rastreados
            for(int j = 0; j < formTargets.Count; i++) { // 
                if(IsColliding(trackedBlocks[i].GetX(), trackedBlocks[i].GetY(), trackedBlocks[i].GetWidth(), trackedBlocks[i].GetHeight(), formTargets[j].dirX, )) {
                    if(trackedBlocks[i].GetSignature() == 2) {
                        formTargets[j].GetComponent<Form>().DestroyForm();
                        yellowHUD.transform.localScale = new Vector3(9, 1.24f, 1);
                    }

                    if(trackedBlocks[i].GetSignature() == 3) {
                        formTargets[j].GetComponent<Form>().DestroyForm();
                    }
                }
            }
        }
    }

}
