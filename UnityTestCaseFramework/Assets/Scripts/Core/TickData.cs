using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTestCaseFramework
{
	/// <summary>
	/// 帧数据
	/// </summary>
	/// <author>xtom</author>
	public class TickData : BytesBuffer
	{
        /// <summary>
        /// 当前帧
        /// </summary>
        public uint frame;

		/// <summary>
		/// 随机种子
		/// </summary>
		public uint randomSeed;

        public TickData(int capacity = 16) : base(capacity)
        {
        }
    }
}

