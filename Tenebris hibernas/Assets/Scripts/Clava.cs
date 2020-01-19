using UnityEngine;

public class Clava : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float torque = 10.0f;
    public bool atingiuDireita = false;
    public bool atingiuEsquerda = true;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.centerOfMass = Vector2.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            rb2d.AddTorque(10.0f);

        if (Input.GetKeyDown(KeyCode.Y))
            rb2d.AddTorque(-10.0f);

        Physics();
    }

    private void Physics()
    {
        if (rb2d.rotation > 60.0f)
        {
            //rb2d.angularVelocity = 15.0f;
            atingiuDireita = true;
            atingiuEsquerda = false;
        }
        else if (rb2d.rotation < -60.0f)
        {
            //rb2d.angularVelocity = -15.0f;
            atingiuDireita = false;
            atingiuEsquerda = true;
        }

        if (!atingiuDireita)
        {
            rb2d.AddTorque(torque * Time.deltaTime);
        }
        else if (atingiuDireita)
        {
            rb2d.AddTorque(-torque * Time.deltaTime);
        }

    }
}
