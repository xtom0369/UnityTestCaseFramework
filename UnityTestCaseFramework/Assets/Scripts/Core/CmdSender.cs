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

        /// <summary>
        /// 使用道具命令
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="count"></param>
        public void SendUseItemCmd(uint itemId, uint count) 
		{
            //_buffer.WriteUInt32(curFrame);
            _buffer.WriteByte((byte)EnumCmdType.USE_ITEM);
            _buffer.WriteUInt32(itemId);
            _buffer.WriteUInt32(count);
        }
    }
}

