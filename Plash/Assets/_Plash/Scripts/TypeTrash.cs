using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TypeTrash : MonoBehaviour
{
    public Type type;
    public int belongTo;
    public int fase;
    [SerializeField] private Instanciador getFase;
    

    [SerializeField] private GameObject[] papel;
    [SerializeField] private GameObject[] plastico; 
    [SerializeField] private GameObject[] metal;
    [SerializeField] private GameObject[] vidro;
    [SerializeField] private GameObject[] hospitalar;
    [SerializeField] private GameObject[] radioativo;


    private void Awake()
    {
        getFase = FindObjectOfType<Instanciador>().GetComponent<Instanciador>();

        fase = getFase.fase;
    }

    void Start()
    {
        if (fase == 1)
        {
            type = RandomType(Type.Plastico, Type.Papel + 1);//troquei para ir até papel por hora
            
            if(type == Type.Plastico)
            {
                plastico[RandomTrash()].SetActive(true);
            }
            else if(type == Type.Metal)
            {
                metal[RandomTrash()].SetActive(true);
            }
            else if(type == Type.Papel)
            {
                papel[RandomTrash()].SetActive(true);
            }
        }
        else if (fase == 2)
        {
            type = RandomType(Type.Vidro, Type.Radioativo + 1);//troquei para ir até papel por hora
            
            if(type == Type.Vidro)
            {
                vidro[RandomTrash()].SetActive(true);
            }
            else if(type == Type.Hospitalar)
            {
                hospitalar[RandomTrash()].SetActive(true);
            }
            else if(type == Type.Radioativo)
            {
                radioativo[RandomTrash()].SetActive(true);
            }
        }
        else
        {
            type = RandomType(Type.Plastico, Type.Papel + 1);//troquei para ir até papel por hora
            
            if(type == Type.Plastico)
            {
                plastico[RandomTrash()].SetActive(true);
            }
            else if(type == Type.Metal)
            {
                metal[RandomTrash()].SetActive(true);
            }
            else if(type == Type.Papel)
            {
                type = Type.Radioativo; 
                radioativo[RandomTrash()].SetActive(true);
            }
        }
        

        Destroy(gameObject, 23f);
    }

    Type RandomType (Type min, Type max)
    {
        int randType = Random.Range((int) min, (int) max);
        return (Type) randType;
    }

    int RandomTrash ()
    {
        return Random.Range(0, 1);
    }
}


public enum Type { Plastico = 0, Metal = 1, Papel = 2, Vidro = 3, Hospitalar = 4, Radioativo = 5 }
