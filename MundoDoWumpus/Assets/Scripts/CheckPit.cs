using UnityEngine;

public class CheckPit : MonoBehaviour
{
    [SerializeField] private GameObject breezeObject;
    [SerializeField] private GameObject stenchObject;
    public void IsPitted()
    {
        RemoveChilds();
        if (transform.parent.CompareTag("Pit"))
        {
            var objeto = Instantiate(breezeObject, transform.position + new Vector3(1f, 0f, 0f), Quaternion.Euler(0f, 180f, 0f));
            objeto.transform.parent = gameObject.transform;

            objeto = Instantiate(breezeObject, transform.position + new Vector3(-1f, 0f, 0f), Quaternion.Euler(0f, 180f, 0f));
            objeto.transform.parent = gameObject.transform;

            objeto = Instantiate(breezeObject, transform.position + new Vector3(0f, 1f, 0f), Quaternion.Euler(0f, 180f, 0f));
            objeto.transform.parent = gameObject.transform;

            objeto = Instantiate(breezeObject, transform.position + new Vector3(0f, -1f, 0f), Quaternion.Euler(0f, 180f, 0f));
            objeto.transform.parent = gameObject.transform;
        }else if(transform.parent.CompareTag("Monster"))
        {
            var objeto = Instantiate(stenchObject, transform.position + new Vector3(1f, 0f, 0f), Quaternion.Euler(0f, 180f, 0f));
            objeto.transform.parent = gameObject.transform;

            objeto = Instantiate(stenchObject, transform.position + new Vector3(-1f, 0f, 0f), Quaternion.Euler(0f, 180f, 0f));
            objeto.transform.parent = gameObject.transform;

            objeto = Instantiate(stenchObject, transform.position + new Vector3(0f, 1f, 0f), Quaternion.Euler(0f, 180f, 0f));
            objeto.transform.parent = gameObject.transform;

            objeto = Instantiate(stenchObject, transform.position + new Vector3(0f, -1f, 0f), Quaternion.Euler(0f, 180f, 0f));
            objeto.transform.parent = gameObject.transform;
        }
    }

    public void RemoveChilds()
    {
        foreach (Transform filho in transform)
        {
            Destroy(filho.gameObject);
        }
    }
}
