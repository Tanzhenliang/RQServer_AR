using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleAndRotate : MonoBehaviour
{
    public Transform mtarget;
    public RectTransform ModelRenderImg;
    private Touch touch1,touch2;
    private Vector2 controllRectpos;
    private float width, height;

    private void Awake()
    {
        if (mtarget == null) {
            mtarget = transform;
        }
        if (ModelRenderImg == null) {
            ModelRenderImg = GameObject.Find("ModelImg").GetComponent<RectTransform>();
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount < 0) {
            return;
        }
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            //if (touch.position.x < controllRectpos.x - width / 2 || touch.position.x > controllRectpos.x + width / 2 || touch.position.y < controllRectpos.y - height / 2 || touch.position.y < controllRectpos.y + height / 2)
            //{
            //    return;
            //}
            if (RectTransformUtility.RectangleContainsScreenPoint(ModelRenderImg, touch.position)) {
                Vector2 deltapos = touch.deltaPosition;
                if (Mathf.Abs(deltapos.x)  > 10) {
                    mtarget.transform.Rotate(Vector3.down * deltapos.x * 0.1f, Space.World);
                    mtarget.transform.rotation = Quaternion.Euler(mtarget.transform.eulerAngles.x, mtarget.transform.eulerAngles.y,0);
                }
                if (Mathf.Abs(deltapos.y) > 10) {
                    mtarget.transform.Rotate(Vector3.right * deltapos.y * 0.1f, Space.World);
                    mtarget.transform.rotation = Quaternion.Euler(mtarget.transform.eulerAngles.x, mtarget.transform.eulerAngles.y, 0);
                }
                
               
            }
           
        }
        if (Input.touchCount == 2) {
            Touch newtouch1 = Input.GetTouch(0);
            Touch newtouch2 = Input.GetTouch(1);
            
            if (newtouch2.phase == TouchPhase.Began) {
                touch2 = newtouch2;
                touch1 = newtouch1;
                return;
            }
            if (RectTransformUtility.RectangleContainsScreenPoint(ModelRenderImg, newtouch1.position) && RectTransformUtility.RectangleContainsScreenPoint(ModelRenderImg, newtouch2.position))
            {
                float olddistance = Vector2.Distance(touch1.position, touch2.position);
                float newdistance = Vector2.Distance(newtouch1.position, newtouch2.position);
                float offset = newdistance - olddistance;
                float scaleFactor = offset / 200f;
                Vector3 mlocalscale = mtarget.transform.localScale;
                Vector3 scale = new Vector3(mlocalscale.x + scaleFactor, mlocalscale.y + scaleFactor, mlocalscale.z + scaleFactor);
                if (scale.x > 0.3f && scale.y > 0.3f && scale.z > 0.3f)
                {
                    mtarget.transform.localScale = scale;
                }

            }
            
            touch1 = newtouch1;
            touch2 = newtouch2;

        
        }
    }
}
