using UnityEngine;

public class TypeOfBlock : MonoBehaviour
{
    private Materials materials;
    private Material myMaterial;
    private GameObject myObject;
    private CheckPit verificarPit;

    void Awake()
    {
        materials = GameObject.FindWithTag("GameController").GetComponent<Materials>();
        verificarPit = GetComponentInChildren<CheckPit>();
    }
    void Start()
    {
        myObject = transform.GetChild(0).gameObject;
        //CheckMyMaterial();
    }

    public void CheckMyMaterial()
    {
        myMaterial = materials.ReturnMaterial(gameObject.tag);
        myObject.GetComponent<Renderer>().material = myMaterial;
        verificarPit.IsPitted();
        NeedColider();
    }

    private void NeedColider()
    {
        //Debug.Log("Essa tag do " + gameObject.name + " se chama " + gameObject.tag);
        if (!CompareTag("Blank"))
        {
            if(gameObject.GetComponent<BoxCollider>() != null)
                Destroy(gameObject.GetComponent<BoxCollider>());
            var box = gameObject.AddComponent<BoxCollider>();
            box.size = new Vector3(0.9f, 0.9f, 0.9f);
            box.center = new Vector3(0f, 0.3f, 0f);
            box.isTrigger = true;
        }
        else if(CompareTag("Blank"))
        {
            if (gameObject.GetComponent<BoxCollider>() != null)
                Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }
}
