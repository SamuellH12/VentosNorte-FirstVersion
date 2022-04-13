using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(Controle2D))]
    public class MovimentoDeJogador : MonoBehaviour
    {
        [SerializeField]
        private float _velocidade = 50f;
        [SerializeField]
        private Joystick joystick;
        [SerializeField]
        private GerenciadorDeSons gerenciadorDeSons;

        private Controle2D _controle;
        private Animator anim;
        private Rigidbody2D rigid;
        private AudioSource music;
        private float _movimentoHorizontal = 0f;
        private bool _pulando = false;

        public bool jogadorControlavel = true;


        private void Awake()
        {
            _controle = GetComponent<Controle2D>(); // Obtém o componente Controle2D que está acoplado ao jogador e salva na variável privada
             anim = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody2D>();
            music = GetComponent<AudioSource>();
        }

        void Update()
        {

            _movimentoHorizontal = Input.GetAxisRaw("Horizontal") * _velocidade;
            
            if(joystick.Horizontal >= 0.2){
                _movimentoHorizontal = 1 * _velocidade;
            } else if(joystick.Horizontal <=-0.2){
                _movimentoHorizontal = -1 * _velocidade;
            }
            

            if (Input.GetButtonDown("Jump"))
            {
                pular();
                music.Play();
            }

            if(rigid.velocity.x > 1 || rigid.velocity.x < -1){
                anim.SetBool("correndo", true);
                if(gerenciadorDeSons != null) { gerenciadorDeSons.TocaAudo("correndo"); }
            } else {
                anim.SetBool("correndo", false);
            }

            if (_controle.GetEstaNoChao()){
                anim.SetBool("pulando", false);
            } 
            else
            {
                anim.SetBool("pulando", true);
            }

            //Futuramente criar ataque;
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        anim.SetBool("ataque", true);
        //    }

        }

        public void desativarControles()
        {
            jogadorControlavel = false;
        }
        public void ativarControles()
        {
            jogadorControlavel = true;
        }

        public void pular()
        {
            _pulando = true;
        }

        void FixedUpdate()
        {
            if(!jogadorControlavel){ _movimentoHorizontal = 0; _pulando = false; }
                _controle.Movimento(_movimentoHorizontal * Time.fixedDeltaTime, _pulando);
            
            _pulando = false;
        }

    }
