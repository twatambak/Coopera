using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixy : MonoBehaviour {

    /// <summary> A instância de Utils. Utilizada para implementar o modelo de classe único, usado para gerenciamento de dados. </summary>
    static InterfaceUtils instance = Utils.GetInstance();

    //==========================================================================================================//
     /// <summary>
     /// Cria um novo identificador com base nos dados coletados dos objetos rastreados pela Pixy. Todas as
     /// informações do objeto rastreado são aplicadas em dados correspondentes em um script aplicado no
     /// GameObject base dos identificadores. Essas informações são posteriormente acessadas utilizando os Gets()
     /// específicos através do GetComponent() para o identificador.
     /// </summary>
     /// <param name="baseIdenti"> O GameObject base usado para a criação dos identificadores. </param>
     /// <param name="assinatura"> A assinatura de cor do objeto rastreado pela Pixy. </param>
     /// <param name="x"> A posição X do objeto rastreado pela Pixy. </param>
     /// <param name="y"> A posição y do objeto rastreado pela Pixy. </param>
    //==========================================================================================================//
    public static void CriarIdentificadores(GameObject baseIdenti, float assinatura, float x, float y, float largura, float altura) {
        GameObject novoIdenti;
        novoIdenti = baseIdenti; // Para caso queira ser só um
        //novoIdenti = Instantiate(baseIdenti) as GameObject; // Para caso sejam vários.
        novoIdenti.GetComponent<Identificador>().Bola(assinatura, x, y, largura, altura);
        novoIdenti.transform.position = novoIdenti.GetComponent<Identificador>().GetPontoOrigemConvertido();
        novoIdenti.transform.localScale = new Vector3(novoIdenti.GetComponent<Identificador>().GetLarguraConvertida(), novoIdenti.GetComponent<Identificador>().GetAlturaConvertida(), 1);
        //instance.AddIdentificador(novoIdenti);
    }
}
