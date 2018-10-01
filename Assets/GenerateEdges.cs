using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEdges : MonoBehaviour
{
    public float widthOfCollider = 2f;
    public float z_axis = 0f;
    private Vector2 screenSize;
    public GameObject background;

    void Start()
    {
        Dictionary<string, Transform> colliders = new Dictionary<string, Transform>();
        //Create GameObjects and add their Transform components to the Dictionary created above
        colliders.Add("Top",new GameObject().transform);
        colliders.Add("Bottom",new GameObject().transform);
        colliders.Add("Right",new GameObject().transform);
        colliders.Add("Left",new GameObject().transform);
       
        Vector3 cameraPos = Camera.main.transform.position;
        screenSize.x = background.wid
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0,0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
       
        foreach(KeyValuePair<string, Transform> bc in colliders) {
            bc.Value.gameObject.AddComponent<BoxCollider2D>();
            //give the objects a name
            bc.Value.name = bc.Key + "Collider";
            bc.Value.parent = transform;
            if (bc.Key == "Left" || bc.Key == "Right") {
                bc.Value.localScale = new Vector3(widthOfCollider, screenSize.y * 2, widthOfCollider);
            } else {
                bc.Value.localScale = new Vector3(screenSize.x * 2, widthOfCollider, widthOfCollider);
            }
        }
   
        colliders["Right"].position = new Vector3(cameraPos.x + screenSize.x + (colliders["Right"].localScale.x* 0.5f), cameraPos.y, z_axis);
        colliders["Left"].position = new Vector3(cameraPos.x - screenSize.x - (colliders["Left"].localScale.x* 0.5f), cameraPos.y, z_axis);
        colliders["Top"].position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (colliders["Top"].localScale.y* 0.5f), z_axis);
        colliders["Bottom"].position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (colliders["Bottom"].localScale.y* 0.5f), z_axis);
     }
}
