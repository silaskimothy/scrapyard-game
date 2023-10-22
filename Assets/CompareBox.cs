using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareBox : MonoBehaviour
{
    public bool CurrentActive;
    public static bool IsActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentActive)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        } else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        if (IsActive && CurrentActive)
        {
            IsActive = false;
            CurrentActive = false;
        } else if (IsActive)
        {
            return;
        }

        IsActive = true;
        CurrentActive = true;
    }
}
