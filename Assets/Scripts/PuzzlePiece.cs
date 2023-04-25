using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _click;
    [SerializeField] private GameObject[] _shadows;
    private Vector2 _originalPosition;
  


    End end_script;
    private void Start()
    {

        _shadows = GameObject.FindGameObjectsWithTag("shadow");
        //baslangic pozisyonumuzu belirlemek icin yapiyoruz.
        _originalPosition = transform.position;
        end_script = GameObject.Find("Puzzle Piece").GetComponent<End>();

    }
    // objeyi surukle  anlamina geliyor.
    private void OnMouseDrag()
    {
        Vector3 _pozition = GetMousePos();//Dokundugumuz yerleri bize verir.
        _pozition.z = 0;
        // dokundugumuz yerle esitliyoruz posizyona.
        transform.position = _pozition;
    }

    private void Update()
    {
        MouseUp();

    }
    /*
     * Fareyi biraktigimizda calisacak fonksiyonumuz.
     * */
    private void MouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {

            foreach (GameObject shadow in _shadows)
            {
                if (gameObject.name == shadow.name)//ust üste gelirse
                {
                    float distance = Vector3.Distance(shadow.transform.position, transform.position);// Mesafe ölcmek icin kullaniliyor.
                    if (distance <= 1)
                    {
                        transform.position = shadow.transform.position;
                        _audio.PlayOneShot(_click); 
                        Destroy(this);
                        end_script.LevelEnd();

                    }
                    else
                    {
                        transform.DOMove(_originalPosition, 0.5f).SetEase(Ease.InCubic);

                    }
                }
            }
        }
    }



   public Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
