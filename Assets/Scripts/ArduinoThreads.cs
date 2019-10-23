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

    string[] separatedLine = null;
    List<string> rawData = new List<string>();

    List<string> arduinoData = new List<string>();
    List<TrackedBlocks> trackedList = new List<TrackedBlocks>();

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
        separatedLine = arduinoSerialLine.Split('|');

        if(separatedLine != null){
          foreach(var item in separatedLine){
            count++;
          }

          if(count == 4){
            TrackedBlocks obj = new TrackedBlocks(utils.toInt(separatedLine[0]), utils.toInt(separatedLine[1]), utils.toInt(separatedLine[2]), utils.toInt(separatedLine[3]));

            /*foreach(var item in trackedList){
              if(item.getIndex() == obj.getIndex()){
                item = obj;
              } else {
                trackedList.Add(obj);
              }
            }*/

            for(int i = 0; i < trackedList.Count; i++){
              if(trackedList[i].getIndex() == obj.getIndex()){
                trackedList[i] = obj;
              } else {
                trackedList.Add(obj);
              }
            }
          }
        }
      }
      separatedLine = null;
    }
}
