using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBat : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private float distanciaminima;
    [SerializeField] private int paso = 0;
    [SerializeField] private SpriteRenderer SR;
    private Transform personaje;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        girar();
        personaje = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntos[paso].position, velocidad * Time.deltaTime);
        if(Vector2.Distance(transform.position, puntos[paso].position) < distanciaminima)
        {
            paso = Random.Range(0, puntos.Length);

        }
        if(paso >= puntos.Length)
        {
            paso = 0;
        }
        girar();
    }

    private void girar()
    {
        if(transform.position.x < puntos[paso].position.x)
        {
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
        }
    }
}
