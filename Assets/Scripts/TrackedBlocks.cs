using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===================================================================================================
// A classe TrackedBlocks está ligada ao gerenciamento dos objetos reconhecidos pela PixyCam.
//===================================================================================================
public class TrackedBlocks {
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

    public int getIndex(){
      return index;
    }

    public int getSignature(){
      return signature;
    }

    public int getX(){
      return x;
    }

    public int getY(){
      return y;
    }

    
    public override string ToString(){
        string text = "ID: " + index + "| Sig: " + signature + "| X: " + x + "| Y: " + y;
        return text;
    }
}
