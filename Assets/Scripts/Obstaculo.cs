using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour {

    [SerializeField]
    private float velocidade = 0.5f;

    private bool pontuou;
    private Vector3 posicaoDoAviao;

    private Pontuacao pontuacao;

    [SerializeField]
    private float variacaoy;

    private void Start()
    {
        this.posicaoDoAviao = GameObject.FindObjectOfType<Aviao>().transform.position;
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        
    }

    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoy, variacaoy));
    }

    void Update()
    {

        this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);


        if (!this.pontuou && this.transform.position.x < this.posicaoDoAviao.x)
        {
            Debug.Log("Pontuou");

            this.pontuou = true;
            this.pontuacao.AdicionarPontos();
        }
    }

    private void OnTriggerEnter2D(Collider2D outro) {

        this.Destruir();
        
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
