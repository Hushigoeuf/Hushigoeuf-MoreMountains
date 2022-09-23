#if MOREMOUNTAINS_TOPDOWNENGINE
using MoreMountains.Tools;
using UnityEngine;

namespace Hushigoeuf.MoreMountains
{
    /// <summary>
    /// Заставляет персонажа двигаться в соответствии с классом-родителем AIActionMoveRandomly2D,
    /// но в пределах заданной прямоугольной области.
    /// </summary>
    [AddComponentMenu(HGEditor.PATH_MENU_COMPONENT + nameof(AIActionMoveRandomlyBox2D))]
    public class AIActionMoveRandomlyBox2D : AIActionMoveRandomlyPosition2D
    {
        [Header(nameof(AIActionMoveRandomlyBox2D))]
        public Vector2 MinimumRandomPosition;

        public Vector2 MaximumRandomPosition;

        protected override void PickRandomPosition()
        {
            _pickedPosition = MMMaths.RandomVector2(MinimumRandomPosition, MaximumRandomPosition);
        }
    }
}
#endif