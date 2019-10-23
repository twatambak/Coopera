using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************************************************************
    A classe Arduino está ligada a configuração da comunicação da Unity com a placa Arduino.
*****************************************************************************************************************/
public class Listener : MonoBehaviour {
    Utils utils;

    //============================================================================================================
    // Cria os objetos que estão sendo rastreados
    //============================================================================================================
    List<TrackedBlocks> createTrackedBlocks(List<string> data){
        List<TrackedBlocks> trackedData = new List<TrackedBlocks>();
        while(data.Count >= 4){
            TrackedBlocks block = new TrackedBlocks(utils.toInt(data[0]), utils.toInt(data[1]), utils.toInt(data[2]), utils.toInt(data[3]));
            trackedData.Add(block);
            data.RemoveAt(0);
            data.RemoveAt(1);
            data.RemoveAt(2);
            data.RemoveAt(3);
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

        string line = null;
        string[] separatedLine = null;
        List<string> data = new List<string>();
        while(msg != null) {
            separatedLine = msg.Split('|');
            foreach(var item in separatedLine){
                data.Add(item);
            }
        }
        Debug.Log("Mensagem: " + msg);
    }


    /* ----------------------------------------------------------------------------------------------
     * void OnMessageArrived(string msg)
    --------------------------------------------------------------------------------------------- */
    void OnConnectionEvent(bool success) {
      Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}
