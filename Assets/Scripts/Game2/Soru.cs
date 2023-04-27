using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Soru 
{
    public string SoruText;
    public Sprite Asikki;
    public Sprite Bsikki;
    public Sprite Csikki;
    public Sprite Dsikki;
    public string Cevap;
    public AudioClip Voice;


    void sorular(string sorutext, Sprite asikki, Sprite bsikki, Sprite csikki, Sprite dsikki, string cevap, AudioClip voice)
    {
        SoruText = sorutext;
        Asikki = asikki;
        Bsikki = bsikki;
        Csikki = csikki;
        Dsikki = dsikki;
        Cevap = cevap;
        Voice = voice;
    }
}
