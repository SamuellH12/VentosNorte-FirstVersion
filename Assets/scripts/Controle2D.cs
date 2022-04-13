using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Controle2D : MonoBehaviour
    {
        [SerializeField]
        private float _forcaDoPulo = 200f;         
        [SerializeField]
        private LayerMask _camadaChao;              
        [SerializeField]
        private Transform _posicaoDeBaixo;         
        

        private float _suavizacaoMovimento = .05f;  
        private bool _controleAereo = true;         
        private bool _estaNoChao;                   
        private Rigidbody2D _rigidbody2D;           
        private bool _viradoParaDireita = true;     
        const float _raioParaChao = .2f;            

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _estaNoChao = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(_posicaoDeBaixo.position, _raioParaChao, _camadaChao);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    _estaNoChao = true;
            }
        }

        public bool GetEstaNoChao()
        {
            return _estaNoChao;
        }



        /// <param name="qtdMovimento">A quantidade de movimento aplicada</param>
        /// <param name="pulando">Verdadeiro se o jogador estiver tentando pular</param>
        public void Movimento(float qtdMovimento, bool pulando)
        {
            if (_estaNoChao || _controleAereo)
            {
                AplicaMovimento(qtdMovimento);
                DetectaGirar(qtdMovimento);
            }
            if (_estaNoChao && pulando)
            {
                _estaNoChao = false;
                _rigidbody2D.AddForce(new Vector2(0f, _forcaDoPulo));
            }

        }

        /// <param name="qtdMovimento">A quantidade de movimento aplicada</param>
        private void AplicaMovimento(float qtdMovimento)
        {
        
            var velocidadeJogador = new Vector2(qtdMovimento * 10f, _rigidbody2D.velocity.y);
            
            Vector3 velocity = Vector3.zero;
            _rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, velocidadeJogador, ref velocity, _suavizacaoMovimento);
        }

        /// <param name="qtdMovimento">A quantidade de movimento aplicada</param>
        private void DetectaGirar(float qtdMovimento)
        {

            if (qtdMovimento > 0 && !_viradoParaDireita)
            {
                GiraJogador();
            }
            else if (qtdMovimento < 0 && _viradoParaDireita)
            {
                GiraJogador();
            }
        }

        private void GiraJogador()
        {
            _viradoParaDireita = !_viradoParaDireita;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }