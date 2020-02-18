using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HUD : MonoBehaviour {

    public void Brilha() {
        SerializedObject halo = new SerializedObject(GetComponent("Halo"));
        halo.FindProperty("m_Size").floatValue = 0.8f;
        halo.FindProperty("m_Enabled").boolValue = true;
        halo.FindProperty("m_Color").colorValue = this.GetComponent<Renderer>().material.color;
        halo.ApplyModifiedProperties();
        StartCoroutine(Wait());
        halo.FindProperty("m_Size").floatValue = 0;
        halo.FindProperty("m_Enabled").boolValue = false;
        halo.FindProperty("m_Color").colorValue = Color.white;
        halo.ApplyModifiedProperties();
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(0.3f);
    }
}
