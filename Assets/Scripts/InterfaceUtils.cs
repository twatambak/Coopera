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
     /// iniciando em 0) do arquivo CSV. Como decrementamos um valor na função de leitura do CSV passamos o ID 2. 
     /// </summary>
     /// <returns> A quantidade máxima possível para os alvos. </returns>
    //==========================================================================================================//
    int CSV_GetMaximoAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a velocidade dos alvos. Essa informação está disponível na posição 3 (com o vetor iniciando em 0)
     /// do arquivo CSV. Como decrementamos um valor na função de leitura do CSV passamos o ID 4. 
     /// </summary>
     /// <returns> A velocidade de movimento dos alvos. </returns>
    //==========================================================================================================//
    int CSV_GetVelocidadeAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho dos alvos. Essa informação está disponível na posição 5 (com o vetor iniciando em 0)
     /// do arquivo CSV. Como decrementamos um valor na função de leitura do CSV passamos o ID 6. 
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    int CSV_GetTamanhoAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o valor de assinatura que representa a cor amarela (ou cor do time 1) da Pixy. Essa informação 
     /// está disponível na posição 7 (com o vetor iniciando em 0) do arquivo CSV.  Como decrementamos um valor
     /// na função de leitura do CSV passamos o ID 8.
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    int CSV_GetAssinaturaAmarela();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o valor de assinatura que representa a cor amarela (ou cor do time 1) da Pixy. Essa informação 
     /// está disponível na posição 9 (com o vetor iniciando em 0) do arquivo CSV.  Como decrementamos um valor
     /// na função de leitura do CSV passamos o ID 10.
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    int CSV_GetAssinaturaVerde();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o método de reconhecimento das bolas. Essa informação 
     /// está disponível na posição 11 (com o vetor iniciando em 0) do arquivo CSV.  Como decrementamos um valor
     /// na função de leitura do CSV passamos o ID 12.
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    string CSV_GetMetodoReconhecimento();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tempo de duração do jogo. Essa informação 
     /// está disponível na posição 13 (com o vetor iniciando em 0) do arquivo CSV.  Como decrementamos um valor
     /// na função de leitura do CSV passamos o ID 14.
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    int CSV_GetTempoJogo();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tipo dos alvos. Essa informação 
     /// está disponível na posição 15 (com o vetor iniciando em 0) do arquivo CSV.  Como decrementamos um valor
     /// na função de leitura do CSV passamos o ID 16.
     /// </summary>
     /// <returns> O tamanho dos alvos. </returns>
    //==========================================================================================================//
    string CSV_GetTipoAlvos();

    //==========================================================================================================//
    /// <summary>
    /// Retorna a lista de GameObjects criados a partir dos objetos rastreados pela Pixy. Os elementos dessa
    /// lista servem de base para analisar se bola acertou o alvo.
    /// </summary>
    /// <returns> A lista de GameObjects de identificação de posição da bola rastreada pela Pixy. </returns>
    //==========================================================================================================//
    List<GameObject> GetListaIdentificadores();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho da lista de identificadores.
     /// </summary>
     /// <returns> O tamanho da lista de identificadores. </returns>
    //==========================================================================================================//
    int GetTamanhoListaIdentificadores();

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o GameObject passado na lista de identificadores dos objetos rastreados pela Pixy.
     /// </summary>
     /// <param name="identificador"> O GameObject a ser adicionado na lista de identificadores. </param>
    //==========================================================================================================//
    void AddIdentificador(GameObject identificador);

    //==========================================================================================================//
     /// <summary>
     /// Remove o GameObject passado da lista de identificadores dos objetos rastreados pela Pixy.
     /// </summary>
     /// <param name="identificador"> O GameObject a ser removido na lista de identificadores. </param>
    //==========================================================================================================//
    void RemoveIdentificador(GameObject identificador);

    //==========================================================================================================//
     /// <summary>
     /// Limpa (remove todos os elementos) da lista de identificadores.
     /// </summary>
    //==========================================================================================================//
    void LimparIdentificadores();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho da lista de alvos.
     /// </summary>
     /// <returns> O tamanho da lista de alvos. </returns>
    //==========================================================================================================//
    int GetTamanhoListaAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o alvo passado na lista de alvos. A adição à quantidade de alvos já é realizada.
     /// </summary>
     /// <param name="alvo"> O GameObject a ser adicionado na lista de alvos. </param>
    //==========================================================================================================//
    void AddAlvo(GameObject alvo);

    //==========================================================================================================//
     /// <summary>
     /// Remove o alvo recebido da lista de alvos. A subtração da quantidade de alvos já é realizada.
     /// </summary>
     /// <param name="alvo"> O GameObejct a ser removido da lista de alvos. </param>
    //==========================================================================================================//
    void RemoveAlvo(GameObject alvo);

    void LimparAlvos();

    //==========================================================================================================//
    /// <summary>
    /// Retorna a quantidade atual de alvos.
    /// </summary>
    /// <returns></returns>
    //==========================================================================================================//
    int GetQuantidadeAlvos();

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
}

