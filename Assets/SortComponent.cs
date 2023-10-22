using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortComponent : MonoBehaviour
{
    public Style Type;

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

    public Color CalColor(Style Style)
    {
        switch (Style)
        {
            case 0:
                {
                    return Color.blue;
                }
            case (Style)1:
                {
                    return Color.yellow;
                }
            case (Style)2:
                {
                    return Color.red;
                }
            case (Style)3:
                {
                    return Color.magenta;
                }
        }

        return new Color(1, 1, 1) * Random.Range(0, 1f);
    }
}
public enum Style
{
    PlayerField = 0,
    PlayerHand = 1,
    EnemyField = 2,
    EnemyIncomming = 3,
}
