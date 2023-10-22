using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VarBox : MonoBehaviour
{
    public Var Type;

    public bool UseNumber;
    public string Amount;

    public bool CurrentActive;
    public static bool IsActive = false;

    void Update()
    {
        if (CurrentActive)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = CalColor(Type);
        }
    }

    private void OnMouseDown()
    {
        //GetComponent<SpriteRenderer>().color = Color.black;
        if (IsActive && CurrentActive)
        {
            IsActive = false;
            CurrentActive = false;
        }
        else if (IsActive)
        {
            return;
        }

        IsActive = true;
        CurrentActive = true;
    }

    public Color CalColor(Var Style)
    {
        if (Amount != "")
        {
            return new Color(1, 1, 1) * Random.Range(0, 1f);
        }

        switch (Style)
        {
            case 0:
                {
                    return Color.cyan;
                }
            case (Var) 1:
                {
                    return Color.yellow;
                }
            case (Var) 2:
                {
                    return Color.white;
                }
            case (Var) 3:
                {
                    return Color.magenta;
                }
            case (Var) 4:
                {
                    return Color.blue;
                }
            case (Var) 5:
                {
                    return Color.red;
                }
        }

        return new Color(1, 1, 1) * Random.Range(0, 1f);
    }
}
public enum Var
{
    CardType = 0,
    Sigil = 1,
    CostBone = 2,
    CostBlood = 3,
    Attack = 4,
    HP = 5,
}