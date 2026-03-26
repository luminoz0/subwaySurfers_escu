using UnityEngine;

[CreateAssetMenu(fileName = "CHARACTERDATA", menuName = "Scriptable Objects/CHARACTERDATA")]
public class CHARACTERDATA : ScriptableObject
{
    public string jumpAnimationName = "Jump";
    public string moveAnimationName = "Move";
    public string rollAnimationName = "Roll";
    public string loseAnimationName = "Lose";
    public string runAnimationName= "Run";
}
 
 