using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XrefManager
{
    public static class LayerComparer
    {
        #region Public Methods
        public static bool IsLike(string pattern, string text, bool caseSensitive = false)
        {
            return LikeOperator.LikeString(text, pattern, Microsoft.VisualBasic.CompareMethod.Text);
        }
        #endregion
    }
}
