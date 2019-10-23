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
    int width;
    int height;

    public TrackedBlocks(int index, int signature, int x, int y, int width, int height) {
        this.index = index;
        this.signature = signature;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public int GetIndex() {
        return index;
    }

    public int GetSignature() {
        return signature;
    }

    public int GetX() {
        return x;
    }

    public int GetY() {
        return y;
    }

    public int GetWidth() {
        return width;
    }

    public int GetHeight() {
        return height;
    }

    public override string ToString() {
        string text = "ID: " + index + "| Sig: " + signature + "| X: " + x + "| Y: " + y + "| Width: " + width + "| Height: " + height;
        return text;
    }
}
