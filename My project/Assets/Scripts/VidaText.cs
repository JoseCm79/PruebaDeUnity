using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaText : MonoBehaviour
{
    private Slider barradevida;
    private void Start()
    {
        
        barradevida = GetComponent<Slider>();
        barradevida.maxValue = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().vida;
    }
    private void Update()
    {

        barradevida.value = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().vida;
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().vida <= 0)
        {
            StartCoroutine(MuerteAnim());

        }
            
    }
    IEnumerator MuerteAnim()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().velocidadDeMovimiento = 0f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("Dead");
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
    }
}
