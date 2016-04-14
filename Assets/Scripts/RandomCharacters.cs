 /// <summary>
/// 
/// </summary>

using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]  

//Name of class must be name of file as well

public class RandomCharacters : MonoBehaviour {
	
	public float AvatarRange = 25;

	protected Animator avatar;
	
	private float SpeedDampTime = .25f;	
	private float DirectionDampTime = .25f;	
	private Vector3 TargetPosition = new Vector3(0,0,0);

	//------Bernard-----------Initialize the AudioSource
	private AudioSource steps;
	//--------------------------------------------------
	

	void Start () 
	{
		//------Bernard---------Plays random footsepts from the Array
		steps = GetComponent<AudioSource> ();
		steps.clip = AudioManager.RandomFootSteps(); 
		steps.Play ();
		//------------------------------------------------------
		
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
		}		
	}   		  
}
