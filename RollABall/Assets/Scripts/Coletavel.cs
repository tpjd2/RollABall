using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    private AudioSource asource;
    private MeshRenderer mr;
    private Collider c;

    // Start is called before the first frame update
    void Start()
    {
        asource = GetComponent<AudioSource>();
        mr = GetComponent<MeshRenderer>();
        c = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Coleta());
        }
    }

    private IEnumerator Coleta()
    {
        mr.enabled = false;
        c.enabled = false;
        GameController.instancia.AtualizaTempo(2f);
        GameController.instancia.AtualizaPontos(1f);
        asource.Play();
        yield return new WaitForSeconds(asource.clip.length);        
        this.gameObject.SetActive(false);
    }
}
