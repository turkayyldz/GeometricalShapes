using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject[] _total;
    [SerializeField] private Transform[] upYTransforms;
    [SerializeField] private Transform[] downYTransforms;
    [SerializeField] private Transform[] scaleTransforms;
    public float revealDuration;
    private int _totalGeo;
    public static bool isComleted;


    private void Start()
    {
        isComleted = false;

        DOTweenMethod();

    }



    /*
     * Metod objelerin y degerinden geri gönerek oldugu posizyona geri gelir.
     * DoScale ise renkli objelerin kucukten orjinal haline gelmesine sebep olur. 
     * */

    private void DOTweenMethod()
    {
        foreach (Transform scaleTransform in scaleTransforms)
        {
            scaleTransform.DOScale(Vector2.zero, revealDuration).From();
        }

        foreach (Transform upYTransform in upYTransforms)
        {
            upYTransform.DOMoveY(50f, revealDuration).From();
        }
        foreach (Transform downYTransform in downYTransforms)
        {
            downYTransform.DOMoveY(-50f, revealDuration).From();
        }
    }

    /*
    * liste içindeki tüm elemanlarý esitleyerek, eleman kalmadigi taktirde oyunu bitirecek kod.
    * */
    public void LevelEnd()
    {

        _totalGeo++;
        if (_totalGeo == _total.Length)
        {
            isComleted = true;
            MenuPanel.Instance.Winn(0);
 
            Debug.Log("oyun bitti;");
            
        }
    }
   



}
