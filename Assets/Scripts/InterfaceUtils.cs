using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/************************************************************************************************************/
 /// <summary>
 /// Interface de funcionamento da Utils.
 /// </summary>
/************************************************************************************************************/
interface InterfaceUtils {

    //==========================================================================================================//
     /// <summary>
     /// A função é utilizada para retornar um valor de configuração presente no CSV de configurações. As 
     /// configurações do CSV estão ligadas tanto a propriedades da fase quanto da conexão com o arduino. Ao se 
     /// escolher a posição referente ao valor de configuração lembre que o id está sendo decrementado no início 
     /// da função. Isso é feito para que a primeira posição relacionada aos valores seja 1. Os valores de 
     /// configuração estão sempre dispostos em posições pares exceto 0.
     /// </summary>
     /// <param name="id"> O ID da informação a ser recuperada no CSV. </param>
     /// <returns> O valor de configuração obtido de retorno no CSV. </returns>
    //==========================================================================================================//
    string LoadCSV(int id);

    //==========================================================================================================//
     /// <summary>
     /// Retorna a quantidade máxima de alvos possíveis. Essa informação está disponível na posição 1 (com o vetor
     /// iniciando em 0) do arquivo CSV.
     /// </summary>
     /// <returns> A quantidade máxima possível para os alvos. </returns>
    //==========================================================================================================//
    int CSVGetMaximoAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a velocidade dos alvos. Essa informação está disponível na posição 3 (com o vetor iniciando em 0)
     /// do arquivo CSV.
     /// </summary>
     /// <returns> A velocidade de movimento dos alvos. </returns>
    //==========================================================================================================//
    int CSVGetVelocidadeAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho dos alvos. Essa informação está disponível na posição 5 (com o vetor iniciando em 0)
     /// do arquivo CSV. 
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    int CSVGetTamanhoAlvos();

    int CSVGetAssinaturaAmarela();
    int CSVGetAssinaturaVerde();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de alvos.
     /// </summary>
     /// <returns> A lista de alvos armazenados. </returns>
    //==========================================================================================================//
    List<GameObject> GetListaAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho da lista de alvos.
     /// </summary>
     /// <returns> O tamanho da lista de alvos. </returns>
    //==========================================================================================================//
    int GetTamanhoListaAlvos();


    //==========================================================================================================//
     /// <summary>
     /// Retorna a quantidade atual de alvos.
     /// </summary>
    //==========================================================================================================//
    int GetQuantidadeAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Converte uma string para int.
     /// </summary>
     /// <param name="texto"> O texto a ser convertido. </param>
     /// <returns> O resultado da conversão do texto. </returns>
    //==========================================================================================================//
    int ToInt(string texto);

    //==========================================================================================================//
     /// <summary>
     /// Recebe o nome de uma cena e redireciona a essa cena.
     /// </summary>
     /// <param name="scene"> O nome da cena a qual se deseja ir. </param>
    //==========================================================================================================//
    void GoToScene(string scene);

    //==========================================================================================================//
     /// <summary>
     /// Cria os alvos. a serem acertadas pelo jogador.
     /// </summary>
     /// <param name="baseAlvo"> A GameObject de referência para criação dos alvos. </param>
    //==========================================================================================================//
    void CriarAlvos(GameObject baseAlvo);

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o alvo recebido na lista de alvos.
     /// </summary>
     /// <param name="alvo"> O alvo a ser adicionado na respectiva lista. </param>
    //==========================================================================================================//
    void AddListaAlvos(GameObject alvo);

    //==========================================================================================================//
     /// <summary>
     /// Remove o alvo recebido da lista de alvos.
     /// </summary>
     /// <param name="alvo"> O alvo a ser removido da respectiva lista. </param>
    //==========================================================================================================//
    void RemoveListaAlvos(GameObject alvo);

    //==========================================================================================================//
     /// <summary>
     /// Aumenta em 1 a quantidade de alvos.
     /// </summary>
    //==========================================================================================================//
    void AddQuantidadeAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Subtrai em 1 a quantidade de alvos.
     /// </summary>
    //==========================================================================================================//
    void RemoveQuantidadeAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o valor passado aos pontos do time amarelo.
     /// </summary>
     /// <param name="pontos"> Valor a ser adicionado aos pontos do time amarelo. </param>
    //==========================================================================================================//
    void AddPontosAmarelos(int pontos);

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o valor passado aos pontos do time verde.
     /// </summary>
     /// <param name="pontos"> Valor a ser adicionado aos pontos do time verde. </param>
    //==========================================================================================================//
    void AddPontosVerdes(int pontos);

    List<GameObject> GetListaIdentificadores();
    void CriarIdentificadores(GameObject baseIdenti, float id, float assinatura, float x, float y, float largura, float altura, float idade);
    void AddListaIdentificadores(GameObject identificador);
    int GetTamanhoListaIdentificadores();
    void RemoveListaIdentificadores(GameObject identificador);
}

