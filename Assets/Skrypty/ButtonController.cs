using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;
    public Touch touchPress;


    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        // if(Input.touchCount  == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        // {
        //     theSR.sprite = pressedImage;  
        // }
        // if(Input.touchCount < 1)
        // {
        //     theSR.sprite = defaultImage;
        // }

    }


private void OnMouseDown() {
    Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   //Debug.Log(p);

    RaycastHit2D hit = Physics2D.Raycast(p, -Vector2.up);
    if (hit.collider != null)
        {
            Debug.Log("HIT");

            Debug.Log(hit.collider.gameObject.name);

             theSR.sprite = pressedImage;  
        }
   
}

private void OnMouseUp() {
    theSR.sprite = defaultImage;
}

public bool selectcheck(Vector2 firstpos, Vector2 secondpos)
{
    var rect = Rect.MinMaxRect(firstpos.x, firstpos.y, secondpos.x, secondpos.y);
    return rect.Contains(transform.position, true);
}
}
