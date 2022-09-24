using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClockwise : MonoBehaviour
{
    private Tween activeTween;

    private List<Vector3> areastoVisit = new();
    private float startedAnimation = 0.0f;

    public Animator animator;

    public AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        setAreasToVisit();
        visitFirstArea();
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
                handleDeadState();
            }
        }
    }

    void AddTween(Vector3 areaToVisit)
    {
        activeTween = new Tween(gameObject.transform, gameObject.transform.position, areaToVisit, Time.time, 3.0f);
    }

    void setAreasToVisit()
    {
        areastoVisit.Add(new Vector3(-5.5f, 4.5f, 0f));
        areastoVisit.Add(new Vector3(-0.5f, 4.5f, 0f));
        areastoVisit.Add(new Vector3(-0.5f, 0.5f, 0f));
        areastoVisit.Add(new Vector3(-5.5f, 0.5f, 0f));
    }

    void visitAreas()
    {
        Vector3 areaToVisit;
        playWalkSound();
        if (areastoVisit.IndexOf(activeTween.EndPos) + 1 == areastoVisit.Count)
        {
            areaToVisit = areastoVisit[0];
        }
        else
        {
            areaToVisit = areastoVisit[areastoVisit.IndexOf(activeTween.EndPos) + 1];
        }

        AddTween(areaToVisit);
    }

    void visitFirstArea()
    {
        playWalkSound();
        AddTween(areastoVisit[1]);
    }

    void playWalkSound()
    {
        audioSrc.Stop();
        audioSrc.Play();
    }

    void handleDeadState()
    {
        if (activeTween.EndPos == areastoVisit[0])
        {
            startedAnimation += Time.deltaTime;
            animator.SetBool("PlayDead", true);
            Debug.Log(animator.GetBool("PlayDead"));

            if (animator.GetBool("PlayDead") && (startedAnimation > 3.23f))
            {
                animator.SetBool("PlayDead", false);
                startedAnimation = 0.0f;
                visitAreas();
            }
        }
        else
        {
            visitAreas();
        }
    }
}
