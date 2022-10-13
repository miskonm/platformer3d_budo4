using UnityEditor;
using UnityEngine;

namespace P3D.Game
{
    [CustomEditor(typeof(MovingObject))]
    public class MovingObjectEditor : Editor
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        private static void Draw(MovingObject movingObject, GizmoType gizmoType)
        {
            if (!ShouldDraw(movingObject, gizmoType))
                return;

            if (IsNotValid(movingObject))
                return;

            Gizmos.color = Color.red;
            foreach (Transform point in movingObject.Points)
            {
                Gizmos.DrawSphere(point.position, 0.4f);
            }

            Gizmos.color = Color.green;
            Transform previousPoint = movingObject.Points.First();
            for (int i = 1; i < movingObject.Points.Count; i++)
            {
                Transform point = movingObject.Points[i];
                Gizmos.DrawLine(previousPoint.position, point.position);
                previousPoint = point;
            }

            Gizmos.DrawLine(previousPoint.position, movingObject.Points.First().position);
        }

        private static bool IsNotValid(MovingObject movingObject)
        {
            // TODO: Check null ref in loop
            return movingObject.Points == null || movingObject.Points.Count < 2;
        }

        private static bool ShouldDraw(MovingObject movingObject, GizmoType gizmoType)
        {
            if (gizmoType == GizmoType.Selected)
                return true;

            Transform parent = movingObject.transform.parent;
            if (parent == Selection.activeTransform)
                return true;

            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i) == Selection.activeTransform)
                    return true;
            }

            return false;
        }
    }
}