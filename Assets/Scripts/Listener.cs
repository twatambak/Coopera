using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************************************************************
    A classe Listener é responsável por realizar a comunicação entre a placa arduino e a Unity.

    -={ ATRIBUTOS }=-
        -> Utils utils = extensão da classe de utilidades, contém funções auxiliares.
        -> string[] vetorStringSerial = vetor que separa os valores recebidos pelo serial. 
        -> List<string> dados = lista de string que armazena todos os valores referentes aos objetos rastreados.

    -={ MÉTODOS }=-
        -> List<ObjetosRastreados> createTrackedList() = cria e carrega os blocos que foram rastreados.
        -> void OnMessageArrived(string msg) = trata as mensagens recebidas pela portal serial.
        -> void OnConnectionEvent(bool success) = analisa se a conexão com o arduino foi executada.
*****************************************************************************************************************/
public class Listener : MonoBehaviour {
    public Utils utils;
    string[] vetorStringSerial = null;
    List<string> dados = new List<string>();

    //============================================================================================================
    // List<ObjetosRastreados> createTrackedList()
    //
    // Cria os objetos que estão sendo rastreados utilizando das informações contidas nos quatro primeiros
    // elementos da lista que recebeu os dados dos objetos rastreados pelo arduino. As informações dos dados do
    // bloco rastreado são armazendas em estruturas de quatro elementos, por isso escolhemos os quatro primeiros
    // elementos da lista para a criação do bloco rastreado dentro da Unity. Os quatro elementos são: ID, assinatura
    // posição X e posição Y. Após adicioná-los removemos os quatro primeiros elementos da lista. Assim, o próximo
    // grupo de elemntos a serem analisados representam outro bloco rastreado. 
    //============================================================================================================
    List<ObjetosRastreados> CriaObjetosRastreados(){
        List<ObjetosRastreados> trackedData = new List<ObjetosRastreados>();
        if(dados != null) { 
            while(dados.Count > 6){
                ObjetosRastreados block = new ObjetosRastreados(utils.ToInt(dados[0]), utils.ToInt(dados[1]), utils.ToInt(dados[2]), utils.ToInt(dados[3]), utils.ToInt(dados[4]), utils.ToInt(dados[5]));
                Debug.Log(block.ToString());
                for(int i = 0; i < trackedData.Count; i++){
                    if(trackedData[i].GetID() == block.GetID()){
                        trackedData[i] = block;
                    } else {
                        trackedData.Add(block);
                    }
                }
                for(int i = 5; i < 0; i--) { 
                    dados.RemoveAt(i);
                }
            }
        }
        return trackedData;
    }


    //============================================================================================================
    // void OnMessageArrived(string msg)
    //
    // Verifica se a mensagem recebida pela porta serial não é nula. Caso não seja, separa a mensagem em partes
    // utilizando como base de separação o carácter informado (|). Cada item separado da mensagem recebida é
    // adicionado em uma lista de strings para ser tratado posteriormente. Após todos a mensagem ter sido tratada
    // a função updateArduinoTrackedData() contida dentro da classe Utils é chamada passando como parâmetro a 
    // função createTrackedList(), a qual retorna uma lista contendo os objetos que foram rastreados.
    //============================================================================================================
    void OnMessageArrived(string msg) {
        if(msg != null) {
            vetorStringSerial = msg.Split('|');
            foreach(var item in vetorStringSerial){
                dados.Add(item);
            }
        }
        utils.UpdateListaRastreados(CriaObjetosRastreados());
    }


    //============================================================================================================
    // void OnConnectionEvent(bool success)
    //
    // Verifica se a conexão foi efetuada com sucesso ou não. Executa um comando no terminal informando o status
    // da conexão.
    //============================================================================================================
    void OnConnectionEvent(bool success){
      Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}
