using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kazandınız : MonoBehaviour
{
    private int pointToWin;
    private int suankipuan;
    public GameObject shapes;
    void Start()
    {
        pointToWin = shapes.transform.childCount;
    }
   
    void Update()
    {
        if (suankipuan >= pointToWin )
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void puanekle()
    {
        suankipuan++;
    }
}
