using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiejsceZrzutu : MonoBehaviour
{
    public Vector3 worldPosition;
    public Transform punktyZrzutu;

    public GameObject[] BazaObject;

    public GameObject[] BazaCoDalej;
    public GameObject[] BazaDoZrzutu;

    public GameObject objectsDoRzutu;
    public GameObject objectsNastepny;
    public int lL = 0;

    private int i;
    
    // Start is called before the first frame update
    void Start()
    {
        objectsDoRzutu = BazaObject[2];
        BazaCoDalej[2].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position =  new Vector3(worldPosition.x ,0 ,0 );

        if (Input.GetButtonDown("Fire1"))
        {
            

            var newObj = GameObject.Instantiate(objectsDoRzutu, punktyZrzutu.position, punktyZrzutu.rotation);

            JakObjectsNastepny();
            objectsDoRzutu = objectsNastepny;

        }

    }

    void JakObjectsNastepny()
    {
        lL = Random.Range(0, 100);
        wylocznik();

        if (lL >= 0 && lL <= 15)
        {
            objectsNastepny = BazaObject[0];
            BazaCoDalej[0].SetActive(true);
        }
        else if (lL >= 16 && lL <= 35)
        {
            objectsNastepny = BazaObject[1];
            BazaCoDalej[1].SetActive(true);
        }
        else if (lL >= 36 && lL <= 55)
        {
            objectsNastepny = BazaObject[2];
            BazaCoDalej[2].SetActive(true);
        }
        else if (lL >= 56 && lL <= 70)
        {
            objectsNastepny = BazaObject[3];
            BazaCoDalej[3].SetActive(true);
        }
        else if (lL >= 71 && lL <= 82)
        {
            objectsNastepny = BazaObject[4];
            BazaCoDalej[4].SetActive(true);
        }
        else if (lL >= 83 && lL <= 90)
        {
            objectsNastepny = BazaObject[5];
            BazaCoDalej[5].SetActive(true);
        }
        else if (lL >= 91 && lL <= 97)
        {
            objectsNastepny = BazaObject[6];
            BazaCoDalej[6].SetActive(true);
        }
        else if (lL >= 98 && lL <= 100)
        {
            objectsNastepny = BazaObject[7];
            BazaCoDalej[7].SetActive(true);
        }
    }

    void wylocznik()
    {
        for (i=0; i<11; i++)
        {
            BazaCoDalej[i].SetActive(false);
            BazaDoZrzutu[i].SetActive(false);
        }

    }
}
