using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rotate : MonoBehaviour
{
    public GameObject dogruform;
    private bool hareket;
    private bool bitti;
    private float startposX;
    private float startposY;

    private Vector3 resetpos;

    void Start()
    {
        resetpos = this.transform.position;
    }
    void Update()
    {
        if (bitti == false)
        {
            if (hareket)
            {
                Vector3 farepos;
                farepos = Input.mousePosition;
                farepos = Camera.main.ScreenToWorldPoint(farepos);
                this.gameObject.transform.position = new Vector3(farepos.x - startposX, farepos.y - startposY, this.gameObject.transform.position.z);
            }
        }
      
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 farepos;
            farepos = Input.mousePosition;
            farepos = Camera.main.ScreenToWorldPoint(farepos);
            startposX = farepos.x - this.transform.position.x;
            startposY = farepos.y - this.transform.position.y;
            hareket = true;
        }
    }
    private void OnMouseUp()
    {
        hareket = false;
        if (Mathf.Abs(this.transform.position.x - dogruform.transform.position.x)<= 0.5f && 
            Mathf.Abs(this.transform.position.y - dogruform.transform.position.y) <= 0.5f)
        {
            this.transform.position = new Vector3(dogruform.transform.position.x, dogruform.transform.position.y, dogruform.transform.position.z);
            bitti = true;
            GameObject.Find("Puanlayýcý").GetComponent<kazandýnýz>().puanekle();
        }
        else
        {
            this.transform.position = new Vector3(resetpos.x, resetpos.y, resetpos.z);
        }
    }
}
