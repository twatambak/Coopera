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
     /// <returns> Retorna a quantidade máxima possível para os alvos. </returns>
    //==========================================================================================================//
    int CSVGetMaximoAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a velocidade dos alvos. Essa informação está disponível na posição 3 (com o vetor iniciando em 0)
     /// do arquivo CSV.
     /// </summary>
     /// <returns> Ret </returns>
    //==========================================================================================================//
    int CSVGetVelocidadeAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho dos alvos. Essa informação está disponível na posição 5 (com o vetor iniciando em 0)
     /// do arquivo CSV. 
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    int CSVGetTamanhoAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de alvos.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    List<GameObject> GetListaAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de bolas.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    List<Bola> GetListaBolas();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de classe de alvos.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    List<ClasseAlvo> GetListaClasseAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a quantidade atual de alvos.
     /// </summary>
    //==========================================================================================================//
    int GetQuantidadeAlvos();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho da lista de bolas.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    int GetTamanhoListaBolas();

    //==========================================================================================================//
     /// <summary>
     /// Exibe o tamanho da lista de bolas.
     /// </summary>
    //==========================================================================================================//
    void PrintTamanhoListaBolas();

    //==========================================================================================================//
     /// <summary>
     /// A função recebe uma lista de bolas. A lista dentro da classe atual armazena todos os blocos rastreados. 
     /// Essa lista é atualizada com as informações recebidas por essa função.
     /// </summary>
     /// <param name="dados"> Lista de dados de bolas. </param>
    //==========================================================================================================//
    void UpdateListaBolas(List<Bola> dados);

    //==========================================================================================================//
     /// <summary>
     /// Converte uma string para int.
     /// </summary>
     /// <param name="texto"></param>
     /// <returns></returns>
    //==========================================================================================================//
    int ToInt(string texto);

    //==========================================================================================================//
     /// <summary>
     /// Recebe o nome de uma cena e redireciona a essa cena.
     /// </summary>
     /// <param name="scene"></param>
    //==========================================================================================================//
    void GoToScene(string scene);

    //==========================================================================================================//
     /// <summary>
     /// Cria as formas a serem acertadas pelo jogador.
     /// </summary>
     /// <param name="formaBase"></param>
    //==========================================================================================================//
    void CriarFormas(GameObject formaBase);

    //==========================================================================================================//
     /// <summary>
     /// Adiciona a Forma recebida na lista de formas.
     /// </summary>
     /// <param name="forma"></param>
    //==========================================================================================================//
    void AddListaFormas(GameObject forma);

    //==========================================================================================================//
     /// <summary>
     /// Remove a Forma recebida da lista de formas.
     /// </summary>
     /// <param name="forma"></param>
    //==========================================================================================================//
    void RemoveListaFormas(GameObject forma);

    //==========================================================================================================//
     /// <summary>
     /// Adiciona a classe de forma-alvo passada na lista de classe para forma-alvo.
     /// </summary>
     /// <param name="forma"></param>
    //==========================================================================================================//
    void AddListaClasseFormas(ClasseForma forma);

    //==========================================================================================================//
     /// <summary>
     /// Remove a classe de forma-alvo passada na lista de classe para forma-alvo.
     /// </summary>
     /// <param name="forma"></param>
    //==========================================================================================================//
    void RemoveListaClasseFormas(ClasseForma forma);

    //==========================================================================================================//
     /// <summary>
     /// 
     /// </summary>
     /// <param name="forma"></param>
    //==========================================================================================================//
    void RemoveListaClasseFormas(GameObject forma);

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o objeto passado na lista de objetos rastreados.
     /// </summary>
     /// <param name="rastreado"></param>
    //==========================================================================================================//
    void AddListaRastreados(ObjetosRastreados rastreado);

    //==========================================================================================================//
     /// <summary>
     /// Remove o objeto passado da lista de rastreados.
     /// </summary>
     /// <param name="rastreado"></param>
    //==========================================================================================================//
    void RemoveListaRastreados(ObjetosRastreados rastreado);

    //==========================================================================================================//
     /// <summary>
     /// Limpa os objetos rastreados pela PixyCam.
     /// </summary>
    //==========================================================================================================//
    void LimparRastreados();

    //==========================================================================================================//
    /// <summary>
    /// Acrescenta uma unidade da quantia atual de formas.
    /// </summary>
    //==========================================================================================================//
    void AddQuantiaAtual();

    //==========================================================================================================//
     /// <summary>
     /// Remove uma unidade da quantia atual de formas.
     /// </summary>
    //==========================================================================================================//
    void RemoveQuantiaAtual();

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o valor passado aos pontos do time amarelo.
     /// </summary>
    //==========================================================================================================//
    void AddPontosAmarelos(int pontos);

    //==========================================================================================================//
     /// <summary>
     /// Adiciona o valor passado aos pontos do time verde.
     /// </summary>
    //==========================================================================================================//
    void AddPontosVerdes(int pontos);

    //==========================================================================================================//
     /// <summary>
     /// Verifica a colisão entre as posições do viewport.
     /// </summary>
     /// <param name="rastreioPosInicial"></param>
     /// <param name="rastreioPosFinal"></param>
     /// <param name="formaPosInicial"></param>
     /// <param name="formaPosFinal"></param>
     /// <returns></returns>
    //==========================================================================================================//
    Boolean VerificaColisao(Vector2 rastreioPosInicial, Vector2 rastreioPosFinal, Vector2 formaPosInicial, Vector2 formaPosFinal);

    //==========================================================================================================//
     /// <summary>
     /// Verifica colisão entre a forma-alvo e o objeto rastreado.
     /// </summary>
     /// <param name="forma"></param>
     /// <param name="rastreio"></param>
     /// <returns></returns>
    //==========================================================================================================//
    Boolean VerificaColisao(ClasseForma forma, ObjetosRastreados rastreio);

    void CriaQuadrado(ObjetosRastreados rastreio);
    void MovimentaIdentificador();
}

