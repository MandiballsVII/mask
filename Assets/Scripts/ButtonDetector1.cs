using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetector1 : MonoBehaviour
{
    [Header("Configuración del Input")]
    public KeyCode teclaAsignada;
    public KeyCode teclaMando;
    public List<GameObject> notasRango = new List<GameObject>();

    public GameObject keyHitted;
  
    void Start()
    {
        if (teclaAsignada == KeyCode.None) teclaAsignada = KeyCode.A;  
    } 

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            if(!notasRango.Contains(other.gameObject)) {
                notasRango.Add(other.gameObject);
            }

            if (Input.GetKeyDown(teclaAsignada) || Input.GetKeyDown(teclaMando))
            {
                keyHitted = other.gameObject;
                VerificarGolpe();
            }
        }
        Debug.Log(message: "Combo system activated.");
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Note"))
        {   
            Debug.Log(message: "Combo missed!");

            //ScoreManager.instance.ResetCombo();
            //notasRango.Remove(other.gameObject);
            //Destroy(other.gameObject);
        }   
    }

    public void VerificarGolpe()
    {
        if (keyHitted == null)
            return;
        
        float distancia = Vector2.Distance(transform.position, keyHitted.transform.position);
        
        if (ScoreManager.instance != null) {
            if (distancia < 0.2f ) {

                ScoreManager.instance.AddScore(500);
                Debug.Log(message: "Perfect!");

            } else if (distancia < 0.5f) {

                ScoreManager.instance.AddScore(250);
                Debug.Log(message: "Good!");

            } else {

                ScoreManager.instance.AddScore(100);
                Debug.Log(message: "Ok");

            }
        } else {
            Debug.LogError("ERROR! ScoreManager not found.");
        }

        Debug.Log(message: "HIT! Golpe con éxito");

        notasRango.Remove(keyHitted);
        Destroy(keyHitted);
        keyHitted = null;
    }
}
