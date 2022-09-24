using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClockwise : MonoBehaviour
{
    private Tween activeTween;

    private List<Vector3> areastoVisit = new();

    // Start is called before the first frame update
    void Start()
    {
        areastoVisit.Add(new Vector3(-5.5f, 4.5f, 0f));
        areastoVisit.Add(new Vector3(-0.5f, 4.5f, 0f));
        areastoVisit.Add(new Vector3(-0.5f, 0.5f, 0f));
        areastoVisit.Add(new Vector3(-5.5f, 0.5f, 0f));

        activeTween = new Tween(gameObject.transform, gameObject.transform.position, new Vector3(-0.5f, 4.5f, 0f), Time.time, 3.0f);

        // activeTweens.Add(new Tween(gameObject.transform, gameObject.transform.position, new Vector3(-5.5f, 0.5f, 0f), Time.time + 4.0f, 2.0f));
        // activeTweens.Add(new Tween(gameObject.transform, gameObject.transform.position, new Vector3(-5.5f, 4.5f, 0f), Time.time + 6.0f, 2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null)
        {
            float percentageComplete = (Time.time - activeTween.StartTime) / activeTween.Duration;
            float distanceFromTarget = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);

            if (distanceFromTarget > 0.1f)
            {
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, percentageComplete);
            }
            else if (distanceFromTarget <= 0.1f)
            {
                activeTween.Target.position = activeTween.EndPos;
                AddTween();
            }
        }
    }

    void AddTween()
    {
        Vector3 areaToVisit;
        Debug.Log(areastoVisit.Count);

        if (areastoVisit.IndexOf(activeTween.EndPos) + 1 == areastoVisit.Count)
        {
            areaToVisit = areastoVisit[0];
        }
        else
        {
            areaToVisit = areastoVisit[areastoVisit.IndexOf(activeTween.EndPos) + 1];
        }
        activeTween = new Tween(gameObject.transform, gameObject.transform.position, areaToVisit, Time.time, 3.0f);
    }
}
