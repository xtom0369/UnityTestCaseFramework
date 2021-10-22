using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityTestCaseFramework
{
    public delegate void CmdEventCallback(CmdEvent @event);

    /// <summary>
    /// 命令接收器
    /// </summary>
    /// <author>xtom</author>
    public partial class CmdReceiver
	{
		public CmdReceiver()
		{

		}

		/// <summary>
		/// 指令接收器单例
		/// </summary>
		public static CmdReceiver Inst { get { return _inst ?? (_inst = new CmdReceiver()); } }

		static CmdReceiver _inst;

        Dictionary<byte, CmdEventCallback> _cmdType2Actions = new Dictionary<byte, CmdEventCallback>();

        public void AddListener(EnumCmdType cmdType, CmdEventCallback callback) 
        {
            byte type = (byte)cmdType;
            _cmdType2Actions.TryGetValue((byte)cmdType, out CmdEventCallback cb);

            cb += callback;
            _cmdType2Actions[type] = cb;
        }

        public void RemoveListener(EnumCmdType cmdType, CmdEventCallback callback)
        {
            byte type = (byte)cmdType;
            if (!_cmdType2Actions.TryGetValue((byte)cmdType, out CmdEventCallback cb))
                return;

            cb -= callback;
            _cmdType2Actions[type] = cb;
        }

        /// <summary>
        /// 触发命令事件
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="event"></param>
        void DispatchListener(EnumCmdType cmdType, CmdEvent @event) 
        {
            byte type = (byte)cmdType;
            if (!_cmdType2Actions.TryGetValue((byte)cmdType, out CmdEventCallback cb))
                return;

            if (cb != null)
                cb(@event);
        }

        public bool TryConverCmd2Event(EnumCmdType cmdType, TickData tickData, out CmdEvent evt)
        {
            evt = GetCmdEventByType(cmdType, tickData);
            return evt != null;
        }

        CmdEvent GetCmdEventByType(EnumCmdType type, BytesBuffer buffer)
        {
            CmdEvent evt = null;
            switch (type) // 避免反射创建带来的开销
            {
                case EnumCmdType.USE_ITEM: evt = new UseItemEvent(EnumCmdType.USE_ITEM); break;
                default: break;
            }
            if (evt != null) { evt.Read(buffer); }
            return evt;
        }
    }

    public class CmdEvent
    {
        public EnumCmdType type { get => _type; }
        EnumCmdType _type;

        public CmdEvent(EnumCmdType type)
        {
            _type = type;
        }
        virtual public void Read(BytesBuffer buffer) { }
    }

    public partial class UseItemEvent : CmdEvent
    {
        public uint itemId;
        public uint itemCount;
        public UseItemEvent(EnumCmdType type) : base(type)
        {
        }
        override public void Read(BytesBuffer buffer)
        {
            itemId = buffer.ReadUInt32();
            itemCount = buffer.ReadUInt32();
        }
    }
}
