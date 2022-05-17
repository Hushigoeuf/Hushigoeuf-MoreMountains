#if MOREMOUNTAINS_TOPDOWNENGINE
using MoreMountains.TopDownEngine;
using UnityEngine;

namespace Hushigoeuf
{
    /// <summary>
    /// Заставляет персонажа двигаться в соответствии с классом-родителем AIActionMoveRandomly2D,
    /// но в качестве основы берется позиция, а не направление.
    /// </summary>
    public abstract class HG_MM_AIActionMoveRandomlyPosition2D : AIActionMoveRandomly2D
    {
        protected Vector2 _pickedPosition;

        protected override void PickRandomDirection()
        {
            base.PickRandomDirection();

            PickRandomPosition();

            _direction = (_pickedPosition - (Vector2) transform.position).normalized;
        }

        protected abstract void PickRandomPosition();

        protected virtual void OnDrawGizmosSelected()
        {
            if (!Application.isPlaying) return;

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, _pickedPosition);
        }
    }
}
#endif