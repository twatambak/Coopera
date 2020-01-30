using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************************************************************/
 /// <summary>
 /// A classe Listener é responsável por realizar a comunicação entre a placa arduino e a Unity.
 /// </summary>
/************************************************************************************************************/
public class Listener : MonoBehaviour {
    /// <summary> A instância de Utils. Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados. </summary>
    static InterfaceUtils instance = Utils.GetInstance();
    /// <summary> Cores dos novos alvos. </summary>
    public GameObject baseIdentificador;
    /// <summary> Vetor de string contendo as informações recebidas pelo serial.  </summary>
    string[] vetorStringSerial = null;
    /// <summary> Lista de dados do arduino.  </summary>
    List<string> dados = new List<string>();

    //==========================================================================================================//
     /// <summary>
     /// Cria os objetos que estão sendo rastreados utilizando das informações contidas nos quatro primeiros
     /// elementos da lista que recebeu os dados dos objetos rastreados pelo arduino. As informações dos dados do
     /// bloco rastreado são armazendas em estruturas de quatro elementos, por isso escolhemos os quatro primeiros
     /// elementos da lista para a criação do bloco rastreado dentro da Unity. Os quatro elementos são: ID, assinatura
     /// posição X e posição Y. Após adicioná-los removemos os quatro primeiros elementos da lista. Assim, o próximo
     /// grupo de elementos a serem analisados representam outro bloco rastreado. 
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    void ArmazenaBolasRastreadas(){
        if(dados != null) { 
            while(dados.Count >= 7){
                instance.CriarIdentificadores(baseIdentificador, instance.ToInt(dados[0]), instance.ToInt(dados[1]), instance.ToInt(dados[2]), instance.ToInt(dados[3]), instance.ToInt(dados[4]), instance.ToInt(dados[5]), instance.ToInt(dados[6]));
                dados.Clear();
            }
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Verifica se a mensagem recebida pela porta serial não é nula. Caso não seja, separa a mensagem em partes
     /// utilizando como base de separação o carácter informado (|). Cada item separado da mensagem recebida é
     /// adicionado em uma lista de strings para ser tratado posteriormente. Após todos a mensagem ter sido tratada
     /// a função updateArduinoTrackedData() contida dentro da classe Utils é chamada passando como parâmetro a 
     /// função createTrackedList(), a qual retorna uma lista contendo os objetos que foram rastreados.
     /// </summary>
     /// <param name="msg"> A mensagem recebida pela porta serial arduino. </param>
    //==========================================================================================================//
    void OnMessageArrived(string msg) {
        if(msg != null) {
            vetorStringSerial = msg.Split('|');
            foreach(var item in vetorStringSerial){
                dados.Add(item);
            }
            ArmazenaBolasRastreadas();
        } else {
            //instance.LimparIdentificadores();
        }
    }

    //==========================================================================================================//
     /// <summary>
     /// Verifica se a conexão foi efetuada com sucesso ou não. Executa um comando no terminal informando o status
     /// da conexão.
     /// </summary>
     /// <param name="success"></param>
    //==========================================================================================================//
    void OnConnectionEvent(bool success){
      Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}
