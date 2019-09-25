using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===================================================================================================
// A classe TrackedBlocks está ligada ao gerenciamento dos objetos reconhecidos pela PixyCam.
//===================================================================================================
public class TrackedBlocks : MonoBehaviour {
    int index;
    int signature;
    int x;
    int y;

    public TrackedBlocks(int index, int signature, int x, int y){
      this.index = index;
      this.signature = signature;
      this.x = x;
      this.y = y;
    }
}
