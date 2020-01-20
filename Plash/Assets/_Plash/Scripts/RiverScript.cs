using UnityEngine;

public class RiverScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer colorRiver;
    
    
    // Start is called before the first frame update
    void Start()
    {
        colorRiver = GetComponent<MeshRenderer>();
        colorRiver.material.color = new Color(0.196f, 0.196f, 0.196f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreGame.scorePoint <= 60)
        {
            colorRiver.material.color = new Color(0.196f, 0.196f, 0.196f);
        }
        else if (ScoreGame.scorePoint > 60 && ScoreGame.scorePoint <= 120)
        {
            ChangeColor(new Color(0.196f, 0.26f, 0.5f));
        }
        else if (ScoreGame.scorePoint > 120 && ScoreGame.scorePoint <= 180)
        {
            ChangeColor(new Color(0.196f, 0.5f, 0.7f));
        }
        else
        {
            ChangeColor(new Color(0.196f, 0.5f, 1));
        }
    }

    /// <summary>
    /// Faz a interpolação entre a cor atual e a nova cor
    /// </summary>
    /// <param name="color">Nova cor desejada</param>
    private void ChangeColor(Color color)
    {
        colorRiver.material.color = Color.Lerp(colorRiver.material.color, color, Time.deltaTime);
    }
}
