using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instancia;

    [SerializeField] private PlayerController pc;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Text textoPontos;
    [SerializeField] private Text textoTempo;
    [SerializeField] private Text textoGameOver;
    [SerializeField] private float tempoRestante;

    private float pontos;
    private bool gameOver;
    private int powerUps;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            if (instancia != this)
            {
                Destroy(this);
            }
        }
        pontos = 0f;
        gameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        AtualizaPontos(0f);
        AtualizaTempo();
        // BUSCA TODOS OS GAMEOBJECTS QUE POSSUEM A TAG POWERUP
        // E INFORMA A QUANTIDADE DE OBJETOS
        powerUps = GameObject.FindGameObjectsWithTag("PowerUp").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            tempoRestante -= Time.deltaTime;
            AtualizaTempo();

            // VERIFICA O TEMPO RESTANTE
            if (tempoRestante <= 0f)
            {
                FimDeJogo("Time Is Out!");
            }
        }
    }

    public void FimDeJogo(string msg)
    {
        textoGameOver.text = msg;
        gameOver = true;
        pc.enabled = false;
        rb.freezeRotation = true;
    }

    public void AtualizaPontos(float incremento)
    {
        pontos += incremento;
        textoPontos.text = "Pontos: " + pontos;
    }

    public void AtualizaTempo()
    {
        textoTempo.text = "Tempo restante: " + Mathf.Round(tempoRestante);
    }

    public void AtualizaTempo(float incremento)
    {
        tempoRestante += incremento;
        AtualizaTempo();
    }
}
