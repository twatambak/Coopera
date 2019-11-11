using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

interface InterfaceUtils {
    string LoadCSV(int id);
    int GetMaximoFormas();
    int GetVelocidadeFormas();
    int GetTamanhoFormas();
    List<GameObject> GetListaFormas();
    List<ObjetosRastreados> GetListaRastreados();
    int GetQuantiaAtualFormas();
    void UpdateListaRastreados(List<ObjetosRastreados> dados);
    int ToInt(string texto);
    void GoToScene(string scene);
    void CriarFormas(GameObject formaBase);
    void AddListaFormas(GameObject forma);
    void AddQuantiaAtual();
}

