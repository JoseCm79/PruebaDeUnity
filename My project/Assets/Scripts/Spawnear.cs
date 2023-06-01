using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnear : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    [SerializeField] private GameObject murcielagoprefab;
    private bool Spawn = true;
    // Update is called once per frame
    void Update()
    {
        if (Spawn)
        {
                Instantiate(murcielagoprefab, spawn.transform.position, spawn.rotation);
                StartCoroutine(Sucesos());
        }
        
    }
    IEnumerator Sucesos()
    {
        Spawn = false;
        yield return new WaitForSeconds(20f);
        Spawn = true;
    }


}
