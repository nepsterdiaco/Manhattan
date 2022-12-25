using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diaco
{
    public class LimitRotation : MonoBehaviour
    {
        public float MinRotate = 0.0f;
        public float MaxRotate = 0.0f;
        private void LateUpdate()
        {
            //Debug.Log(transform.localRotation + "..........." + transform.localEulerAngles);
            // transform.localEulerAngles = new Vector3(0, MinRotate, 0);
            var s = RoundAngle2(transform.localEulerAngles.y);
            var temp_angle = Mathf.Clamp(s, MinRotate, MaxRotate);
            transform.localEulerAngles = new Vector3(0, temp_angle, 0);
        }


        float RoundAngle2(float angle)
        {
            // Make sure that we get value between (-360, 360], we cannot use here module of 180 and call it a day, because we would get wrong values
            angle %= 360;
            if (angle > 180)
            {
                // If we get number above 180 we need to move the value around to get negative between (-180, 0]
                return angle - 360;
            }
            else if (angle < -180)
            {
                // If we get a number below -180 we need to move the value around to get positive between (0, 180]
                return angle + 360;
            }
            else
            {
                // We are between (-180, 180) so we just return the value
                return angle;
            }
        }
    }
}
