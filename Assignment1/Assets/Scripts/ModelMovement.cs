using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMovement : MonoBehaviour
{
    public Animator anim;
    private Vector3 movementVector;
    public float speed = 100f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movementVector = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            try
            {
                if (hit.collider.tag == "Ground")
                {
                    Vector3 v = hit.point;
                    movementVector = new Vector3(v.x, transform.position.y, v.z);
                    transform.LookAt(movementVector);
                }
            }
            catch
            {
            }
            iTween.MoveTo(gameObject, movementVector, 20f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Animation>().Play("0008_Win"); 
    }
}
