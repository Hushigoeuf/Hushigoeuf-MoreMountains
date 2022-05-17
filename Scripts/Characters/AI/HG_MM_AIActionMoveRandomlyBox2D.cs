#if MOREMOUNTAINS_TOPDOWNENGINE
using MoreMountains.Tools;
using UnityEngine;

namespace Hushigoeuf
{
    /// <summary>
    /// Заставляет персонажа двигаться в соответствии с классом-родителем AIActionMoveRandomly2D,
    /// но в пределах заданной прямоугольной области.
    /// </summary>
    [AddComponentMenu(HGEditor.PATH_MENU_TP + nameof(HG_MM_AIActionMoveRandomlyBox2D))]
    public class HG_MM_AIActionMoveRandomlyBox2D : HG_MM_AIActionMoveRandomlyPosition2D
    {
        [Header(nameof(HG_MM_AIActionMoveRandomlyBox2D))]
        public Vector2 MinimumRandomPosition;

        public Vector2 MaximumRandomPosition;

        protected override void PickRandomPosition()
        {
            _pickedPosition = MMMaths.RandomVector2(MinimumRandomPosition, MaximumRandomPosition);
        }
    }
}
#endif