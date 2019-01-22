using Assets.scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class PlaneControls
    {

        public static float movementFloatiness = 0.01f;
        private static float moveTarget;
        public static void Move(float z)
        {
            if (Manager.paused) return;
            if (!ShipController.Instance.collide)
            {
                z *= ShipController.Instance.verticalSpeedModifier;
                if (ShipController.Instance.flipControls)
                    z *= -1;

                moveTarget += z * 1.5f;

                float calc = Mathf.Lerp(0, moveTarget, movementFloatiness);

                moveTarget -= calc;

                float h = Mathf.Sqrt(Mathf.Pow(calc, 2) + Mathf.Pow(ShipController.Instance.currentSpeed, 2));
                float t = Mathf.Sin(calc / h);
                if (h == 0) t = 0;
                ShipController.Instance.customRotate = new Vector3(ShipController.Instance.customRotate.x, ShipController.Instance.customRotate.y, Mathf.Rad2Deg * t);

                float horizontalDistance = calc * Mathf.Sin(Mathf.Deg2Rad * ShipController.Instance.customRotate.x);
                float verticalDistance = calc * Mathf.Cos(Mathf.Deg2Rad * ShipController.Instance.customRotate.x);

                float frameScale = Time.deltaTime * 50;

                ShipController.Instance.gameObject.transform.position += Vector3.left * horizontalDistance * frameScale;
                ShipController.Instance.gameObject.transform.position += Vector3.up * verticalDistance * frameScale;
            }
        }

        public static float rotateFloatiness = 0.1f;
        private static float rotTarget;
        public static void Rotate(float speed)
        {
            if (Manager.paused) return;
            if (!ShipController.Instance.collide)
            {
                float boost = 15;

                rotTarget += speed * 1.4f;
                float calc = Mathf.Lerp(0, rotTarget, rotateFloatiness);

                ShipController.Instance.customRotate += Vector3.left * boost * calc * Time.deltaTime * 18;

                rotTarget -= calc;

                var rot = ShipController.Instance.customRotate;

                if (ShipController.Instance.customRotate.x >= 360)
                    rot.x -= 360;
                if (ShipController.Instance.customRotate.x <= -360)
                    rot.x += 360;
                ShipController.Instance.gameObject.transform.eulerAngles = ShipController.Instance.customRotate;
            }
        }
    }
}
