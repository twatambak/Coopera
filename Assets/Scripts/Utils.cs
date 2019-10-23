using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*****************************************************************************************************************
    A classe Utils contém alguns métodos de uso geral utilizados por classes distintas.
*****************************************************************************************************************/
public class Utils : MonoBehaviour {

    List<TrackedBlocks> arduinoData = new List<TrackedBlocks>();

  
    //============================================================================================================
    // public int loadCSV(int id)
    //
    // A função loadCSV(int id) é utilizada para retornar um valor de configuração presente
    // no CSV de configurações. As configurações do CSV estão ligadas tanto a propriedades da fase
    // quanto da conexão com o arduino. Ao se escolher a posição referente ao valor de configuração
    // lembrar-se que o id está sendo decrementado no início da função. Isso é feito para que a
    // primeira posição relacionada aos valores seja 1. Os valores de configuração estão sempre
    // dispostos em posições pares exceto 0.
    //============================================================================================================
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


    //============================================================================================================
    // public void updateArduinoTrackedData(List<TrackedBlocks> data)
    //
    // A função recebe uma lista de TrackedBlocks, refente aos objetos rastreados. A lista (arduinoData) dentro da
    // classe atual (Utils), armazena todos os blocos rastreados. Essa lista é atualizada com as informações
    // recebidas por essa função.
    //============================================================================================================
    public void UpdateArduinoTrackedData(List<TrackedBlocks> data){
        arduinoData = data;
    }

    public List<TrackedBlocks> GetTrackedBlocks() {
        return arduinoData;
    }   

    //============================================================================================================
    // public int loadCSV(int id)

    // A função loadCSV(int id) é utilizada para retornar um valor de configuração presente
    // no CSV de configurações. As configurações do CSV estão ligadas tanto a propriedades da fase
    // quanto da conexão com o arduino. Ao se escolher a posição referente ao valor de configuração
    // lembrar-se que o id está sendo decrementado no início da função. Isso é feito para que a
    // primeira posição relacionada aos valores seja 1. Os valores de configuração estão sempre
    // dispostos em posições pares exceto 0.
    //============================================================================================================
    public int ToInt(string texto) {
        return System.Int32.Parse(texto);
    }


    //============================================================================================================
    // public void goToScene(string scene);
    //
    // Recebe o nome de uma cena e redireciona a essa cena.
    //============================================================================================================
    public void GoToScene(string scene){
      SceneManager.LoadScene(scene);
    }
}
