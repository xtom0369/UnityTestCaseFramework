using System;
using System.Text;

namespace UnityTestCaseFramework
{
	public static partial class Utility
	{
		/// <summary>
		/// 字符相关的实用函数。
		/// </summary>
		public static class Text
		{
			private const int StringBuilderCapacity = 1024;

			[ThreadStatic]
			private static StringBuilder m_CachedStringBuilder = null;

			/// <summary>
			/// 获取格式化字符串。
			/// </summary>
			/// <param name="format">字符串格式。</param>
			/// <param name="arg0">字符串参数 0。</param>
			/// <returns>格式化后的字符串。</returns>
			public static string Format(string format, object arg0)
			{
				if (format == null)
				{
					throw new Exception("Format is invalid.");
				}

				CheckCachedStringBuilder();
				m_CachedStringBuilder.Length = 0;
				m_CachedStringBuilder.AppendFormat(format, arg0);
				return m_CachedStringBuilder.ToString();
			}

			/// <summary>
			/// 获取格式化字符串。
			/// </summary>
			/// <param name="format">字符串格式。</param>
			/// <param name="arg0">字符串参数 0。</param>
			/// <param name="arg1">字符串参数 1。</param>
			/// <returns>格式化后的字符串。</returns>
			public static string Format(string format, object arg0, object arg1)
			{
				if (format == null)
				{
					throw new Exception("Format is invalid.");
				}

				CheckCachedStringBuilder();
				m_CachedStringBuilder.Length = 0;
				m_CachedStringBuilder.AppendFormat(format, arg0, arg1);
				return m_CachedStringBuilder.ToString();
			}

			/// <summary>
			/// 获取格式化字符串。
			/// </summary>
			/// <param name="format">字符串格式。</param>
			/// <param name="arg0">字符串参数 0。</param>
			/// <param name="arg1">字符串参数 1。</param>
			/// <param name="arg2">字符串参数 2。</param>
			/// <returns>格式化后的字符串。</returns>
			public static string Format(string format, object arg0, object arg1, object arg2)
			{
				if (format == null)
				{
					throw new Exception("Format is invalid.");
				}

				CheckCachedStringBuilder();
				m_CachedStringBuilder.Length = 0;
				m_CachedStringBuilder.AppendFormat(format, arg0, arg1, arg2);
				return m_CachedStringBuilder.ToString();
			}

			/// <summary>
			/// 获取格式化字符串。
			/// </summary>
			/// <param name="format">字符串格式。</param>
			/// <param name="args">字符串参数。</param>
			/// <returns>格式化后的字符串。</returns>
			public static string Format(string format, params object[] args)
			{
				if (format == null)
				{
					throw new Exception("Format is invalid.");
				}

				if (args == null)
				{
					throw new Exception("Args is invalid.");
				}

				CheckCachedStringBuilder();
				m_CachedStringBuilder.Length = 0;
				m_CachedStringBuilder.AppendFormat(format, args);
				return m_CachedStringBuilder.ToString();
			}

			private static void CheckCachedStringBuilder()
			{
				if (m_CachedStringBuilder == null)
				{
					m_CachedStringBuilder = new StringBuilder(StringBuilderCapacity);
				}
			}
		}
	}
}
