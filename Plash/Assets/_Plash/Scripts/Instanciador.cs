
using UnityEngine;
using Random = UnityEngine.Random;

public class Instanciador : MonoBehaviour
{
    [SerializeField]
    private GameObject lixo;
    [SerializeField]
    private float timeSpawn;
    [SerializeField]
    private int whichPlayer = 1;
    private ScriptTrash trash;
    private PauseGame pauseGame;
    private bool auxPause = false;
    public int fase;

    void Awake()
    {
        pauseGame = GameObject.Find("Canvas").GetComponent<PauseGame>();
    }
    void Start()
    {
        InvokeRepeating("InstanciarLixo", timeSpawn, timeSpawn);
    }

    void Update()
    {
        if(!auxPause && pauseGame.isPause)
        {
            CancelInvoke("InstanciarLixo");
            auxPause = true;
        }
        else if(auxPause && !pauseGame.isPause)
        {
            Start();
            auxPause = false;
        }
    }
    void InstanciarLixo()
    {
        GameObject spawn;
        spawn = Instantiate(lixo, new Vector3(Random.Range(1.1f, 3.8f), transform.position.y, transform.position.z), Quaternion.identity);
        trash = spawn.GetComponent<ScriptTrash>();
        trash.speed = GetSpeed(fase);
        trash._player = whichPlayer;
        spawn.GetComponent<TypeTrash>().belongTo = whichPlayer;
    }

    int GetSpeed(int fase)
    {
        if (fase == 1)
            return Random.Range(3, 6);
        if (fase == 2)
            return Random.Range(4, 7);
        else
            return Random.Range(5, 8);
    }
}
