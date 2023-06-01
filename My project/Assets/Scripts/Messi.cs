using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messi : MonoBehaviour
{
    [SerializeField] private int dano;
    [SerializeField] public int vida;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Movimiento>().vida -= Random.Range(5,dano);
            collision.GetComponent<Animator>().Play("Hit");
            StartCoroutine(animacionDano(collision));
            
        }
    }
    IEnumerator animacionDano(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f);
        collision.GetComponent<Animator>().Play("Idle");
    }
}
