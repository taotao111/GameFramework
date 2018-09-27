#if EDITOR_ATTR
using System;

namespace GameFramework.SkillSystem
{
    public class EditorAttr : Attribute
    {
        public string viewName = "Attr";
        public int index = 1000;
        public bool enable = true;
        public bool enumMask = false;
        /// <summary>
        /// 在Unity il2cpp不能用，所以在用到的地方需要增加宏
        /// </summary>
        public object[] dep2;
    }
}
#endif