using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private int danoDoTiro = 1;
    [SerializeField] private float speed = 30f;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 10f);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + speed * Time.deltaTime * transform.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        Quaternion rotacaoOpostaABala = Quaternion.LookRotation(-transform.forward);
        switch (other.tag)
        {
            case "Inimigo":
                var zumbi = other.GetComponent<ZombieController>();
                zumbi.TomarDano(danoDoTiro);
                zumbi.ParticulaSangue(transform.position, rotacaoOpostaABala);
                break;
            case "ChefeDeFase":
                var chefe = other.GetComponent<ControlaChefe>();
                chefe.TomarDano(danoDoTiro);
                chefe.ParticulaSangue(transform.position, rotacaoOpostaABala);
                break;

        }

        Destroy(gameObject);
    }
}
