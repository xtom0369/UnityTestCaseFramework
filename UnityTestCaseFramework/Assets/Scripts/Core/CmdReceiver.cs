using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTestCaseFramework
{
	/// <summary>
	/// 命令枚举
	/// </summary>
	/// <author>xtom</author>
	public class CmdReceiver
	{

		public CmdReceiver()
		{

		}

		/// <summary>
		/// 指令接收器单例
		/// </summary>
		public CmdReceiver Inst { get { return _inst ?? (_inst = new CmdReceiver()); } }

		CmdReceiver _inst;
	}
}
