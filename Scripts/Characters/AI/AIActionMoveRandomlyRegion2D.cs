#if MOREMOUNTAINS_TOPDOWNENGINE
using UnityEngine;

namespace Hushigoeuf.MoreMountains
{
    /// <summary>
    /// Заставляет персонажа двигаться в соответствии с классом-родителем AIActionMoveRandomly2D,
    /// но в пределах сторонней области на базе HG_MM_AICharacterRegion2D.
    /// </summary>
    [AddComponentMenu(HGEditor.PATH_MENU_COMPONENT + nameof(AIActionMoveRandomlyRegion2D))]
    public sealed class AIActionMoveRandomlyRegion2D : AIActionMoveRandomlyPosition2D
    {
        [Header(nameof(AIActionMoveRandomlyRegion2D))]
        public string RegionID;

        private AICharacterRegion2D _region;

        protected override void PickRandomPosition()
        {
            if (_region == null)
                _region = AICharacterRegion2D.GetRegion(RegionID);

            if (_region != null)
                _pickedPosition = _region.GetRandomPosition();
            else _pickedPosition = transform.position;
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();

            if (_region == null) return;

            switch (_region.RegionType)
            {
                case AICharacterRegion2D.RegionTypes.Box:
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(_region.transform.position, _region.Size);
                    break;

                case AICharacterRegion2D.RegionTypes.Circle:
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(_region.transform.position, _region.Radius);
                    break;
            }
        }
    }
}
#endif