using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTrash : MonoBehaviour
{
    public int _player;
    private Transform Player;
    public float speed = 2.0f, timeHold = 0f;
    private float angle = 0f;
    public bool confirmThrown = false;
    private PauseGame pauseGame;

    public bool toCatch = false;
    void Start()
    {
        pauseGame = GameObject.Find("Canvas").GetComponent<PauseGame>();
        Player = GameObject.FindWithTag("Player " + _player).GetComponent<Transform>();
    }

    void Update()
    {
        if (!pauseGame.isPause)
        {
            if (toCatch)
                transform.position = (new Vector3(Player.position.x - 0.5f, transform.position.y, Player.position.z));
            else if (!confirmThrown)
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            else
                transform.Translate(Vector3.forward * speed * 5 * Time.deltaTime, Space.Self);
        }
        else
        {
            return;
        }
        
    }

    public void ChangeDirection(float angle, bool confirm)
    {
        confirmThrown = confirm;
       // Debug.Log(angle);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.Rotate(0f, angle, 0f);
        this.angle = angle;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeleteTrash"))
        {
            Destroy(gameObject);
        }
    }
}
