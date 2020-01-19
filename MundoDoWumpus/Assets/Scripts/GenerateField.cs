using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GenerateField : MonoBehaviour
{
    public GameObject[] campos = new GameObject[]{};
    public int DefaultPit, DefaultMonster, DefaultGold, DefaultBlank;

    //0 = Pit, 1 = Monster, 2 = Gold, 3 = Blank
    private int pit, monster, gold, blank, total;
    
    void Start()
    {
        AtualizarCampos();
        //Debug.Log("Quantidade Padrao é: Pit - " + DefaultPit + " Monster - " + DefaultMonster + " Gold - " + DefaultGold + " Blank - " + DefaultBlank);
    }


    public void Restart(){
        SceneManager.LoadScene(0);
    }

    public void AtualizarCampos(){
        RestartValues();
        foreach (GameObject item in campos)
        {
            if(item.gameObject.name == "1-1")
            {
                item.gameObject.tag = "Player";
            }else if(item.gameObject.name == "1-2"){
                item.gameObject.tag = "Blank";
                blank--;
            }else if(item.gameObject.name == "2-1"){
                item.gameObject.tag = "Blank";
                blank--;
            }
            else{
                if(total > 0){
                    var free = false;
                    while(!free){
                        var tipo = Random.Range(0,10);
                        if(tipo >= 0 && tipo < 3 && pit > 0){
                            item.gameObject.tag = "Pit";
                            free = !free;
                            pit--;
                        }else if(tipo == 3 && monster > 0){
                            item.gameObject.tag = "Monster";
                            free = !free;
                            monster--;
                        }else if(tipo == 4 && gold > 0){
                            item.gameObject.tag = "Gold";
                            free = !free;
                            gold--;
                        }else if(tipo >= 5 && blank > 0){
                            item.gameObject.tag = "Blank";
                            free = !free;
                            blank--;
                        }
                    }
                    total--;
                    item.GetComponent<TypeOfBlock>().CheckMyMaterial();
                }
            }
        }
    }

    private void RestartValues(){
        gold = DefaultGold;
        monster = DefaultMonster;
        pit = DefaultPit;
        blank = DefaultBlank;
        total = pit+monster+gold+blank;
    }
}
