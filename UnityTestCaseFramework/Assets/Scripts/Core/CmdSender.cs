using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTestCaseFramework
{
	/// <summary>
	/// 指令发送器
	/// </summary>
	/// <author>xtom</author>
	public class CmdSender
	{
		/// <summary>
		/// 指令发送器单例
		/// </summary>
		public CmdSender Inst { get { return _inst ?? (_inst = new CmdSender()); } }

		CmdSender _inst;

		public CmdSender()
		{

		}

		public void Send(EnumCmdType type) 
		{ 
			
		}

		public void Send<T0>(EnumCmdType type, T0 arg0)
		{

		}
	}
}

