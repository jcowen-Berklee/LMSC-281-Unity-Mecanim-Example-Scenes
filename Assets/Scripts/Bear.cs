 /// <summary>
/// 
/// </summary>

using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]  

//Name of class must be name of file as well

public class Bear : MonoBehaviour {
	
	public float AvatarRange = 25;

	protected Animator avatar;
	
	private float SpeedDampTime = .25f;	
	private float DirectionDampTime = .25f;	
	private Vector3 TargetPosition = new Vector3(0,0,0);


	//perrin-----declare two private AudioSources "grunts" and breaths"
	private AudioSource grunts;
	private AudioSource breaths;



	
	// Use this for initialization
	void Start () 
	{
		avatar = GetComponent<Animator>();

		//perrin-----call the bearBreathing function *see below*
		bearBreathing ();






	}


	//perrin----make a new custom function named bearBreathing to call in the start function (just for fun) 
		void bearBreathing (){
	
	
			
			//perrin----the following three lines instantiate the AudioSource and load the desired samples of bears breathing using the AudioManager
			//see the script "Bazooka.cs" lines 55-63 for a more detailed explanation
			breaths = GetComponent<AudioSource> ();
			breaths.clip = AudioManager.RandomSound (AudioManager.bearBreathing);
			breaths.Play ();
	
	
	
	
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

    void OnCollisionEnter(Collision collision)
    {
		if (avatar != null)
        {
			var currentState = avatar.GetCurrentAnimatorStateInfo(0);
			var nextState = avatar.GetNextAnimatorStateInfo(0);
			if (!currentState.IsName("Base Layer.Dying") && !nextState.IsName("Base Layer.Dying"))
				avatar.SetBool("Dying", true);


			//perrin----instantiates AudioSource to variable and loads proper samples...see the bearBreathing() function above...
			grunts = GetComponent<AudioSource> ();
			grunts.clip = AudioManager.RandomSound(AudioManager.bearDying);
			grunts.Play ();


        }        
    }
}
