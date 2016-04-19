 /// <summary>
/// 
/// </summary>

using UnityEngine;
using System;
using System.Collections;

//Team X - Implementation by SGossner
//Bear dying
  
[RequireComponent(typeof(Animator))]  

//Name of class must be name of file as well

public class Bear : MonoBehaviour {
	
	public float AvatarRange = 25;
    public int Sound = 0;



	public AudioClip[] bearFootSteps;						//Useful for not hard-coding too many specifics in later use of SoundManager.
//	public AudioClip bearFootSteps1;						//Used for manual input of each AudioClip instead of using an Array
//	public AudioClip bearFootSteps2;
//	public AudioClip bearFootSteps3;
	public AudioClip bearDeath;								//Bouncing off the SoundManager with function SoundManager.instance.userFunctionHere(whatNeedsToBePlacedInReturn). ~Mac

    protected Animator avatar;
	
	private float SpeedDampTime = .25f;	
	private float DirectionDampTime = .25f;	
	private Vector3 TargetPosition = new Vector3(0,0,0);

	
	// Use this for initialization
	void Start () 
	{
		avatar = GetComponent<Animator>();
	}
    
	void Update () 
	{
		if(avatar)
		{
            int rand = UnityEngine.Random.Range(0, 50);

            avatar.SetBool("Jump", rand == 20);
            avatar.SetBool("Dive", rand == 30);
			
			if(Vector3.Distance(TargetPosition,avatar.rootPosition) > 5)
			{
				avatar.SetFloat("Speed",1,SpeedDampTime, Time.deltaTime);
				
				Vector3 curentDir = avatar.rootRotation * Vector3.forward;
				Vector3 wantedDir = (TargetPosition - avatar.rootPosition).normalized;
	
				if(Vector3.Dot(curentDir,wantedDir) > 0)
				{
					avatar.SetFloat("Direction",Vector3.Cross(curentDir,wantedDir).y,DirectionDampTime, Time.deltaTime);
				}
				else
				{
            		avatar.SetFloat("Direction", Vector3.Cross(curentDir,wantedDir).y > 0 ? 1 : -1, DirectionDampTime, Time.deltaTime);
				}
			}
			else
			{
            	avatar.SetFloat("Speed",0,SpeedDampTime, Time.deltaTime);
				
				if(avatar.GetFloat("Speed") < 0.01f)
				{
					TargetPosition = new Vector3(UnityEngine.Random.Range(-AvatarRange,AvatarRange),0,UnityEngine.Random.Range(-AvatarRange,AvatarRange));
				}
			}
            var nextState = avatar.GetNextAnimatorStateInfo(0);
            if (nextState.IsName("Base Layer.Dying"))
            {                
                avatar.SetBool("Dying", false);
            }

        }		
	}

//	void SpecificFootSteps ()
//	{
//		SoundManager.instance.RandomizeSfx(bearFootSteps1,bearFootSteps2,bearFootSteps3);
//	}

	void SpecificFootSteps ()
	{
		SoundManager.instance.RandomizeSfx(bearFootSteps);
	}

    void OnCollisionEnter(Collision collision)
    {
		if (avatar != null)
        {
			var currentState = avatar.GetCurrentAnimatorStateInfo(0);
			var nextState = avatar.GetNextAnimatorStateInfo(0);
            //play bear dying sound
            //SoundManager.OneShot(0);
			SoundManager.instance.PlaySingle(bearDeath);
            /*if (GetComponent<AudioSource>().isPlaying == false)
            {
                GetComponent<AudioSource>().Play();
            } */
            if (!currentState.IsName("Base Layer.Dying") && !nextState.IsName("Base Layer.Dying"))
				avatar.SetBool("Dying", true);
        }       

    }
}
