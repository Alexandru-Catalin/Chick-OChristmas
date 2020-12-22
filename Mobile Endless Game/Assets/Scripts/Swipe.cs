using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public float speed = 10f;
    CharacterController cc;
    bool canMove = true;
    private int line = 1;
    private int targetLine = 1;
    Vector3 movec = Vector3.zero;

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        if (!line.Equals(targetLine))
        {
            if (targetLine == 0 && pos.x < -4)
            {
                gameObject.transform.position = new Vector3(-4f, 1.4f, pos.z);
                line = targetLine;
                canMove = true;
                movec.x = 0;
            }
            else if (targetLine == 1 && (pos.x > 0 || pos.x < 0))
            {
                if (line == 0 && pos.x >= 0)
                {
                    gameObject.transform.position = new Vector3(0, 1.4f, pos.z);
                    line = targetLine;
                    canMove = true;
                    movec.x = 0;
                }
                else if (line == 2 && pos.x <= 0)
                {
                    gameObject.transform.position = new Vector3(0, 1.4f, pos.z);
                    line = targetLine;
                    canMove = true;
                    movec.x = 0;
                }
            }
            else if (targetLine == 2 && pos.x > 4)
            {
                gameObject.transform.position = new Vector3(4f, 1.4f, pos.z);
                line = targetLine;
                canMove = true;
                movec.x = 0;
            }
        }

        CheckInputs();
        cc.Move(movec * Time.deltaTime);
        speed += 0.4f * Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime;
      
        void CheckInputs()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove && line > 0)
            {
                targetLine--;
                canMove = true;
                movec.x = -40;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && canMove && line < 2)
            {
                targetLine++;
                canMove = true;
                movec.x = 40;
            }
        }
    }

}
