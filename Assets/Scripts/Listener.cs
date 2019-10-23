using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************************************************************
    The Listener class is responsible for communicating between the arduino board and Unity.

    -= ATTRIBUTES =-
        -> Utils utils = utility class extension, contains auxiliary functions.
        -> string[] separatedLine = vector separating the values ​​received by the serial.
        -> List<string> data = string list that stores all values ​​for tracked objects.

    -= METHODS =-
        -> List <TrackedBlocks> createTrackedList() = create and load blocks that have been tracked.
        -> void OnMessageArrived(string msg) = handles messages received by the serial portal.
        -> void OnConnectionEvent(bool success) = parses if connection to arduino has been performed.
    
------------------------------------------------------------------------------------------------------------------
    A classe Listener é responsável por realizar a comunicação entre a placa arduino e a Unity.

    -= ATRIBUTOS =-
        -> Utils utils = extensão da classe de utilidades, contém funções auxiliares.
        -> string[] separatedLine = vetor que separa os valores recebidos pelo serial. 
        -> List<string> data = lista de string que armazena todos os valores referentes aos objetos rastreados.

    -= MÉTODOS =-
        -> List<TrackedBlocks> createTrackedList() = cria e carrega os blocos que foram rastreados.
        -> void OnMessageArrived(string msg) = trata as mensagens recebidas pela portal serial.
        -> void OnConnectionEvent(bool success) = analisa se a conexão com o arduino foi executada.

*****************************************************************************************************************/
public class Listener : MonoBehaviour {
    public Utils utils;
    string[] separatedLine = null;
    List<string> data = new List<string>();

    //============================================================================================================
    // List <TrackedBlocks> createTrackedList ()
    //
    // Create the objects that are being tracked using the information contained in the first four
    // list elements that received data from objects tracked by arduino. The data information of the
    // tracked blocks are warehouses in four element structures, so we chose the first four
    // list elements for creating the tracked block within Unity. The four elements are: ID, Signature
    // position X and position Y. After adding them we remove the first four elements from the list. So the next
    // group of elements to parse represent another tracked block.
    // -----------------------------------------------------------------------------------------------------------
    // List<TrackedBlocks> createTrackedList()
    //
    // Cria os objetos que estão sendo rastreados utilizando das informações contidas nos quatro primeiros
    // elementos da lista que recebeu os dados dos objetos rastreados pelo arduino. As informações dos dados do
    // bloco rastreado são armazendas em estruturas de quatro elementos, por isso escolhemos os quatro primeiros
    // elementos da lista para a criação do bloco rastreado dentro da Unity. Os quatro elementos são: ID, assinatura
    // posição X e posição Y. Após adicioná-los removemos os quatro primeiros elementos da lista. Assim, o próximo
    // grupo de elemntos a serem analisados representam outro bloco rastreado. 
    //============================================================================================================
    List<TrackedBlocks> createTrackedList(){
        List<TrackedBlocks> trackedData = new List<TrackedBlocks>();
        if(data != null) { 
            while(data.Count > 6){
                TrackedBlocks block = new TrackedBlocks(utils.ToInt(data[0]), utils.ToInt(data[1]), utils.ToInt(data[2]), utils.ToInt(data[3]), utils.ToInt(data[4]), utils.ToInt(data[5]));
                Debug.Log(block.ToString());
                for(int i = 0; i < trackedData.Count; i++){
                    if(trackedData[i].GetIndex() == block.GetIndex()){
                        trackedData[i] = block;
                    } else {
                        trackedData.Add(block);
                    }
                }
                data.RemoveAt(5);
                data.RemoveAt(4);
                data.RemoveAt(3);
                data.RemoveAt(2);
                data.RemoveAt(1);
                data.RemoveAt(0);
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
            separatedLine = msg.Split('|');
            foreach(var item in separatedLine){
                data.Add(item);
            }
        }

        utils.UpdateArduinoTrackedData(createTrackedList());
        //Debug.Log("Mensagem: " + msg);
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
