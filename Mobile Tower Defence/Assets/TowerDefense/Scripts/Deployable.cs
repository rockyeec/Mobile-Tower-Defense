﻿using UnityEngine;

public class Deployable : MonoBehaviour
{
    [Header("Deploy Attributes")]
    [SerializeField] private Material[] materials = null;
    [SerializeField] private int canDeployOnLayer = 31;

    protected bool IsDeployed { get; private set; }
    private Camera cam;

    private MeshRenderer[] renderers;
    private Collider[] colliders;

    public enum RendererIndex
    {
        normal = 0,
        transparent_green = 1,
        transparent_red = 2
    }

    void ChangeMaterial(RendererIndex index)
    {
        foreach (var item in renderers)
        {
            item.material = materials[(int)index];
        }
    }
    void SetColliders(bool b)
    {
        foreach (var item in colliders)
        {
            item.enabled = b;
        }
    }

    private void Start()
    {
        cam = Camera.main;
        renderers = GetComponentsInChildren<MeshRenderer>();
        colliders = GetComponentsInChildren<Collider>();
        IsDeployed = false;
        SetColliders(false);

        Init();
    }

    private void Update()
    {
        if (IsDeployed)
        {
            Tick(Time.deltaTime);
            return;
        }

        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, float.PositiveInfinity, ~(1 << 10)))
        {
            bool isDeployable = hit.collider.gameObject.layer == canDeployOnLayer;
            
            transform.position = hit.point;            

            if (Input.GetMouseButtonUp(0))
            {
                if (isDeployable)
                {
                    Deploy();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                ChangeMaterial(
                isDeployable
                ? RendererIndex.transparent_green
                : RendererIndex.transparent_red);
            }
        }
    }

    protected virtual void Init() { }
    protected virtual void Tick(in float delta) { }

    void Deploy()
    {
        ChangeMaterial(RendererIndex.normal);
        IsDeployed = true;
        SetColliders(true);
    }
}
