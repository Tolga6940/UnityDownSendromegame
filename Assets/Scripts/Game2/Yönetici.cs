using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yönetici : MonoBehaviour
{
    public VerimDataa verimm;
    public Soru suankisoru;
    public Text Sorutexts;
    public Image Asikkis;
    public Image Bsikkis;
    public Image Csikkis;
    public Image Dsikkis;
    public AudioSource Voices;
    public GameObject oyunsonu;
    public int rndid;
    
    public void Awake()
    {
        Soruver();
    }
    public void Update()
    {
        if (verimm.Sorular.Count == 0) 
        {
            oyunsonu.SetActive(true);
        }
    }
    void Soruver() 
    {
        if (verimm.Sorular.Count >0)
        {
            rndid = Random.Range(0, verimm.Sorular.Count - 1);
            suankisoru = verimm.Sorular[rndid];
            Sorutexts.text = suankisoru.SoruText;
            Asikkis.GetComponent<Image>().sprite = suankisoru.Asikki;
            Bsikkis.GetComponent<Image>().sprite = suankisoru.Bsikki;
            Csikkis.GetComponent<Image>().sprite = suankisoru.Csikki;
            Dsikkis.GetComponent<Image>().sprite = suankisoru.Dsikki;
            Voices.clip = suankisoru.Voice;
            Voices.Play();
        }
       
        

    }
    public void cevapver(string sik)
    {
        verimm.Sorular.RemoveAt(rndid);
        if (sik==suankisoru.Cevap)
        {
            
            Debug.Log("Doğru bildiniz");
                Soruver();
        }
        else
        {
            Debug.Log("Yanlış Bildiniz");
        }
    }
}
