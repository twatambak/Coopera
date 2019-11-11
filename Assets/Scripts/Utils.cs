using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*****************************************************************************************************************
    A classe Utils contém alguns métodos de uso geral utilizados por classes distintas.
*****************************************************************************************************************/
public class Utils : InterfaceUtils {
    static Utils instance = null; // A instância de Utils. Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados.

    public static List<ObjetosRastreados> listaRastreados = new List<ObjetosRastreados>(); // Lista dos objetos rastreados pela PixyCam.
    public static List<GameObject> listaFormas = new List<GameObject>(); // Lista de formas geradas pelo jogo.
    public static int quantiaAtual; // Quantidade atual de formas presentes na tela.
    public GameObject formaBase; // A base utilizada para criação de novas Formas.
    public static int pontosTimeAmarelo; // Quantia de pontos do time amarelo.
    public static int pontosTimeVerde; // Quantia de pontos do time verde.
    public Forma forma; // Forma auxiliar para criação de novas Formas.


    //==========================================================================================================//
    // public static Utils GetInstance()
    //
    // Retorna uma instância de Utils.
    //==========================================================================================================//
    public static Utils GetInstance() { 
        if(instance == null) {
            return new Utils();
        } else {
            return instance;
        }
    }

    //==========================================================================================================//
    // public int LoadCSV(int id)
    //
    // A função LoadCSV(int id) é utilizada para retornar um valor de configuração presente
    // no CSV de configurações. As configurações do CSV estão ligadas tanto a propriedades da fase
    // quanto da conexão com o arduino. Ao se escolher a posição referente ao valor de configuração
    // lembrar-se que o id está sendo decrementado no início da função. Isso é feito para que a
    // primeira posição relacionada aos valores seja 1. Os valores de configuração estão sempre
    // dispostos em posições pares exceto 0.
    //==========================================================================================================//
    public string LoadCSV(int id) {
        id--;
        System.IO.StreamReader stream = new System.IO.StreamReader(@"config.txt");
        string line = null;
        string[] separatedLine = null;
        List<string> data = new List<string>();

        while ((line = stream.ReadLine()) != null) {
            separatedLine = line.Split('|');
            foreach (var item in separatedLine) {
                data.Add(item);
            }
        }
        return data[id];
    }

    //==========================================================================================================//
     // public int GetMaximoFormas()
     //
     // Retorna a quantidade máxima de formas possíveis.
    //==========================================================================================================//
    public int GetMaximoFormas() {
        return (ToInt(LoadCSV(2)));
    }

    //==========================================================================================================//
    // public int GetVelocidadeFormas()
    //
    // Retorna a velocidade das formas.
    //==========================================================================================================//
    public int GetVelocidadeFormas() {
        return (ToInt(LoadCSV(4)));
    }

    //==========================================================================================================//
    // public int GetVelocidadeFormas()
    //
    // Retorna a velocidade das formas.
    //==========================================================================================================//
    public int GetTamanhoFormas() {
        return (ToInt(LoadCSV(4)));
    }

    //==========================================================================================================//
    // public List<GameObject> GetListaFormas()
    //
    // Retorna a lista de formas.
    //==========================================================================================================//
    public List<GameObject> GetListaFormas() {
        return listaFormas;
    }

    //==========================================================================================================//
    // public List<ObjetosRastreados> GetListaRastreados()
    //
    // Retorna a lista de objetos rastreados.
    //==========================================================================================================//
    public List<ObjetosRastreados> GetListaRastreados() {
        return listaRastreados;
    }

    //==========================================================================================================//
    // public int GetQuantiaAtualFormas()
    //
    // Retorna a quantidade atual de formas.
    //==========================================================================================================//
    public int GetQuantiaAtualFormas() {
        return quantiaAtual;
    }

    //==========================================================================================================//
    // public void updateArduinoTrackedData(List<ObjetosRastreados> dados)
    //
    // A função recebe uma lista de ObjetosRastreados, refente aos objetos rastreados. A lista (listaRastreados) dentro da
    // classe atual (Utils), armazena todos os blocos rastreados. Essa lista é atualizada com as informações
    // recebidas por essa função.
    //==========================================================================================================//
    public void UpdateListaRastreados(List<ObjetosRastreados> dados) {
        listaRastreados = dados;
    }

    //==========================================================================================================//
    // public int ToInt(string texto)
    //
    // Converte uma string para inteiro.
    //==========================================================================================================//
    public int ToInt(string texto) {
        return System.Int32.Parse(texto);
    }

    //==========================================================================================================//
    // public void GoToScene(string scene);
    //
    // Recebe o nome de uma cena e redireciona a essa cena.
    //==========================================================================================================//
    public void GoToScene(string scene){
      SceneManager.LoadScene(scene);
    }

    //==========================================================================================================//
    // public void CriarFormas()
    //==========================================================================================================//
    public void CriarFormas() {
        forma.Criar();
    }

    //==========================================================================================================//
    // public void AddListaFormas(GameObject forma)
    //==========================================================================================================//
    public void AddListaFormas(GameObject forma) {
        listaFormas.Add(forma);
    }

    //==========================================================================================================//
    // public void AddQuantiaAtual()
    //==========================================================================================================//
    public void AddQuantiaAtual() {
        if (quantiaAtual < GetMaximoFormas()) {
            quantiaAtual++;
        }
    }
}
