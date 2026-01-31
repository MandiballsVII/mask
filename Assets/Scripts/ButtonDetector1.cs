using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetector1 : MonoBehaviour
{
    [Header("Configuración del Input")]
    public KeyCode teclaAsignada;
    public KeyCode teclaMando;
    public List<GameObject> notasRango = new List<GameObject>();
  
    void Start()
    {
        if (teclaAsignada == KeyCode.None) teclaAsignada = KeyCode.A;  
    } 

    void Update()
    {
        if (Input.GetKeyDown(teclaAsignada) || Input.GetKeyDown(teclaMando))
        {
            if (notasRango.Count > 0)
            {
                VerificarGolpe();
            }
            else
            {
                Debug.Log(message: "Missed! You didn't pressed any key.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nota"))
        {
            notasRango.Add(other.gameObject);

        }
        Debug.Log(message: "Combo system activated.");
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Nota"))
        {
            if(notasRango.Contains(other.gameObject)) 
            {
                notasRango.Remove(other.gameObject);
                
                Debug.Log(message: "Combo missed.");

                Destroy(other.gameObject, 0.5f);
            }
        }   
    }

    void VerificarGolpe()
    {
        GameObject keyHitted = notasRango[0];
        
        float distancia = Vector2.Distance(transform.position, keyHitted.transform.position);

        if (distancia < 0.15f )
        {
            Debug.Log(message: "Perfect!");
            ScoreManager.instance.AddScore(500);

        } else if (distancia < 0.35f) {
            Debug.Log(message: "Good!");
        } else {
            Debug.Log(message: "Ok");
        }

        Debug.Log(message: "HIT! Golpe con éxito");

        notasRango.Remove(keyHitted);
        Destroy(keyHitted);
    }
}
