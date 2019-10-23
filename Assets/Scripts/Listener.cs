using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************************************************************
    A classe Arduino está ligada a configuração da comunicação da Unity com a placa Arduino.
*****************************************************************************************************************/
public class Listener : MonoBehaviour {
    public Utils utils;
    string line = null;
    string[] separatedLine = null;
    List<string> data = new List<string>();
    //============================================================================================================
    // Cria os objetos que estão sendo rastreados
    //============================================================================================================
    List<TrackedBlocks> createTrackedList(){
        List<TrackedBlocks> trackedData = new List<TrackedBlocks>();
        if(data != null) { 
            while(data.Count > 4){
                TrackedBlocks block = new TrackedBlocks(utils.toInt(data[0]), utils.toInt(data[1]), utils.toInt(data[2]), utils.toInt(data[3]));
                Debug.Log(block.ToString());
                trackedData.Add(block);
                data.RemoveAt(3);
                data.RemoveAt(2);
                data.RemoveAt(1);
                data.RemoveAt(0);
            }
        }
        return trackedData;
    }

    /* ----------------------------------------------------------------------------------------------
     * void OnMessageArrived(string msg)
    --------------------------------------------------------------------------------------------- */
    void OnMessageArrived(string msg) {
        /*string[] seperatedLine = null;
        List<string> arduinoData = new List<string>();
        try {
            while (msg != null) {
                seperatedLine = msg.Split('|');
                foreach (var item in seperatedLine) {
                    arduinoData.Add(item);
                }
            }
        } catch(global :: System.Exception) {
            Debug.LogError("Não foi possível fazer essas coisas não mermão.");
            throw;
        }*/

        if(msg != null) {
            separatedLine = msg.Split('|');
            foreach(var item in separatedLine){
                data.Add(item);
            }
        }

        createTrackedList();
        //Debug.Log("Mensagem: " + msg);
    }


    /* ----------------------------------------------------------------------------------------------
     * void OnMessageArrived(string msg)
    --------------------------------------------------------------------------------------------- */
    void OnConnectionEvent(bool success) {
      Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}
