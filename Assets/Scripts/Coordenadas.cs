using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===================================================================================================
// A classe Coordenadas está ligada ao gerenciamento dos objetos reconhecidos pela PixyCam.
//===================================================================================================
public class Coordenadas : MonoBehaviour {
    int index;
    int assinatura;
    int x;
    int y;

    /* ----------------------------------------------------------------------------------------------
     * Construtor
     --------------------------------------------------------------------------------------------- */
    public Coordenadas(int index, int assinatura, int x, int y) {
        this.index = index;
        this.assinatura = assinatura;
        this.x = x;
        this.y = y;

    }

    /* ----------------------------------------------------------------------------------------------
     * void Start()
     * Start() é chamada antes do update do primeiro frame.
     * Nada por enquanto.
     --------------------------------------------------------------------------------------------- */
    void Start() {
    }

    /* ----------------------------------------------------------------------------------------------
     * void Update()
     * Update() é é chamada no início de cada novo frame.
     * Nada por enquanto.
     --------------------------------------------------------------------------------------------- */
    void Update() {
    }
}
