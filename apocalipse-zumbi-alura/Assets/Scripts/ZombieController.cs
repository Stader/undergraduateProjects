using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieController : MonoBehaviour, IMatavel
{
    [SerializeField] private GameObject player;
    private MovimentoPersonagem _movimentaInimigo;
    private AnimacaoPersonagem _animacaoInimigo;
    private Status _statusInimigo;
    public AudioClip somDeMorte;
    private Vector3 _posicaoAleatoria;
    private Vector3 _dir;
    private float _contadorVagar;
    private float _tempoEntrePosicoesAleatorias = 4f;
    private float _porcentagemGerarKitMedico = 0.1f;
    public GameObject KitMedico;
    private InterfaceController scriptControlaInterface;
    [HideInInspector] public SpawnZombie meuGerador;
    public GameObject ParticulaSangueZumbi;


    private void Start()
    {
        player = GameObject.FindWithTag(Tags.Jogador);
        _movimentaInimigo = GetComponent<MovimentoPersonagem>();
        _animacaoInimigo = GetComponent<AnimacaoPersonagem>();
        _statusInimigo = GetComponent<Status>();
        AleatorizarZumbi();
        scriptControlaInterface = FindObjectOfType(typeof(InterfaceController)) as InterfaceController;
    }

    private void FixedUpdate()
    {
        var positionPlayer = player.transform.position;
        var position = transform.position;

        _animacaoInimigo.Movimentar(_dir.magnitude);

        var distance = Vector3.Distance(position, positionPlayer);
        _movimentaInimigo.Rotacionar(_dir);

        if (distance > 15f)
        {
            Vagar();
        }
        else if (distance > 2.5f)
        {
            _dir = positionPlayer - position;
            _movimentaInimigo.Movimentar(_dir, _statusInimigo.Velocidade);
            _animacaoInimigo.Atacar(false);
        }
        else
        {
            _dir = positionPlayer - position;
            _animacaoInimigo.Atacar(true);
        }
    }

    void Vagar()
    {
        _contadorVagar -= Time.deltaTime;
        if (_contadorVagar <= 0)
        {
            _posicaoAleatoria = AleatorizarPosicao();
            _contadorVagar += _tempoEntrePosicoesAleatorias + Random.Range(-1f, 1f);
        }
        bool ficouPertoOSuficiente = Vector3.Distance(transform.position, _posicaoAleatoria) <= 0.05;
        if (!ficouPertoOSuficiente)
        {
            _dir = _posicaoAleatoria - transform.position;
            _movimentaInimigo.Movimentar(_dir, _statusInimigo.Velocidade);
        }
    }

    Vector3 AleatorizarPosicao()
    {
        var posicao = Random.insideUnitSphere * 10;
        posicao += transform.position;
        posicao.y = transform.position.y;

        return posicao;
    }

    void AtacaJogador()
    {
        var dano = Random.Range(20, 31);
        player.GetComponent<PlayerController>().TomarDano(dano);
    }

    void AleatorizarZumbi()
    {
        var randomZombie = Random.Range(1, transform.childCount);
        transform.GetChild(randomZombie).gameObject.SetActive(true);
    }

    public void TomarDano(int dano)
    {
        _statusInimigo.Vida -= dano;
        if (_statusInimigo.Vida <= 0)
        {
            Morrer();
        }
    }

    public void ParticulaSangue(Vector3 posicao, Quaternion rotacao)
    {
        Instantiate(ParticulaSangueZumbi, posicao,rotacao);
    }

    public void Morrer()
    {
        Destroy(gameObject, 3f);
        _animacaoInimigo.Morrer();
        _movimentaInimigo.Morrer();
        this.enabled = false;
        AudioController.instancia.PlayOneShot(somDeMorte);
        VerificarGeracaoKitMedico(_porcentagemGerarKitMedico);
        scriptControlaInterface.AtualizarQuantidadeDeZumbisMortos();
        meuGerador.DiminuirQtdZumbisVivos();

    }

    void VerificarGeracaoKitMedico(float porcentagemGeracao)
    {
        if (Random.value <= porcentagemGeracao)
            Instantiate(KitMedico, transform.position, Quaternion.identity);
    }
}