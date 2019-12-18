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
     /// A função LoadCSV(int id) é utilizada para retornar um valor de configuração presente
     /// no CSV de configurações. As configurações do CSV estão ligadas tanto a propriedades da fase
     /// quanto da conexão com o arduino. Ao se escolher a posição referente ao valor de configuração
     /// lembrar-se que o id está sendo decrementado no início da função. Isso é feito para que a
     /// primeira posição relacionada aos valores seja 1. Os valores de configuração estão sempre
     /// dispostos em posições pares exceto 0.
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>
    //==========================================================================================================//
    string LoadCSV(int id);

    //==========================================================================================================//
     /// <summary>
     /// Retorna a quantidade máxima de formas possíveis.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    int GetMaximoFormas();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a velocidade das formas.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    int GetVelocidadeFormas();

    //==========================================================================================================//
     /// <summary>
     /// Retorna o tamanho das formas.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    int GetTamanhoFormas();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de formas.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    List<GameObject> GetListaFormas();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a lista de objetos rastreados.
     /// </summary>
     /// <returns></returns>
    //==========================================================================================================//
    List<ObjetosRastreados> GetListaRastreados();

    //==========================================================================================================//
     /// <summary>
     /// Retorna a quantidade atual de formas.
     /// </summary>
    //==========================================================================================================//
    int GetQuantiaAtualFormas();

    int GetTamanhoListaRastreados();

    void ExibeTamanhoListaRastreados();

    //==========================================================================================================//
     /// <summary>
     /// A função recebe uma lista de ObjetosRastreados, refente aos objetos rastreados. A lista (listaRastreados) dentro da
     /// classe atual (Utils), armazena todos os blocos rastreados. Essa lista é atualizada com as informações
     /// recebidas por essa função.
     /// </summary>
     /// <param name="dados"></param>
     /// <returns></returns>
    //==========================================================================================================//
    void UpdateListaRastreados(List<ObjetosRastreados> dados);

    //==========================================================================================================//
     /// <summary>
     /// Converte uma string para inteiro.
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
     /// Remove os 
     /// </summary>
    //==========================================================================================================//
    void RemoveRastreadosAntigos();

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
     /// Retorna o ponto X central da forma (localizado no canto superior direito da forma).
     /// </summary>
     /// <param name="forma"> A forma a ser reconhecido o ponto central X. </param>
     /// <returns></returns>
    //==========================================================================================================//
    Vector3 PontoDireitaForma(GameObject forma);

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto Y central da forma (localizado no canto inferior esquerdo da forma).
     /// </summary>
     /// <param name="forma"> A forma a ser reconhecido o ponto central Y. </param>
     /// <returns></returns>
    //==========================================================================================================//
    Vector3 PontoEsquerdaForma(GameObject forma);

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto X central do objeto rastreado (localizado no canto superior direito do objeto rastreado).
     /// </summary>
     /// <param name="rastreio"> O objeto rastreado ao qual se deseja saber o ponto central X. </param>
     /// <returns></returns>
    //==========================================================================================================//
    Vector3 PontoDireitaRastreado(ObjetosRastreados rastreio);

    //==========================================================================================================//
     /// <summary>
     /// Retorna o ponto Y central do objeto rastreado (localizado no canto inferior esquerdo do objeto rastreado).
     /// </summary>
     /// <param name="rastreio"> O objeto rastreado ao qual se deseja saber o ponto central Y. </param>
     /// <returns></returns>
    //==========================================================================================================//
    Vector3 PontoEsquerdaRastreado(ObjetosRastreados rastreio);

    //==========================================================================================================//
    //==========================================================================================================//
    Boolean VerificaColisao(Vector3 rastreioEsq, Vector3 rastreioDir, Vector3 formaEsq, Vector3 formaDir);

    //==========================================================================================================//
    //==========================================================================================================//
    Boolean VerificaColisao(GameObject forma, ObjetosRastreados rastreio);

    //==========================================================================================================//
    //==========================================================================================================//
    Vector3 RetornaVetorRastreio(ObjetosRastreados rastreio);

    //==========================================================================================================//
    //==========================================================================================================//
    Vector3 RetornaVetorForma(GameObject forma);
}

