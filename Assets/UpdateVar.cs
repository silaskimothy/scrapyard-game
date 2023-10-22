using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UpdateVar : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject[] Ook = GameObject.FindGameObjectsWithTag("Var");
            foreach (var o in Ook)
            {
                o.GetComponent<VarBox>().CurrentActive = false;
            }
            VarBox.IsActive = false;

            GameObject[] Book = GameObject.FindGameObjectsWithTag("Compare");
            foreach (var o in Book)
            {
                o.GetComponent<CompareBox>().CurrentActive = false;
            }
            CompareBox.IsActive = false;

            GameObject[] Pook = GameObject.FindGameObjectsWithTag("Under");
            foreach (var o in Pook)
            {
                try
                {
                    o.GetComponent<IfStatement>().Selected = false;
                } catch
                {
                    o.GetComponent<ListStatement>().Selected = false;
                }
            }
        }
    }

    public void TextSet(TMP_InputField Field)
    {
        GameObject[] Ook = GameObject.FindGameObjectsWithTag("Var");
        foreach (var o in Ook)
        {
            if (o.GetComponent<VarBox>().CurrentActive)
            {
                VarBox N = o.GetComponent<VarBox>();

                Debug.Log(N.CurrentActive + " " + VarBox.IsActive);

                N.CurrentActive = false;
                VarBox.IsActive = false;
                N.Amount = Field.text;
            }
        }
    }

    public void UpVar(TMP_Dropdown Menu)
    {
        GameObject[] Ook = GameObject.FindGameObjectsWithTag("Var");
        foreach (var o in Ook)
        {
            if (o.GetComponent<VarBox>().CurrentActive)
            {
                VarBox N = o.GetComponent<VarBox>();

                Debug.Log(N.CurrentActive + " " + VarBox.IsActive);

                N.CurrentActive = false;
                VarBox.IsActive = false;

                switch (Menu.options[Menu.value].text)
                {
                    case "Card Type":
                        {
                            N.Type = Var.CardType;
                            break;
                        }
                    case "Sigil":
                        {
                            N.Type = Var.Sigil;
                            break;
                        }
                    case "Cost (Scrap)":
                        {
                            N.Type = Var.CostBone;
                            break;
                        }
                    case "Cost (Charge)":
                        {
                            N.Type = Var.CostBlood;
                            break;
                        }
                    case "Attack":
                        {
                            N.Type = Var.Attack;
                            break;
                        }
                    case "HP":
                        {
                            N.Type = Var.HP;
                            break;
                        }
                }
            }
        }
    }
}