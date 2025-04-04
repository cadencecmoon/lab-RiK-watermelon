using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laczenie : MonoBehaviour
{
    public LayerMask mergeLayer; // Warstwa, na której znajduj¹ siê obiekty, które mog¹ byæ scalane
    public float mergeDistanceThreshold = 0.5f; // Odleg³oœæ, w jakiej obiekty s¹ uznawane za do³¹czalne
    public GameObject mergedObjectPrefab; // Prefabrykat nowego obiektu po scaleniu
    private GameObject GdzieSkrypt; // Gdzie jest skrypt
    public int punktyJakieDostaje; //Punkty wyœwietlane
                                   // public int punkty; //Te punkty dajemy
    public bool usuwamyJu¿ = false;

    void Start()
    {
        GdzieSkrypt = GameObject.Find("GdzieSkrypt");
    }

    void Update()
    {
        MergeNearbyObjects();
        
    }

    void MergeNearbyObjects()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, mergeDistanceThreshold, mergeLayer);

        if (colliders.Length >= 2)
        {
            Vector2 mergedPosition = CalculateCenterPosition(colliders);

            foreach (Collider2D collider in colliders)
            {
                Punktacja sc = GdzieSkrypt.GetComponent<Punktacja>();
                sc.wynikTen += punktyJakieDostaje;
                Destroy(collider.gameObject);
            }

            if (usuwamyJu¿ == false)
            {
                GameObject mergedObject = Instantiate(mergedObjectPrefab, mergedPosition, Quaternion.identity);
                // Mo¿esz dodaæ kod, który ustawia w³aœciwoœci nowego obiektu na podstawie obiektów scalonych
            }
            else 
            {
                Debug.Log("usuwam");
            }
        }
            
    }

    Vector2 CalculateCenterPosition(Collider2D[] colliders)
    {
        Vector2 center = Vector2.zero;

        foreach (Collider2D collider in colliders)
        {
            center += (Vector2)collider.transform.position;
            Debug.Log("Position: " + collider.transform.position);
        }

        return center / colliders.Length;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Punktacja sc = GdzieSkrypt.GetComponent<Punktacja>();
        sc.wynikTen += punktyJakieDostaje;
        

        if (col.gameObject.tag == "Metor")
        {
            Destroy(gameObject);
        }
    }

}
