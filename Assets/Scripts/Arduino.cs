using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

//===================================================================================================
// A classe Arduino está ligada a configuração da comunicação da Unity com a placa Arduino.
//===================================================================================================
public class Arduino : MonoBehaviour {

    public Utils utils;
    public SerialController serialController;

    public bool arduinoStatus = false;

    string[] seperatedLine = null;
    List<string> rawData = new List<string>();

    List<string> arduinoData = new List<string>();
    List<TrackedBlocks> trackedList = new List<TrackedBlocks>();

    string arduinoSerialLine;

    /* ----------------------------------------------------------------------------------------------
     * void Start()
     * Start() é chamada antes do update do primeiro frame.
     * Ao iniciar o frame é realizada uma tentativa de conexão com o Arduino. Caso a conexão falhe
     * uma mensagem de erro é exibida. Caso a conexão seja bem-sucedida a comunicação entre a Unity
     * e a placa é estabelecida.
     --------------------------------------------------------------------------------------------- */
    void Start() {
      arduinoStatus = true;
    }


    /* ----------------------------------------------------------------------------------------------
     * void Update()
     * Update() é é chamada no início de cada novo frame.
     --------------------------------------------------------------------------------------------- */
    void Update() {
      if(arduinoStatus){
        var taskGetTrackedBlocks = new Thread(getTrackedBlocks);
        taskGetTrackedBlocks.Start();
      } else {

      }
    }


    /* ----------------------------------------------------------------------------------------------
     --------------------------------------------------------------------------------------------- */
    public void setArduino(){
      arduinoStatus = !arduinoStatus;
    }


    /* ----------------------------------------------------------------------------------------------
     --------------------------------------------------------------------------------------------- */
    public void getTrackedBlocks(){
      arduinoSerialLine = serialController.ReadSerialMessage();
      var taskCreateTrackedBlocks = new Thread(createTrackedBlocks);
      while(arduinoSerialLine != null & arduinoSerialLine != "" & arduinoSerialLine != "error: no response"){
        taskCreateTrackedBlocks.Start();
      }
      Thread.Sleep(100);
    }


    /* ----------------------------------------------------------------------------------------------
     --------------------------------------------------------------------------------------------- */
    public void createTrackedBlocks(){
      int count = 0;
      if(arduinoSerialLine != null & arduinoSerialLine != ""){
        seperatedLine = arduinoSerialLine.Split('|');

        if(seperatedLine != null){
          foreach(var item in seperatedLine){
            count++;
          }

          if(count == 4){
            TrackedBlocks obj = new TrackedBlocks(utils.toInt(seperatedLine[0]), utils.toInt(seperatedLine[1]), utils.toInt(seperatedLine[2]), utils.toInt(seperatedLine[3]));

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
      seperatedLine = null;
      Thread.Sleep(100);
    }
}
