#if MOREMOUNTAINS_TOPDOWNENGINE
using UnityEngine;

namespace Hushigoeuf.MoreMountains
{
    /// <summary>
    /// Заставляет персонажа двигаться в соответствии с классом-родителем AIActionMoveRandomly2D,
    /// но в пределах заданной сферической области.
    /// </summary>
    [AddComponentMenu(HGEditor.PATH_MENU_COMPONENT + nameof(AIActionMoveRandomlyCircle2D))]
    public class AIActionMoveRandomlyCircle2D : AIActionMoveRandomlyPosition2D
    {
        [Header(nameof(AIActionMoveRandomlyCircle2D))]
        public float MinimumRandomRadius;

        public float MaximumRandomRadius;

        protected Vector3 _center;
        protected float _radius;

        public override void Initialization()
        {
            base.Initialization();

            _center = transform.position;

            _radius = Random.Range(MinimumRandomRadius, MaximumRandomRadius);
        }

        protected override void PickRandomPosition()
        {
            _pickedPosition = GetRandomPositionInsideCircle(_center, _radius);
        }

        protected virtual Vector2 GetRandomPositionInsideCircle(Vector2 center, float radius) =>
            center + Random.insideUnitCircle * radius;

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();

            var center = transform.position;
            float radius = MaximumRandomRadius;
            if (Application.isPlaying)
            {
                center = _center;
                radius = _radius;
            }

            if (radius > 0)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(center, radius);
            }
        }
    }
}
#endif