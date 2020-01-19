using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArtificialInteligence : MonoBehaviour
{
    public Text[,] mapeamento = new Text[4, 4];

    public int[,] campo = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, };

    //0 - desconhecido      1 - Normal      2 - Fedor       3 - Brisa       4 - Buraco      5 - monstro     6 - Fedor e Brisa       7 - Ouro
    public int posicaoAtual;
    public int tipoDeCampo;
    public bool pegueiOuro = false;
    public int flecha = 1;
    public GameObject arrow;
    public Text victoryText;

    private void Start()
    {
        victoryText.text = "";
        DebugMaster();
        StartCoroutine(WaitTime(1f));
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(WaitTime());
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            DebugMaster();
        }*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
         Application.Quit();
    #endif
        }

        if (Input.GetKeyDown(KeyCode.F1))
            SceneManager.LoadScene(0);
    }

    private void DebugMaster()
    {
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                var z = i * 4 + j;
                mapeamento[i, j] = GameObject.Find("" + z.ToString()).GetComponent<Text>();
                //Debug.Log("Texto da posicao " + z + " é: " + mapeamento[i, j].text);
            }
        }
    }

    private void Action()
    {
        // Y é o WIMP 3
        if (!pegueiOuro)
        {
            if (WhatIsMyPosition(2) == 0 && WhatIsMyPosition(3) == 0)
            {
                UpOrRight();
            }
            else if (WhatIsMyPosition(2) == 1 && WhatIsMyPosition(3) == 0)
            {
                if (tipoDeCampo == 3)
                {
                    LeftUpRight();
                }
                else if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 4);
                    if (direction == 0)
                    {
                        GoUp();
                    }
                    else if (direction == 1)
                    {
                        GoRight();
                    }
                    else if (direction == 2)
                    {
                        GoLeft();
                    }
                    else if (direction == 3)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    UpOrRight();
                }
            }
            else if (WhatIsMyPosition(2) == 2 && WhatIsMyPosition(3) == 0)
            {
                if (tipoDeCampo == 3)
                {
                    LeftUpRight();
                }
                else if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 4);
                    if (direction == 0)
                    {
                        GoUp();
                    }
                    else if (direction == 1)
                    {
                        GoRight();
                    }
                    else if (direction == 2)
                    {
                        GoLeft();
                    }
                    else if (direction == 3)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    UpOrRight();
                }
            }
            else if (WhatIsMyPosition(2) == 3 && WhatIsMyPosition(3) == 0)
            {
                UpOrLeft();
            }
            else if (WhatIsMyPosition(2) == 0 && WhatIsMyPosition(3) == 1)
            {
                if (tipoDeCampo == 3)
                {
                    UpDownRight();
                }
                else if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 4);
                    if (direction == 0)
                    {
                        GoUp();
                    }
                    else if (direction == 1)
                    {
                        GoRight();
                    }
                    else if (direction == 2)
                    {
                        GoDown();
                    }
                    else if (direction == 3)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    UpDownRight();
                }
            }
            else if (WhatIsMyPosition(2) == 1 && WhatIsMyPosition(3) == 1)
            {
                if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 4);
                    if (direction == 0)
                    {
                        GoUp();
                    }
                    else if (direction == 1)
                    {
                        GoRight();
                    }
                    else if (direction == 2)
                    {
                        GoDown();
                    }
                    else if (direction == 3)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    AnyDirection();
                }
            }
            else if (WhatIsMyPosition(2) == 2 && WhatIsMyPosition(3) == 1)
            {
                if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 4);
                    if (direction == 0)
                    {
                        GoUp();
                    }
                    else if (direction == 1)
                    {
                        GoRight();
                    }
                    else if (direction == 2)
                    {
                        GoDown();
                    }
                    else if (direction == 3)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    AnyDirection();
                }
            }
            else if (WhatIsMyPosition(2) == 3 && WhatIsMyPosition(3) == 1)
            {
                if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 2);
                    if (direction == 0)
                    {
                        AnyDirection();
                    }
                    else if (direction == 1)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    UpDownLeft();
                }
            }
            else if (WhatIsMyPosition(2) == 0 && WhatIsMyPosition(3) == 2)
            {
                if (tipoDeCampo == 3)
                {
                    UpDownRight();
                }
                else if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 4);
                    if (direction == 0)
                    {
                        GoUp();
                    }
                    else if (direction == 1)
                    {
                        GoRight();
                    }
                    else if (direction == 2)
                    {
                        GoDown();
                    }
                    else if (direction == 3)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    UpDownRight();
                }
            }
            else if (WhatIsMyPosition(2) == 1 && WhatIsMyPosition(3) == 2)
            {
                if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 2);
                    if (direction == 0)
                    {
                        AnyDirection();
                    }
                    else if (direction == 1)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    AnyDirection();
                }
            }
            else if (WhatIsMyPosition(2) == 2 && WhatIsMyPosition(3) == 2)
            {
                if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 2);
                    if (direction == 0)
                    {
                        AnyDirection();
                    }
                    else if (direction == 1)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    AnyDirection();
                }
            }
            else if (WhatIsMyPosition(2) == 3 && WhatIsMyPosition(3) == 2)
            {
                if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 4);
                    if (direction == 0)
                    {
                        GoUp();
                    }
                    else if (direction == 1)
                    {
                        GoLeft();
                    }
                    else if (direction == 2)
                    {
                        GoDown();
                    }
                    else if (direction == 3)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    UpDownLeft();
                }
            }
            else if (WhatIsMyPosition(2) == 0 && WhatIsMyPosition(3) == 3)
            {
                DownOrRight();
            }
            else if (WhatIsMyPosition(2) == 1 && WhatIsMyPosition(3) == 3)
            {
                if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 4);
                    if (direction == 0)
                    {
                        GoRight();
                    }
                    else if (direction == 1)
                    {
                        GoLeft();
                    }
                    else if (direction == 2)
                    {
                        GoDown();
                    }
                    else if (direction == 3)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    LeftDownRight();
                }
            }
            else if (WhatIsMyPosition(2) == 2 && WhatIsMyPosition(3) == 3)
            {
                if (tipoDeCampo == 2)
                {
                    var direction = Random.Range(0, 4);
                    if (direction == 0)
                    {
                        GoRight();
                    }
                    else if (direction == 1)
                    {
                        GoLeft();
                    }
                    else if (direction == 2)
                    {
                        GoDown();
                    }
                    else if (direction == 3)
                    {
                        if (flecha > 0)
                        {
                            Disparar();
                            return;
                        }
                        else
                        {
                            GoDown();
                        }
                    }
                }
                else
                {
                    LeftDownRight();
                }
            }
            else if (WhatIsMyPosition(2) == 3 && WhatIsMyPosition(3) == 3)
            {
                DownOrLeft();
            }
        }
        else if (pegueiOuro)
        {
            if (WhatIsMyPosition(2) == 0 && WhatIsMyPosition(3) == 0)
            {
                StartCoroutine(WinGame());
            }
            else if (WhatIsMyPosition(2) == 0 && WhatIsMyPosition(3) != 0)
            {
                GoDown();
            }
            else if (WhatIsMyPosition(2) != 0 && WhatIsMyPosition(3) == 0)
            {
                GoLeft();
            }
            else
            {
                DownOrLeft();
            }
        }

        StartCoroutine(WaitTime(1f));
    }

    private void Disparar()
    {
        StopAllCoroutines();
        flecha--;
        var fire = Instantiate(arrow, transform.position, Quaternion.identity);
        fire.transform.position = new Vector3(transform.position.x, transform.position.y, -2.7f);
        fire.GetComponent<Flecha>().direction = Random.Range(0, 2);
        StartCoroutine(WaitTime(3f));
    }

    private IEnumerator WaitTime(float time)
    {
        tipoDeCampo = 1;
        yield return new WaitForSeconds(time);
        MyBlockIs();
        Action();
    }

    private IEnumerator WinGame()
    {
        victoryText.text = "Você recuperou o ouro, Parabéns!";
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);
    }

    #region Movimentacao

    private void AnyDirection()
    {
        var direction = Random.Range(0, 4);
        if (direction == 0)
        {
            GoUp();
        }
        else if (direction == 1)
        {
            GoRight();
        }
        else if (direction == 2)
        {
            GoDown();
        }
        else if (direction == 3)
        {
            GoLeft();
        }
    }

    private void UpDownLeft()
    {
        var direction = Random.Range(0, 3);
        if (direction == 0)
        {
            GoDown();
        }
        else if (direction == 1)
        {
            GoUp();
        }
        else if (direction == 2)
        {
            GoLeft();
        }
    }

    private void UpDownRight()
    {
        var direction = Random.Range(0, 3);
        if (direction == 0)
        {
            GoDown();
        }
        else if (direction == 1)
        {
            GoRight();
        }
        else if (direction == 2)
        {
            GoUp();
        }
    }

    private void LeftDownRight()
    {
        var direction = Random.Range(0, 3);
        if (direction == 0)
        {
            GoDown();
        }
        else if (direction == 1)
        {
            GoRight();
        }
        else if (direction == 2)
        {
            GoLeft();
        }
    }

    private void LeftUpRight()
    {
        var direction = Random.Range(0, 3);
        if (direction == 0)
        {
            GoUp();
        }
        else if (direction == 1)
        {
            GoRight();
        }
        else if (direction == 2)
        {
            GoLeft();
        }
    }

    private void UpOrRight()
    {
        var direction = Random.Range(0, 2);
        if (direction == 0)
        {
            GoUp();
        }
        else
            GoRight();
    }

    private void DownOrRight()
    {
        var direction = Random.Range(0, 2);
        if (direction == 0)
        {
            GoDown();
        }
        else
            GoRight();
    }

    private void DownOrLeft()
    {
        var direction = Random.Range(0, 2);
        if (direction == 0)
        {
            GoDown();
        }
        else
            GoLeft();
    }

    private void UpOrLeft()
    {
        var direction = Random.Range(0, 2);
        if (direction == 0)
        {
            GoUp();
        }
        else
            GoLeft();
    }

    private void GoUp()
    {
        transform.position += new Vector3(0, 1, 0);
    }

    private void GoDown()
    {
        transform.position += new Vector3(0, -1, 0);
    }

    private void GoRight()
    {
        transform.position += new Vector3(1, 0, 0);
    }

    private void GoLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
    }

    #endregion

    private void MyBlockIs()
    {
        var x = WhatIsMyPosition(2);
        var y = WhatIsMyPosition(3);
        campo[y, x] = tipoDeCampo;
        mapeamento[y, x].text = tipoDeCampo.ToString();
        DebugMaster();
    }

    private int WhatIsMyPosition(int retorno)
    {
        posicaoAtual = 0;
        var x = 0;
        var y = 0;
        if (transform.position.x == 0 && transform.position.y == -1)
        {
            posicaoAtual = 0;
            x = 0;
            y = 0;
        }
        else if (transform.position.x == 1 && transform.position.y == -1)
        {
            posicaoAtual = 1;
            x = 1;
            y = 0;
        }
        else if (transform.position.x == 2 && transform.position.y == -1)
        {
            posicaoAtual = 2;
            x = 2;
            y = 0;
        }
        else if (transform.position.x == 3 && transform.position.y == -1)
        {
            posicaoAtual = 3;
            x = 3;
            y = 0;
        }
        else if (transform.position.x == 0 && transform.position.y == 0)
        {
            posicaoAtual = 4;
            x = 0;
            y = 1;
        }
        else if (transform.position.x == 1 && transform.position.y == 0)
        {
            posicaoAtual = 5;
            x = 1;
            y = 1;
        }
        else if (transform.position.x == 2 && transform.position.y == 0)
        {
            posicaoAtual = 6;
            x = 2;
            y = 1;
        }
        else if (transform.position.x == 3 && transform.position.y == 0)
        {
            posicaoAtual = 7;
            x = 3;
            y = 1;
        }
        else if (transform.position.x == 0 && transform.position.y == 1)
        {
            posicaoAtual = 8;
            x = 0;
            y = 2;
        }
        else if (transform.position.x == 1 && transform.position.y == 1)
        {
            posicaoAtual = 9;
            x = 1;
            y = 2;
        }
        else if (transform.position.x == 2 && transform.position.y == 1)
        {
            posicaoAtual = 10;
            x = 2;
            y = 2;
        }
        else if (transform.position.x == 3 && transform.position.y == 1)
        {
            posicaoAtual = 11;
            x = 3;
            y = 2;
        }
        else if (transform.position.x == 0 && transform.position.y == 2)
        {
            posicaoAtual = 12;
            x = 0;
            y = 3;
        }
        else if (transform.position.x == 1 && transform.position.y == 2)
        {
            posicaoAtual = 13;
            x = 1;
            y = 3;
        }
        else if (transform.position.x == 2 && transform.position.y == 2)
        {
            posicaoAtual = 14;
            x = 2;
            y = 3;
        }
        else if (transform.position.x == 3 && transform.position.y == 2)
        {
            posicaoAtual = 15;
            x = 3;
            y = 3;
        }

        if (retorno == 1)
            return posicaoAtual;
        else if (retorno == 2)
            return x;
        else if (retorno == 3)
            return y;
        return posicaoAtual;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Stench"))
        {
            tipoDeCampo = 2;
        }
        else if (other.CompareTag("Breeze"))
        {
            tipoDeCampo = 3;
        }
        else if (other.CompareTag("Gold"))
        {
            tipoDeCampo = 7;
            pegueiOuro = true;
        }
        else if (other.CompareTag("Pit") || other.CompareTag("Monster"))
        {
            SceneManager.LoadScene(0);
        }
        else if (other.CompareTag("Blank"))
        {
            tipoDeCampo = 1;
        }
    }
}