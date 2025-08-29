using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShapeShifterScript : MonoBehaviour
{
    [Header("Swap Data")]
    [SerializeField] private MainDataHolder MeshList;
    
    [Header("Player")]
    [SerializeField] private MeshFilter CurrentMesh;
    [SerializeField] private MeshCollider CurrentCollider;
    [SerializeField] private Transform PlayerTransform;
    
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip Correct;
    [SerializeField] private AudioClip Switch;
    [SerializeField] private AudioClip Wrong;

    [Header("Particle Sytem")]
    [SerializeField] private ParticleSystem particle;
    
    private int CurrentPlayerIndex;

    public void ChangeShape(int index)
    {
        if(CurrentPlayerIndex != index)
        {
            audioSource.PlayOneShot(Switch);
            particle.Play();
        }
        CurrentPlayerIndex = index;
        CurrentMesh.mesh = MeshList.Catagory[0].Items[index].Mesh;
        CurrentCollider.sharedMesh = MeshList.Catagory[0].Items[index].Mesh;
        PlayerTransform.localScale = new Vector3(MeshList.Catagory[0].Items[index].scale, MeshList.Catagory[0].Items[index].scale, MeshList.Catagory[0].Items[index].scale);
    }

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(Correct);
    }

    public void PlayIncorrectSound()
    {
        audioSource.PlayOneShot(Wrong);
    }

    public int GetPlayerMesh()
    {
        return CurrentPlayerIndex;
    }
}