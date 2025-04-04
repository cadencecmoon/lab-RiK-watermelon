using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Data;


public class Punktacja : MonoBehaviour
{
    [Header("UI Components")]
    //public int punkty = 0;
    public GameObject menuPause;
    public GameObject menuGame;
    public GameObject tablicaWynikow;
    public GameObject KoniecGry;
    public GameObject Opisy;

    public GameObject Gracz;
    public Text wynik;
    public Text wynikKoniec;
    public int wynikTen;
    public Text[] tablicaWText;
    private int ileWynikow = 8;

    [Header("High Scores Settings")]
    public List<string> tablicaWynikpw = new List<string>();
    public List<int> tablicaWynikowInt = new List<int>();
    public string highScoresKeyDM = "highScoresKeyDM";

    private static UnityEvent saveScores = new UnityEvent();


    //public int[] tablicaWynikowInt;

    private void Awake()
    {
        saveScores.AddListener(CheckAndSaveHighScore);
    }


    // Start is called before the first frame update
    void Start()
    {
        wynikTen = 0;
        LoadHighScores();
        DisplayHighScores();
        
    }


    // Update is called once per frame
    void Update()
    {
        zmianaWynikuAktualnego();
    }

    public void PauseMenu()
    {
        menuPause.SetActive(true);
        menuGame.SetActive(false);
        tablicaWynikow.SetActive(false);
        Gracz.SetActive(false);
        Time.timeScale = 0;
    }

    public void ReturPauseMenu()
    {
        menuPause.SetActive(false);
        menuGame.SetActive(true);
        tablicaWynikow.SetActive(false);
        Opisy.SetActive(false);
        Gracz.SetActive(true);
        Time.timeScale = 1;
    }

    public void Tablica()
    {
        menuPause.SetActive(false);
        menuGame.SetActive(false);
        tablicaWynikow.SetActive(true);
        Gracz.SetActive(false);
        Time.timeScale = 0;
    }

    public void OpisyMenu()
    {
        menuPause.SetActive(false);
        Opisy.SetActive(true);
    }


    public void Koniec()
    {
        menuGame.SetActive(false);
        Gracz.SetActive(false);
        KoniecGry.SetActive(true);
        
        wynikKoniec.text = "" + wynikTen;
        Time.timeScale = 0;
    }



    public void GoRestart()
    {
        Application.LoadLevel(0);
        Debug.Log("Restart");
    }
    
    public void GoEnd()
    {
        Application.Quit();
        Debug.Log("Koniec");
    }

    private void zmianaWynikuAktualnego()
    {
        wynik.text = "" + wynikTen;


    }


    private void CheckAndSaveHighScore()
    {
        if (tablicaWynikowInt.Count < 8 || wynikTen > tablicaWynikowInt[tablicaWynikowInt.Count - 1])
        {
            // Dodanie wyniku, jeœli kwalifikuje siê jako najlepszy
            tablicaWynikowInt.Add(wynikTen);
            tablicaWynikowInt.Sort((a, b) => b.CompareTo(a)); // Sortowanie malej¹co

            if (tablicaWynikowInt.Count > ileWynikow)
            {
                tablicaWynikowInt.RemoveAt(ileWynikow); 
            }

            SaveHighScores();
            DisplayHighScores();
        }

        // Reset wyniku po sprawdzeniu
        wynikTen = 0;
    }

    private void SaveHighScores()
    {
        for (int i = 0; i < tablicaWynikowInt.Count; i++)
        {
            PlayerPrefs.SetInt(highScoresKeyDM + i, tablicaWynikowInt[i]);
        }
        PlayerPrefs.Save();
    }

    private void LoadHighScores()
    {
        tablicaWynikowInt.Clear();

        for (int i = 0; i < ileWynikow; i++)
        {
            if (PlayerPrefs.HasKey(highScoresKeyDM + i))
            {
                tablicaWynikowInt.Add(PlayerPrefs.GetInt(highScoresKeyDM + i));
            }
        }

        while (tablicaWynikowInt.Count < ileWynikow)
        {
            tablicaWynikowInt.Add(0); // Domyœlnie zero, jeœli brak zapisanych wyników
        }
    }

    private void DisplayHighScores()
    {
        
            
            for (int i = 0; i < tablicaWynikowInt.Count; i++)
            {
                tablicaWText[i].text = "";
                tablicaWText[i].text += $"{i + 1}." + " " + $"{tablicaWynikpw[i]}" + "  " + $"{tablicaWynikowInt[i]}\n";
            }
       
        
    }



    public void ClearHighScores()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        tablicaWynikowInt.Clear();


        tablicaWynikpw.Clear();

        DisplayHighScores();
    }
}
