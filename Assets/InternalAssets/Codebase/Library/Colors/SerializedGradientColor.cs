using System;
using UnityEngine;

namespace InternalAssets.Codebase.Library.Colors
{
    [Serializable]
    public class SerializedGradientColor
    {
        [SerializeField] private Color _from = Color.white;
        [SerializeField] private Color _to = Color.white;

        public Color GetColor()
        {
            (float, float) r, g, b;

            r = _from.r < _to.r ? (_from.r, _to.r) : (_to.r, _from.r);
            g = _from.g < _to.g ? (_from.g, _to.g) : (_to.g, _from.g);
            b = _from.b < _to.b ? (_from.b, _to.b) : (_to.b, _from.b);
            
            return new Color
            {
                r = UnityEngine.Random.Range(r.Item1, r.Item2),
                g = UnityEngine.Random.Range(g.Item1, g.Item2),
                b = UnityEngine.Random.Range(b.Item1, b.Item2),
            };
        }
    }
}