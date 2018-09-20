using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : MonoBehaviour
{
    /// <summary>
    /// Moar mesh
    /// </summary>
    MeshRenderer _mesh; // private C# field
    /// <summary>
    /// The mesh boundries 
    /// </summary>
    public MeshRenderer mesh // C# property
    {
        get
        {
            if (!_mesh) _mesh = GetComponent<MeshRenderer>(); // "lazy" initialization
            return _mesh;
        }
    }
    /// <summary>
    /// Sets the bounds of the mesh objects
    /// </summary>
    public Bounds bounds // C# property
    {
        get
        {
            return mesh.bounds;
        }
    }
    /// <summary>
    /// If the object is done checking against other objects. Hidden in the inspector
    /// </summary>
    [HideInInspector] public bool isDoneChecking = false;
    /// <summary>
    /// A boolean on if the object is overlapping or not
    /// </summary>
    bool isOverlapping = false;
    /// <summary>
    /// Adds a controller to the collider object
    /// </summary>
	void Start()
    {
        CollisionController.Add(this);
    }
    /// <summary>
    /// Auto remove When collision is true
    /// </summary>
	void OnDestroy()
    {
        CollisionController.Remove(this);
    }
    /// <summary>
    /// Called every frame
    /// </summary>
	void Update()
    {
        isDoneChecking = false;
        isOverlapping = false;
    }
    /// <summary>
    /// Draws red around objects if the object overlapping. Otherwise draws white
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = isOverlapping ? Color.red : Color.white;
        Gizmos.DrawWireCube(transform.position, mesh.bounds.size);
    }
    /// <summary>
    /// Checks to see if some other AABB overlaps this AABB.
    /// </summary>
    /// <param name="other">The other AABB component to check against.</param>
    /// <returns>If true, the two AABBs overlap.</returns>
    public bool CheckOverlap(AABB other)
    {

        if (other.bounds.min.x > bounds.max.x) return false;
        if (other.bounds.max.x < bounds.min.x) return false;

        if (other.bounds.min.y > bounds.max.y) return false;
        if (other.bounds.max.y < bounds.min.y) return false;

        if (other.bounds.min.z > bounds.max.z) return false;
        if (other.bounds.max.z < bounds.min.z) return false;

        return true;
    }
    /// <summary>
    /// Returns true if the object was overlapping
    /// </summary>
    /// <param name="other">The object being overlapped with</param>
    void OverlappingAABB(AABB other)
    {
        isOverlapping = true;
    }

}
