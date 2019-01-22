using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts
{
    class PoleSpawner : MonoBehaviour
    {

        private int rotation;
        private int x;
        private int y;
        private int z;

        public int poleInterval;

        private Random random = new Random();

        public List<GameObject> obstacles;

        private float distanceSinceLastPole;
        private float lastZ;

        public PoleSpawner()
        {
            rotation = 0;
            x = 0;
            y = 0;
            z = 0;
        }

        private void Update()
        {
            distanceSinceLastPole += this.gameObject.transform.position.z - lastZ;
            if (distanceSinceLastPole > poleInterval)
            {
                next();
                ShipController.Instance.score += Mathf.RoundToInt(distanceSinceLastPole);
                distanceSinceLastPole = 0;
            }
            lastZ = this.gameObject.transform.position.z;
        }

        public void next()
        {
            GameObject obj = Instantiate(obstacles[random.Next(obstacles.Capacity)]);
            obj.transform.position += new Vector3(0, 0, ShipController.Instance.gameObject.transform.position.z + 100);
        }

    }
}
