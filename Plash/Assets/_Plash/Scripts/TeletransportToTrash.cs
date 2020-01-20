using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportToTrash : MonoBehaviour
{
    //Direção para onde o lixo vai, esquerda = 0, centro = 1, direita = 2
    [SerializeField]
    private int _direction;
    [SerializeField]
    private GameObject target;
    private TrashParabola parabola;
    private bool aux = true;

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Trash"))
        {
            aux = true;
            Destroy(obj.GetComponent<ScriptTrash>());
            /*if (obj.GetComponent<TrashParabola>() == false)
            {
                obj.gameObject.AddComponent<TrashParabola>();
            }*/
            parabola = obj.GetComponent<TrashParabola>();
            obj.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            parabola.LaunchTrash(_direction);
            parabola.AjustarColisor();

        }
    }
}
