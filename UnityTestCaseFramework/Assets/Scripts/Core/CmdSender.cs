using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTestCaseFramework
{
	/// <summary>
	/// 指令发送器
	/// </summary>
	/// <author>xtom</author>
	public partial class CmdSender
	{
		/// <summary>
		/// 指令发送器单例
		/// </summary>
		public CmdSender Inst { get { return _inst ?? (_inst = new CmdSender()); } }

		CmdSender _inst;

        BytesBuffer _buffer;

        public CmdSender()
		{
			_buffer = new BytesBuffer(100);
		}

		public void SendUseItemCmd(EnumCmdType cmdType, uint itemId, uint count) 
		{
			//_buffer.WriteUInt32(curFrame);
			_buffer.WriteByte((byte)cmdType);
        }
	}
}

