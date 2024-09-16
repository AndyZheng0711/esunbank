using System.Diagnostics.CodeAnalysis;

namespace MyWebAPI.Service
{
    public class Tools
    {
        /// <summary>
        /// 判斷是否為空值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
    }
}
