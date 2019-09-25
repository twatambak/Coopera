using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===================================================================================================
// A classe Arduino está ligada a configuração da comunicação da Unity com a placa Arduino.
//===================================================================================================
public class Listener : MonoBehaviour {

   /* ----------------------------------------------------------------------------------------------
   * void Start()
   * Start() é chamada antes do update do primeiro frame.
   --------------------------------------------------------------------------------------------- */
    void Start(){}


    /* ----------------------------------------------------------------------------------------------
     * void Update()
     * Update() é é chamada no início de cada novo frame.
    --------------------------------------------------------------------------------------------- */
    void Update(){}


    /* ----------------------------------------------------------------------------------------------
     * void OnMessageArrived(string msg)
    --------------------------------------------------------------------------------------------- */
    void OnMessageArrived(string msg) {
      string[] seperatedLine = null;
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
      }
    }


    /* ----------------------------------------------------------------------------------------------
     * void OnMessageArrived(string msg)
    --------------------------------------------------------------------------------------------- */
    void OnConnectionEvent(bool success) {
      Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}
