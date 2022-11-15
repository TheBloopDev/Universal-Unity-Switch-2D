using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider2D))]
public class SwitchScript2D : MonoBehaviour
{
    public LayerMask PlayerLayer;
    private BoxCollider2D box2d;
    public KeyCode KeyForSwitch;
    private bool inarea = false;
    public UnityEvent EventToDo;
    private bool hasbeeninvoked = false;
    void Start()
    {
      box2d = this.gameObject.GetComponent<BoxCollider2D>();
      box2d.isTrigger = true;
    }

    
    void Update()
    {
        if(inarea){
            if(Input.GetKeyDown(KeyForSwitch) && !hasbeeninvoked){
                EventToDo.Invoke();
                hasbeeninvoked = true;
            }
        }
        

        
    }
    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log (collision.gameObject.layer);
        if (PlayerLayer == (PlayerLayer | (1 << collision.gameObject.layer))) {
         Debug.Log (collision.gameObject.layer);
         inarea = true;
     }
    }
    void OnTriggerExit2D(Collider2D collision){
        Debug.Log (collision.gameObject.layer);
        if (PlayerLayer == (PlayerLayer | (1 << collision.gameObject.layer))) {
         Debug.Log (collision.gameObject.layer);
         inarea = false;
     }
    }
}
