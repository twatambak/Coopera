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

    string message;

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
      message = serialController.ReadSerialMessage();
      while(message != null & message != "" & message != "error: no response"){
        var taskCreateTrackedBlocks = new Thread(createTrackedBlocks());
        taskCreateTrackedBlocks.Start(message);
      }
      Thread.Sleep(100);
    }


    /* ----------------------------------------------------------------------------------------------
     --------------------------------------------------------------------------------------------- */
    public void createTrackedBlocks(string text){
      if(text != null & text != ""){
        seperatedLine = message.Split('|');
        /*foreach(var item in seperatedLine){
          Form obj = new Form();
          arduinoData.Add(item);
        }*/
        TrackedBlocks obj = new TrackedBlocks(utils.toInt(seperatedLine[0]), utils.toInt(seperatedLine[1]), utils.toInt(seperatedLine[2]), utils.toInt(seperatedLine[1]));
      }
      Thread.Sleep(100);
    }
}
