using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask solidObjectLayer;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask environmentLayer;
    //	public LayerMask grassLayer;

    public static GameLayers i { get; set; }

    private void Awake()
    {
        i = this;
    }

    public LayerMask PlayerLayer
    {
        get => playerLayer;
    }

    public LayerMask SolidLayer {
        get => solidObjectLayer;
    }

    public LayerMask InteractableLayer {
        get => interactableLayer;
    }

    public LayerMask EnvironmentLayer {
        get => environmentLayer;
        }

 //    public LayerMask Solid Layer {
   //     get => solidObjectsLayer;
  //      }
}
