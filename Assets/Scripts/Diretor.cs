using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{

    [SerializeField]
    private GameObject imagemGameOver;

    private Pontuacao pontuacao;

    [SerializeField]
    private Aviao aviao;

    private void Start()
    {
        this.aviao = GameObject.FindObjectOfType<Aviao>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    public void finalizarJogo()
    {
        Time.timeScale = 0;
        this.imagemGameOver.SetActive(true);


    }


    public void ReiniciarJogo()
    {

        this.pontuacao.ZerarPontos();
        this.imagemGameOver.SetActive(false);
        Time.timeScale = 1;
        aviao.Reiniciar();
        this.DestruirObstaculos();


    }

    private void DestruirObstaculos()
    {
        Obstaculo[] obst = GameObject.FindObjectsOfType<Obstaculo>();

        foreach(Obstaculo  obstaculo in obst)
        {
            obstaculo.Destruir();
        }
    }

}