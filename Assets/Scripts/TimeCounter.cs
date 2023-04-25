using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TimeCounter : MonoBehaviour
{
    private TMP_Text _timeCounterText;
    public float timeLeft;
    End end;
    //TMP Metin �ekmemize yariyor.
    private void Awake()
    {
        _timeCounterText = GetComponent<TMP_Text>();
    }

   
    /*
     * zamani dakika ve saniye cinsinden ekrana yazdirmamizi sagliyor, eger zaman 1 in altindaysa gameover fonksiyonuna indeks sayisini g�nderyor.
     */
    void Update()
    {
        if (!End.isComleted)
        {
            Time();
        }
        
    }

    public void Time()
    {
        if (timeLeft < 1)
        {
            MenuPanel.Instance.GameOver(1);
            

        }
        else
        {
            //FloorToInt  ondalikli sayiyi d�n��t�r�r, FlorrToInt cikan sonucu int degi�kene atayabilir Florr dan farki budur.
            //FloorToInt her hangi bir ondalikli sayiyi taban kismina g�re verir.
            //Floor sadece float degiskene atayabilir.
            timeLeft -= UnityEngine.Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeLeft / 60f);
            int seconds = Mathf.FloorToInt(timeLeft % 60f);
            // string format int gelen de�eri stringe cevirir ve texte atar, text de ekranda yazdirilmasini saglar. 
            _timeCounterText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
    }
}
