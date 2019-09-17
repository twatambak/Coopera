﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

//===================================================================================================
// A classe Arduino está ligada a configuração da comunicação da Unity com a placa Arduino.
//===================================================================================================
public class Arduino : MonoBehaviour {
    public Utils utils;
    SerialPort stream;

    /* ----------------------------------------------------------------------------------------------
     * void Start()
     * Start() é chamada antes do update do primeiro frame.
     * Ao iniciar o frame é realizada uma tentativa de conexão com o Arduino. Caso a conexão falhe
     * uma mensagem de erro é exibida. Caso a conexão seja bem-sucedida a comunicação entre a Unity
     * e a placa é estabelecida.
     --------------------------------------------------------------------------------------------- */
    void Start() {
        try {
            stream = new SerialPort("COM3", 115200);
            stream.Open();
        } catch (global::System.Exception) {
            Debug.LogError("Não foi possível estabelecer uma conexão com a placa Arduino. Tenha certeza de que esta está concectada corretamente. Verifique a conexão, a porta de entrada, o baud rate, e tente novamente.");
            throw;
        }

    }

    /* ----------------------------------------------------------------------------------------------
     * void Update()
     * Update() é é chamada no início de cada novo frame.
     --------------------------------------------------------------------------------------------- */
    void Update() {
    }


    /* ----------------------------------------------------------------------------------------------
     * void leituraSerial()
     * A função leituraSerial() é responsável por ler as informações passadas pelo Arduino através
     * do monitor serial, separá-las e organizar seus dados afim de fazer a leitura correta dos
     * blocos e objetos reconhecidos pela PixyCam. Para a análise das informações dos objetos 
     * reconhecidos, as informações são armazenadas em uma string, uma análise é feita e então são
     * criadas instâncias da classe Coordenadas para representar os objetos rastreados. A ordem das
     * informações coletadas de cada objeto são índice, assinatura, posição X e posição Y.
     --------------------------------------------------------------------------------------------- */
    void leituraSerial() {         
        string linha = null;

        linha = stream.ReadLine();
        string[] linhaSeparada = null;
        List<string> dados = new List<string>();

        while ((linha = stream.ReadLine()) != null) {
            linhaSeparada = linha.Split('|');
            foreach (var item in linhaSeparada) {
                dados.Add(item);
            }
        }
    }
}
