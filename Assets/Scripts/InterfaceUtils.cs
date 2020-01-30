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
    bool AddIdentificador(GameObject identificador);

    //==========================================================================================================//
     /// <summary>
     /// Remove o GameObject passado da lista de identificadores dos objetos rastreados pela Pixy.
     /// </summary>
     /// <param name="identificador"> O GameObject a ser removido na lista de identificadores. </param>
    //==========================================================================================================//
    void RemoveIdentificador(GameObject identificador);

    //==========================================================================================================//
     /// <summary>
     /// Cria um novo identificador com base nos dados coletados dos objetos rastreados pela Pixy. Todas as
     /// informações do objeto rastreado são aplicadas em dados correspondentes em um script aplicado no
     /// GameObject base dos identificadores. Essas informações são posteriormente acessadas utilizando os Gets()
     /// específicos através do GetComponent() para o identificador.
     /// </summary>
     /// <param name="baseIdenti"> O GameObject base usado para a criação dos identificadores. </param>
     /// <param name="id"> O ID do objeto rastreado pela Pixy. </param>
     /// <param name="assinatura"> A assinatura de cor do objeto rastreado pela Pixy. </param>
     /// <param name="x"> A posição X do objeto rastreado pela Pixy. </param>
     /// <param name="y"> A posição y do objeto rastreado pela Pixy. </param>
     /// <param name="largura"> A largura do objeto rastreado pela Pixy. </param>
     /// <param name="altura"> A altura do objeto rastreado pela Pixy. </param>
     /// <param name="idade"> A idade (quanto tempo foi rastreado) do objeto rastreado pela Pixy. </param>
    //==========================================================================================================//
    void CriarIdentificadores(GameObject baseIdenti, float id, float assinatura, float x, float y, float largura, float altura, float idade);

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

    //==========================================================================================================//
     /// <summary>
     /// Cria os alvos a serem acertados pelo jogador.
     /// </summary>
     /// <param name="baseAlvo"> A GameObject de referência para criação dos alvos. </param>
    //==========================================================================================================//
    void CriarAlvo(GameObject baseAlvo);

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

