using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class Animal : MonoBehaviour
    {
        protected int currentPoint;

        protected virtual void Move(float speed, Transform[] movePoint, GameObject animalName)
        {
            if (animalName.transform.localScale.x == -1) currentPoint = movePoint.Length-1;
            if (Vector2.Distance(movePoint[currentPoint].position, animalName.transform.position) < .1f)
            {
                animalName.transform.localScale = new Vector3(animalName.transform.localScale.x*(-1),animalName.transform.localScale.y,1);
                currentPoint++;
                if (currentPoint >= movePoint.Length) currentPoint = 0;
            }
            animalName.transform.position = Vector2.MoveTowards(animalName.transform.position, movePoint[currentPoint].position, speed * Time.deltaTime);
        }
    }
}