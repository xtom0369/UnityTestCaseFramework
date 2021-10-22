using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTestCaseFramework
{
	/// <summary>
	/// 游戏核心循环
	/// </summary>
	/// <author>xtom</author>
	public class GameLoop : MonoBehaviour
	{
		/// <summary>
		/// 帧率
		/// </summary>
		public static int FRAME_PER_SECOND = 30;

		/// <summary>
		/// 每帧对应的时间
		/// </summary>
		public static float SECOND_PER_FRAME = 1.0f / FRAME_PER_SECOND;

		LinkedList<TickData> _frameDataQueue = new LinkedList<TickData>();

        uint _sendFrame = 0; // 发送帧数
        uint _receiveFrame = 0; // 接收帧数
        float _totalDeltaTime = 0; 

        void Start()
		{
			QualitySettings.vSyncCount = 0; // Don’t Sync，即关闭垂直同步，https://gameinstitute.qq.com/community/detail/120791
			Application.targetFrameRate = FRAME_PER_SECOND;

			_receiveFrame = _sendFrame = 0;

   //         Log.Error("Test1");
   //         CmdReceiver.Inst.AddListener(EnumCmdType.USE_ITEM, _1);
   //         CmdReceiver.Inst.AddListener(EnumCmdType.USE_ITEM, _2);
			//CmdReceiver.Inst.DispatchListener(EnumCmdType.USE_ITEM);

   //         Log.Error("Test2");
   //         CmdReceiver.Inst.RemoveListener(EnumCmdType.USE_ITEM, _1);
   //         CmdReceiver.Inst.DispatchListener(EnumCmdType.USE_ITEM);
        }

        void _1() 
		{
			Log.Error("111111111111");
		}
        void _2()
        {
            Log.Error("222222222222");
        }

        void Update()
		{
			return;

            _sendFrame++;

			_totalDeltaTime += Mathf.Min(SECOND_PER_FRAME, Time.deltaTime);
			if (_totalDeltaTime >= SECOND_PER_FRAME)
			{
				ExecFrameData(1);

				_totalDeltaTime -= SECOND_PER_FRAME;
				if (_totalDeltaTime < 0)
					_totalDeltaTime = 0;
			}
		}

		protected void ExecFrameData(int maxExecCount)
		{
			int count = 0;
			while (_frameDataQueue.Count > 0 && count < maxExecCount)
			{
				count++;
				TickData tick = _frameDataQueue.First.Value;
				_frameDataQueue.RemoveFirst();
				uint receiveLatestFrame = tick.frame;

				_receiveFrame = receiveLatestFrame;

                //if (recorder != null)//当前回放文件存在，则把每一个关键帧写入回放文件中
                //	recorder.RecordFrame(tick, _sendFrame);

                //每个逻辑帧重置客户端随机数生成器
                //ResetRandom(randomSeed);

                //处理操作命令
                HandleCommand(tick);

                //if (tickPool != null && tick.isCreateFromPool)
                //	tickPool.BackTickToPool(tick);
            }
		}

        void HandleCommand(TickData tick)
        {
            while (!tick.IsReachEnd())
            {
                uint frame = tick.ReadUInt32(); // 客户端产生命令时的逻辑帧号
                EnumCmdType cmdType = (EnumCmdType)tick.ReadByte(); // 命令类型

                CmdEvent evt;
                if (CmdReceiver.Inst.TryConverCmd2Event(cmdType, tick, out evt))
                {
                    try 
					{ 
						// todo 命令处理
					}
                    catch (System.Exception e)
                    {
                        throw e;
                    }
                }
            }
        }
    }
}

