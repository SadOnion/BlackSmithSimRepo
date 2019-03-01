using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hammer : MonoBehaviour {



    
    public GameObject sparkles;
    private float maxMotor;
    private HingeJoint2D hinge;
	// Use this for initialization
	void Start () {
        hinge = GetComponent<HingeJoint2D>();
        maxMotor = hinge.motor.maxMotorTorque;
	}
   
    public void HammerTime()
    {
       
        StartCoroutine(ChangeMotorSign());
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject o = Instantiate(sparkles, collision.contacts[0].point, Quaternion.identity);
        Destroy(o, 0.5f);
        GetComponent<AudioSource>().Play();
        
    }
    private IEnumerator ChangeMotorSign()
    {
        var m = new JointMotor2D();
        m.motorSpeed = -hinge.motor.motorSpeed;
        m.maxMotorTorque = maxMotor;
        hinge.motor = m;
        
        yield return new WaitForSeconds(0.2f);
        
        m.motorSpeed = -hinge.motor.motorSpeed;
        hinge.motor = m;
        
        

    }
}
