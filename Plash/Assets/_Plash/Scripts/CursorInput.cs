using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorInput : MonoBehaviour
{
    private CursorThrown thrown;
    private Vector3 direction = new Vector3(0f, -0.1f, 1f);
    private float timeCatch = 0f;
    int layerMask = 1;
    public DeclareInput declareInput;
    private PauseGame pauseGame;
    //[SerializeField] private Text debug;
    [SerializeField] private AudioSource soundThrow;

    private Vector3 touchPosition;
    private float localX;
    private int auxTouch = 0;
    void Start()
    {
        pauseGame = GameObject.Find("Canvas").GetComponent<PauseGame>();
        thrown = GetComponent<CursorThrown>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        layerMask = 1 << LayerMask.NameToLayer("Trash");
    }

    void Update()
    {
        if (!pauseGame.isPause)
            DetectTrash();
        else
            return;
        //Debug.Log(auxTouch);
    }

    void FixedUpdate()
    {
        if (!pauseGame.isPause)
            Move();
        else
            return;
    }

    private void Move()
    {
        if (Application.platform == RuntimePlatform.Android)
            declareInput = DeclareInput.Touch;
        
        if (declareInput == DeclareInput.Mouse)
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y");
            transform.Translate(new Vector3(verticalInput * -1, 0f, horizontalInput), Space.World);
        }
        else if (declareInput == DeclareInput.Keyboard)
        {
            float horizontalInput = Input.GetAxis("Keyboard X");
            float verticalInput = Input.GetAxis("Keyboard Y");
            transform.Translate(new Vector3(verticalInput * -1, 0f, horizontalInput), Space.World);
        }
        else if (declareInput == DeclareInput.Controller)
        {
            float horizontalInput = Input.GetAxis("Horizontal_Joystick");
            float verticalInput = Input.GetAxis("Vertical_Joystick");
            transform.Translate(new Vector3(verticalInput * -1, 0f, horizontalInput), Space.World);
        }
        else if (declareInput == DeclareInput.Touch)
        {
            GetComponent<SpriteRenderer>().enabled = false;
                
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.y = 1.03f;
                if (touchPosition.x < 7.5f)
                    localX = 1;
                else if (touchPosition.x > 9.6f)
                {
                    localX = 4.5f;
                }
                else
                {
                    if (touchPosition.x > 7.49f && touchPosition.x < 7.6f)
                        localX = 1;
                    else if (touchPosition.x > 7.59f && touchPosition.x < 7.7f)
                        localX = 1.175f;
                    else if (touchPosition.x > 7.69f && touchPosition.x < 7.8f)
                        localX = 1.35f;
                    else if (touchPosition.x > 7.79f && touchPosition.x < 7.9f)
                        localX = 1.525f;
                    else if (touchPosition.x > 7.89f && touchPosition.x < 8f)
                        localX = 1.7f;
                    else if (touchPosition.x > 7.99f && touchPosition.x < 8.1f)
                        localX = 1.875f;
                    else if (touchPosition.x > 8.09f && touchPosition.x < 8.2f)
                        localX = 2.05f;
                    else if (touchPosition.x > 8.19f && touchPosition.x < 8.3f)
                        localX = 2.255f;
                    else if (touchPosition.x > 8.29f && touchPosition.x < 8.4f)
                        localX = 2.4f;
                    else if (touchPosition.x > 8.39f && touchPosition.x < 8.5f)
                        localX = 2.575f;
                    else if (touchPosition.x > 8.49f && touchPosition.x < 8.6f)
                        localX = 2.75f;
                    else if (touchPosition.x > 8.59f && touchPosition.x < 8.7f)
                        localX = 2.925f;
                    else if (touchPosition.x > 8.69f && touchPosition.x < 8.8f)
                        localX = 3.1f;
                    else if (touchPosition.x > 8.79f && touchPosition.x < 8.9f)
                        localX = 3.275f;
                    else if (touchPosition.x > 8.89f && touchPosition.x < 9f)
                        localX = 3.45f;
                    else if (touchPosition.x > 8.99f && touchPosition.x < 9.1f)
                        localX = 3.625f;
                    else if (touchPosition.x > 9.09f && touchPosition.x < 9.2f)
                        localX = 3.8f;
                    else if (touchPosition.x > 9.19f && touchPosition.x < 9.3f)
                        localX = 3.975f;
                    else if (touchPosition.x > 9.29f && touchPosition.x < 9.4f)
                        localX = 4.15f;
                    else if (touchPosition.x > 9.39f && touchPosition.x < 9.5f)
                        localX = 4.325f;
                    else if (touchPosition.x > 9.49f && touchPosition.x < 9.6f)
                        localX = 4.5f;
                }

                //1
                //4,5
                //7,5
                //9,5
                transform.position = new Vector3(localX, transform.position.y, touchPosition.z);
                //debug.text = "Touch Position: " + touchPosition + "Transform Position: " + transform.position;
                //Debug.Log("Touch Position: " + touchPosition + "Transform Position: " + transform.position);
            }
        }
    }

    private void DetectTrash()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, Mathf.Infinity,
                layerMask) ||
            Physics.Raycast(transform.position + new Vector3(0f, 0f, 0.2f), transform.TransformDirection(direction),
                out hit, Mathf.Infinity, layerMask) ||
            Physics.Raycast(transform.position + new Vector3(0f, 0f, -0.2f), transform.TransformDirection(direction),
                out hit, Mathf.Infinity, layerMask) || Physics.Raycast(transform.position + new Vector3(0.1f, 0f, 0.0f),
                transform.TransformDirection(direction), out hit, Mathf.Infinity, layerMask))
        {
            var position = transform.position;
            Debug.DrawRay(position + new Vector3(0f, 0f, 0.2f), transform.TransformDirection(direction) * hit.distance,
                Color.red);
            Debug.DrawRay(position + new Vector3(0f, 0f, -0.2f), transform.TransformDirection(direction) * hit.distance,
                Color.red);
            Debug.DrawRay(position + new Vector3(0.1f, 0f, 0f), transform.TransformDirection(direction) * hit.distance,
                Color.red);
            Debug.DrawRay(position, transform.TransformDirection(direction) * hit.distance, Color.red);
            if (declareInput == DeclareInput.Mouse)
            {
                if (Input.GetMouseButtonDown(0))
                    OnButtonClick(hit);
                else if (Input.GetMouseButtonUp(0))
                    OnButtonUp(hit);
            }
            else if (declareInput == DeclareInput.Keyboard)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    OnButtonClick(hit);
                else if (Input.GetKeyUp(KeyCode.Space))
                    OnButtonUp(hit);
            }
            else if (declareInput == DeclareInput.Controller)
            {
                if (Input.GetAxis("Fire1_Joystick") >= 0.5f)
                    OnButtonClick(hit);
                else if (Input.GetAxis("Fire1_Joystick") <= 0.2f)
                    OnButtonUp(hit);
            }
            else if (declareInput == DeclareInput.Touch)
            {
                if (Input.touchCount == 1 && auxTouch == 0)
                {
                    OnButtonClick(hit);
                }
                else if ((Input.touchCount < 1 || touchPosition.x < 7.5f) && (auxTouch == 1))
                {
                    OnButtonUp(hit);
                    StartCoroutine(WaitATime());
                }
            }
        }
        else
        {
            var position = transform.position;
            Debug.DrawRay(position + new Vector3(0f, 0f, 0.2f), transform.TransformDirection(direction) * 1000,
                Color.white);
            Debug.DrawRay(position + new Vector3(0f, 0f, -0.2f), transform.TransformDirection(direction) * 1000,
                Color.white);
            Debug.DrawRay(position + new Vector3(0.1f, 0f, 0f), transform.TransformDirection(direction) * 1000,
                Color.white);
            Debug.DrawRay(position, transform.TransformDirection(direction) * 1000, Color.white);
        }
    }

    IEnumerator WaitATime()
    {
        yield return new WaitForSeconds(0.5f);
        auxTouch = 0;
    }

    private void OnButtonClick(RaycastHit hit)
    {
        if (hit.ToString() != "UnityEngine.RaycastHit")
        {
            return;
        }
        auxTouch = 1;
        Debug.Log("Hit: " + hit.ToString());
        timeCatch = Time.time;
        hit.transform.SetParent(transform);
        hit.transform.GetComponent<ScriptTrash>().toCatch = true;
        thrown.apertou = true;
        thrown.lixo = hit.transform.gameObject;
    }

    private void OnButtonUp(RaycastHit hit)
    {
        timeCatch -= Time.time;
        timeCatch *= -1;
        thrown.soltou = true;
        hit.transform.GetComponent<ScriptTrash>().timeHold = timeCatch;
        hit.transform.GetComponent<ScriptTrash>().toCatch = false;
        hit.transform.SetParent(null);
        if (declareInput != DeclareInput.Touch)
        {
            soundThrow.Play();
        }

        auxTouch = 0;
    }
}

public enum DeclareInput
{
    Controller,
    Mouse,
    Keyboard,
    Touch
};


/*Debug.DrawRay(transform.position + new Vector3(0f, 0f, 0.2f), transform.TransformDirection(direction) * hit.distance, Color.red);
            Debug.DrawRay(transform.position + new Vector3(0f, 0f, -0.2f), transform.TransformDirection(direction) * hit.distance, Color.red);
            Debug.DrawRay(transform.position + new Vector3(0.1f, 0f, 0f), transform.TransformDirection(direction) * hit.distance, Color.red);
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.red);*/


/*else
        {
            Debug.DrawRay(transform.position + new Vector3(0f, 0f, 0.2f), transform.TransformDirection(direction) * 1000, Color.white);
            Debug.DrawRay(transform.position + new Vector3(0f, 0f, -0.2f), transform.TransformDirection(direction) * 1000, Color.white);
            Debug.DrawRay(transform.position + new Vector3(0.1f, 0f, 0f), transform.TransformDirection(direction) * 1000, Color.white);
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * 1000, Color.white);
        }*/