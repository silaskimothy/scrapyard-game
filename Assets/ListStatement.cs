using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListStatement : MonoBehaviour
{
    public bool IsDemo;
    public bool Drag;
    public bool Selected;
    public bool ActiveAdd;
    public static bool AddToStatement;
    public GameObject Roof;
    public GameObject Wall;
    public GameObject Floor;
    public int LengthIncrease;

    List<GameObject> NewList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Selected)
        {
            Roof.GetComponent<SpriteRenderer>().color = Color.black;
            Wall.GetComponent<SpriteRenderer>().color = Color.black;
            Floor.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            Roof.GetComponent<SpriteRenderer>().color = Color.blue;
            Wall.GetComponent<SpriteRenderer>().color = Color.blue;
            Floor.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        //if (NewList.Count > 0)
        //Debug.Log(NewList.Count);

        int BarLength = 2;

        for (int x = 0; x < NewList.Count; x++)
        {
            NewList[x].transform.localPosition = transform.localPosition + new Vector3(.2f, -(x + 1) * Roof.transform.localScale.y * .55f, 0);
            try { BarLength += NewList[x].GetComponent<ListStatement>().LengthIncrease; } catch { BarLength += NewList[x].GetComponent<IfStatement>().LengthIncrease; };
        }

        Wall.transform.localScale = new Vector3(Wall.transform.localScale.x, BarLength, 1);
        Wall.transform.localPosition = new Vector3(-.88f, -BarLength / 2 + 1, 0);
        Floor.transform.localPosition = new Vector3(0, -BarLength + 1f, 0);

        if (Selected)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !AddToStatement)
            {
                Drag = !Drag;
            }
            if (Input.GetKeyDown(KeyCode.W) && !Drag)
            {
                ActiveAdd = !ActiveAdd;
                AddToStatement = !AddToStatement;
            }
            //Debug.Log(AddToStatement);
        }
        else
        {
            Drag = false;
            ActiveAdd = false;
        }

        if (Drag)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(AddToStatement + " " + ActiveAdd);
        if (AddToStatement && !ActiveAdd || IfStatement.AddToStatement)
        {
            AddToStatement = false;
            GameObject[] AllowUnder = GameObject.FindGameObjectsWithTag("Under");
            for (int x = 0; x < AllowUnder.Length; x++)
            {
                try
                {
                    if (AllowUnder[x].GetComponent<ListStatement>().ActiveAdd)
                    {
                        AllowUnder[x].GetComponent<ListStatement>().AddStatement(gameObject);
                        AllowUnder[x].GetComponent<ListStatement>().ActiveAdd = false;
                        return;
                    }
                }
                catch {
                    if (AllowUnder[x].GetComponent<IfStatement>().ActiveAdd)
                    {
                        AllowUnder[x].GetComponent<IfStatement>().AddStatement(gameObject);
                        AllowUnder[x].GetComponent<IfStatement>().ActiveAdd = false;
                        return;
                    }
                }
            }
            return;
        }

        GameObject[] IsSelect = GameObject.FindGameObjectsWithTag("Under");
        for (int x = 0; x < IsSelect.Length; x++)
        {
            try
            {
                if (IsSelect[x].GetComponent<ListStatement>().Selected)
                {
                    IsSelect[x].GetComponent<ListStatement>().Selected = false;
                }
            }
            catch { }
        }

        if (IsDemo)
        {
            ListStatement CreateIfStatemnt = Instantiate(gameObject).GetComponent<ListStatement>();
            CreateIfStatemnt.transform.localScale *= 2;
            CreateIfStatemnt.Selected = true;
            CreateIfStatemnt.Drag = true;
            CreateIfStatemnt.IsDemo = false;
        }
        else
        {
            Selected = !Selected;
        }
    }

    public void AddStatement(GameObject Item)
    {
        NewList.Add(Item);
    }
}
