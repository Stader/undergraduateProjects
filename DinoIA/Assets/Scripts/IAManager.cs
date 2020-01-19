using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IAManager : MonoBehaviour
{
    private Material[] colors = new Material[15];
    private Vector3 originalCameraPosition = new Vector3(2, 0.75f, -10f);
    private Vector3 originalDinoPosition = new Vector3(0f, 0.2f, 0f);
    private Vector3 floorPosition = new Vector3(3.75f, -0.25f, 0f);
    public GameObject dinoPrefab, floorPrefab, enemy;
    public GameObject[] cactus;
    public Text generationText, seconds, betterTimeText, spawnText, speedText;
    private Window_Graph _graph;

    public float distanceCheckJump, distanceCheckCrouch;
    public float newDistanceCheckJump, newDistanceCheckCrouch;
    public float mutationPorcent;

    public int spawnDinos, remainDinos, generation = 0;
    public int dinoRemain;

    private float timer, betterTime;
    private int countGraph = 0;
    private bool startGraph;
    private void Awake()
    {
        _graph = GameObject.Find("Window_Graph").GetComponent<Window_Graph>();
    }
    private void Start()
    {
        startGraph = true;
        countGraph = 0;
        timer = 0;
        betterTime = 0;
        TakeColors();
        newDistanceCheckCrouch = distanceCheckCrouch;
        newDistanceCheckJump = distanceCheckJump;
        InstantiateDinos();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        speedText.text = "Velocidade: " + (3f + timer / 1000).ToString("F3");
        seconds.text = timer.ToString("F3");
        _graph.UpdateValue(countGraph, (int)timer);
    }

    private void LateUpdate()
    {
        if (remainDinos == 0)
        {
            InstantiateDinos();
        }
    }

    private void InstantiateDinos()
    {
        if (betterTime < timer)
            betterTime = timer;
        var text = (int)betterTime;
        betterTimeText.text = text.ToString();
        if (!startGraph)
        {
            _graph.valueList.Add(0);
            countGraph++;
        }
        timer = 0;
        StopAllCoroutines();
        StartCoroutine(GenerateObstacle());
        for (var i = 0; i < spawnDinos; i++)
        {
            var randomX = new Vector3(Random.Range(-.5f, .5f), 0f, 0f);
            var dino = Instantiate(dinoPrefab, originalDinoPosition + randomX, Quaternion.identity);
            var random = Random.Range(0, 15);
            var dinoIA = dino.GetComponent<DinoIA>();
            dinoIA.iaManager = this;
            dinoIA.distanceCheckJump = newDistanceCheckJump;
            dinoIA.distanceCheckCrouch = newDistanceCheckCrouch;
            dinoIA.mutation = mutationPorcent;
            dino.GetComponent<Renderer>().material = colors[random];
            remainDinos++;
        }
        Camera.main.GetComponent<CameraFollow>().Restore();
        generation++;
        Camera.main.transform.position = originalCameraPosition;
        var objs = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objs)
        {
            if(obj.CompareTag("Floor") || obj.CompareTag("Enemy") || obj.CompareTag("Cactus"))
                Destroy(obj);
        }
        Instantiate(floorPrefab, floorPosition, Quaternion.identity);
        generationText.text = "Geração: " + generation;
        startGraph = false;
    }

    private IEnumerator GenerateObstacle()
    {
        var time = 3 - timer / 500;
        if (time < 1f)
            time = 1f;
        spawnText.text = "Velocidade Spawn: " + time.ToString("F3");
        yield return new WaitForSeconds(time);
        var pos = new Vector3(Camera.main.transform.position.x + 3.5f, 0f, 0f);
        if (timer > 50f)
        {
            var x = Random.Range(0, 2);
            if(x == 0)
                Instantiate(enemy, pos, Quaternion.identity);
            else
                Instantiate(cactus[Random.Range(0, cactus.Length)], pos, Quaternion.identity);
        }
        else
            Instantiate(cactus[Random.Range(0, cactus.Length)], pos, Quaternion.identity);
        StartCoroutine(GenerateObstacle());
    }

    private void TakeColors()
    {
        colors[0] = Resources.Load<Material>("Materials/Blue");
        colors[1] = Resources.Load<Material>("Materials/Ciano");
        colors[2] = Resources.Load<Material>("Materials/DarkBlue");
        colors[3] = Resources.Load<Material>("Materials/DarkGreen");
        colors[4] = Resources.Load<Material>("Materials/DarkYellow");
        colors[5] = Resources.Load<Material>("Materials/Gray");
        colors[6] = Resources.Load<Material>("Materials/Green");
        colors[7] = Resources.Load<Material>("Materials/Lima");
        colors[8] = Resources.Load<Material>("Materials/LiteBlue");
        colors[9] = Resources.Load<Material>("Materials/Orange");
        colors[10] = Resources.Load<Material>("Materials/Pink");
        colors[11] = Resources.Load<Material>("Materials/Purple");
        colors[12] = Resources.Load<Material>("Materials/Red");
        colors[13] = Resources.Load<Material>("Materials/White");
        colors[14] = Resources.Load<Material>("Materials/Yellow");
    }

    public void GameTime0_5()
    {
        Time.timeScale = 0.5f;
    }

    public void GameTime1()
    {
        Time.timeScale = 1f;
    }

    public void GameTime2()
    {
        Time.timeScale = 2f;
    }

    public void GameTime4()
    {
        Time.timeScale = 4f;
    }

    public void GameTime8()
    {
        Time.timeScale = 8f;
    }
}
