using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject pala;
    [SerializeField] private TextMeshProUGUI textoScore;
    [SerializeField] private TextMeshProUGUI textoVidas;
    [SerializeField] private GameObject ButtonReset;
    private bool puedoLanzar = true;
    private int vidas = 3;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoLanzar == true && vidas >= 1)
        {
            transform.SetParent(null); // Me desemparento
            rb.isKinematic = false; // Lo paso a dinámico

            //Estamos aplicando la fuerza a la que va la bola y lo multiplicamos x10
            //El ForceMode2D, El .Force sería para empujar (como una piedra), y el .Impulse para un golpe seco como una patada
            rb.AddForce(new Vector2 (1, 1).normalized * 10, ForceMode2D.Impulse);
            puedoLanzar = false;
        }
        
        if (vidas == 0)
        {
            ButtonReset.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("ZonaMuerte"))
        {
            ResetearBola();
        }

    }
    private void OnCollisionEnter2D(Collision2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("Bloque"))
        { 
            Destroy(elOtro.gameObject);
            score++;
            textoScore.text = "Score: " + score;
        }
    }

    private void ResetearBola()
    {
        rb.velocity = Vector2.zero; // Suprimimos la velocidad que traigamos
        rb.isKinematic = true; // Paso a Cinemático (sin físicas)
        transform.SetParent(pala.transform); // Volvemos a emparentar la bola
        transform.localPosition = new Vector3(0,1,0); //Recolocamos la bola
        puedoLanzar = true;
        vidas--;
        textoVidas.text = "Vidas: " + vidas;
    }
}
