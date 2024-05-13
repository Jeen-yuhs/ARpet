using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField] private Animator petAnimation;
    public float speedThreshold = 0.1f; // The speed threshold to change animation

    private Vector3 lastPosition;  // Store the last position
    private float lastTime;        // Store the last time position was recorded

    private WaitForSeconds quartSec = new WaitForSeconds(.25f);

    
    //Control the animation state, so that 
    private PetAnimationState AnimationState;
    void Start()
    {
        petAnimation = GetComponent<Animator>();
        lastPosition = transform.position;  // Initialize last position
        lastTime = Time.time;
        StartCoroutine(ControlState());
        AnimationState = PetAnimationState.isIdle;
    }
    
    public enum PetAnimationState
    {
        isIdle, 
        isWalking,
    }
    
    IEnumerator ControlState()
    {
        while (true)
        {
            // Calculate elapsed time
            float elapsedTime = Time.time - lastTime;

            // Calculate the distance traveled since the last frame
            float distance = Vector3.Distance(transform.position, lastPosition);

            // Calculate the speed
            float speed = distance / elapsedTime;

            // Update last time and last position for the next frame
            lastTime = Time.time;
            lastPosition = transform.position;
            
            Debug.Log("CurrentState is => " + AnimationState);

            
            //Change Animation based on speed
            if (speed > speedThreshold)
            {
                if (AnimationState != PetAnimationState.isWalking)
                {
                    Debug.Log("Set to is Walking, Animation State => " + AnimationState);
                    ChangeToState("setWalk");
                    AnimationState = PetAnimationState.isWalking;
                }
            }
            else if(AnimationState != PetAnimationState.isIdle)
            {
                Debug.Log("Set to is Idle =>" + AnimationState);
                ChangeToState("setIdle");
                AnimationState = PetAnimationState.isIdle;

            }            
            yield return quartSec;
        }
        yield return null;
    }

    //Change one bool to true and the others to false
    void ChangeToState(string setToState)
    {
        foreach (var param in petAnimation.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Bool)
            {
                petAnimation.SetBool(param.name, param.name == setToState ? true : false);
            }
        }
    }
}





