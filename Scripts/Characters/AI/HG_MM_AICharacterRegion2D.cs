﻿using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace Hushigoeuf
{
    /// <summary>
    /// Определяет область для движения персонажей c включенным AI.
    /// </summary>
    [AddComponentMenu(HGEditor.PATH_MENU_TP + nameof(HG_MM_AICharacterRegion2D))]
    public class HG_MM_AICharacterRegion2D : MonoBehaviour
    {
        public enum RegionTypes
        {
            Box,
            Circle
        }

        public static readonly Dictionary<string, HG_MM_AICharacterRegion2D> Instances =
            new Dictionary<string, HG_MM_AICharacterRegion2D>();

        [Required] public string RegionID;
        public RegionTypes RegionType;

        /// Размер прямоугольной области если регион соответствующего типа
#if ODIN_INSPECTOR
        [EnableIf(nameof(RegionType), RegionTypes.Box)]
#endif
        public Vector2 Size;

        /// Радиус окружности если регион соответствующего типа
#if ODIN_INSPECTOR
        [EnableIf(nameof(RegionType), RegionTypes.Circle)]
#endif
        public float Radius;

        protected virtual void OnEnable()
        {
            if (!Instances.ContainsKey(RegionID))
                Instances.Add(RegionID, this);
        }

        protected virtual void OnDisable()
        {
            if (Instances.ContainsKey(RegionID))
                Instances.Remove(RegionID);
        }

        /// <summary>
        /// Возвращает рандомную позицию в соответствии с параметрами региона.
        /// </summary>
        public Vector2 GetRandomPosition()
        {
            var result = (Vector2) transform.position;

            switch (RegionType)
            {
                case RegionTypes.Box:
                    result.x += (Random.value - 0.5f) * Size.x;
                    result.y += (Random.value - 0.5f) * Size.y;
                    break;

                case RegionTypes.Circle:
                    result = GetRandomPositionInsideCircle(result, Radius);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Возвращает рандомную позицию внутри заданной окружности.
        /// </summary>
        protected virtual Vector2 GetRandomPositionInsideCircle(Vector2 center, float radius) =>
            center + Random.insideUnitCircle * radius;

#if ODIN_INSPECTOR
        [OnInspectorInit]
        private void EditorOnInitRegionID()
        {
            if (string.IsNullOrEmpty(RegionID))
                RegionID = name;
        }
#endif

        private void OnDrawGizmosSelected()
        {
            switch (RegionType)
            {
                case RegionTypes.Box:
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(transform.position, Size);
                    break;

                case RegionTypes.Circle:
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(transform.position, Radius);
                    break;
            }
        }

        public static HG_MM_AICharacterRegion2D GetRegion(string regionID)
        {
            if (Instances.ContainsKey(regionID))
                return Instances[regionID];
            return null;
        }
    }
}