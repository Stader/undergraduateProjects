using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDeFase : MonoBehaviour
{
    private new CameraFollow camera;
    private MoverPlayer player;
    private LevelChanger levelChanger;

    private void Start()
    {
        levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        player = GameObject.FindWithTag("Player").GetComponent<MoverPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camera.follow = false;
            player.canMove = false;
            StartCoroutine(ProximaFase());
        }
    }

    IEnumerator ProximaFase()
    {
        yield return new WaitForSeconds(1.0f);
        levelChanger.FadeToLevel();
    }
}
