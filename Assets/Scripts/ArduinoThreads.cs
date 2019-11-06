/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

//==================================================================================================
// A classe Arduino está ligada a configuração da comunicação da Unity com a placa Arduino.
//===================================================================================================
public class Arduino : MonoBehaviour {

    public Utils utils; // Referencia a classe Utils que traz algumas funções gerais necessárias para a aplicação
    public SerialController serialController;

    public bool statusArduino = false;

    string[] vetorStringSerial = null;
    List<string> rawData = new List<string>();

    List<string> listaRastreados = new List<string>();
    List<ObjetosRastreados> trackedList = new List<ObjetosRastreados>();

    string arduinoSerialLine;

    //================================================================================================
    // Start() é chamada antes do update do primeiro frame.
    // Ao iniciar o frame é realizada uma tentativa de conexão com o Arduino. Caso a conexão falhe
    // uma mensagem de erro é exibida. Caso a conexão seja bem-sucedida a comunicação entre a Unity
    // e a placa é estabelecida.
    //================================================================================================
    void Start() {
      statusArduino = true;
    }


    //================================================================================================
    // Update é chamada no início de cada novo frame.
    //================================================================================================
    void Update() {
      if(statusArduino){
        createTrackedBlocks();
      } else {

      }
    }


    //================================================================================================
    // Define o status do Arduino.
    //================================================================================================
    public void setArduino(){
      statusArduino = !statusArduino;
    }


    //================================================================================================
    // Pega os objetos rastreados
    //================================================================================================
    public void getTrackedBlocks(){
      arduinoSerialLine = serialController.ReadSerialMessage();
      var taskCreateTrackedBlocks = new Thread(createTrackedBlocks);

      while(arduinoSerialLine != null & arduinoSerialLine != "" & arduinoSerialLine != "error: no response"){
        taskCreateTrackedBlocks.Start();
      }
    }


    //================================================================================================
    // Cria os objetos trackeados.
    //================================================================================================
    public void createTrackedBlocks(){
      int count = 0;
      if(arduinoSerialLine != null & arduinoSerialLine != ""){
        vetorStringSerial = arduinoSerialLine.Split('|');

        if(vetorStringSerial != null){
          foreach(var item in vetorStringSerial){
            count++;
          }

          if(count == 4){
            ObjetosRastreados obj = new ObjetosRastreados(utils.ToInt(vetorStringSerial[0]), utils.ToInt(vetorStringSerial[1]), utils.ToInt(vetorStringSerial[2]), utils.ToInt(vetorStringSerial[3]));



            for(int i = 0; i < trackedList.Count; i++){
              if(trackedList[i].GetID() == obj.GetID()){
                trackedList[i] = obj;
              } else {
                trackedList.Add(obj);
              }
            }
          }
        }
      }
      vetorStringSerial = null;
    }
}
*/