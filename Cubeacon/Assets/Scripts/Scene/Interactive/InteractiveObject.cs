using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class InteractiveObject : MonoBehaviour
{
    public bool noclip;
    private Rigidbody2D rb;
    private int interactiveLayers;
    private AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = FindObjectOfType<AudioSource>();
        interactiveLayers = LayerMask.GetMask("Blocks light", "Mirror", "Passes light", "Switch");
    }

    protected bool TryToMove(Vector2 direction, Dictionary<GameObject, Vector3> acts, Undo undo)
    {
        if (!noclip && IsBlockedByWall(direction))
            return false;

        acts.Add(gameObject, transform.position);

        InteractiveObject objectInFront = InteractiveObjectOnTheWay(direction);
        if  (objectInFront == null || objectInFront.TryToMove(direction, acts, undo))
        {
            Move(direction, acts, undo);
            return true;
        }

        return false;
    }

    private bool IsBlockedByWall(Vector2 direction)
    {
        Vector2 rayStart = rb.position + new Vector2(0.5f, 0.5f) * direction;
        RaycastHit2D hit = Physics2D.Raycast(rayStart, direction, 1, interactiveLayers);

        if (hit.collider != null && hit.collider.tag == "Blocks movement")
            return true;
        return false;
    }

    private InteractiveObject InteractiveObjectOnTheWay(Vector2 direction)
    {
        Vector2 rayStart = rb.position + new Vector2(0.6f, 0.6f) * direction;

        RaycastHit2D hit = Physics2D.Raycast(rayStart, direction, 0.5f, interactiveLayers);
        if (hit.collider != null && hit.collider.tag == "Moveable")
        {
            InteractiveObject obj = hit.collider.GetComponent<InteractiveObject>();
            return obj;
        }

        return null;
    }

    private void Move(Vector2 direction, Dictionary<GameObject, Vector3> acts, Undo undo)
    {
        rb.MovePosition(rb.position + direction);
        var temp = new Dictionary<GameObject, Vector3>(acts);
        if (temp.Count > 0)
            undo.history.Push(temp);
        acts.Clear();
        if (audioSource != null)
            audioSource.Play();
    }
}
