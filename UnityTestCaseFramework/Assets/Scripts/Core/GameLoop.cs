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
		protected LinkedList<TickData> _frameDataQueue = new LinkedList<TickData>();

		void Start()
		{
			
		}

		void Update()
		{
			
		}

		/*
		protected void ExecFrameData(int maxExecCount, bool isAutoBackTick2Pool = true)
		{
			int maxExecFrameDataOneFrame = 0;
			while (_frameDataQueue.Count > 0 && maxExecFrameDataOneFrame < maxExecCount)
			{
				maxExecFrameDataOneFrame++;
				BattleServerTick tick = _frameDataQueue.First.Value;
				_frameDataQueue.RemoveFirst();
				uint serverLatestFrame = tick.serverFrame;
#if ASSERT_ENABLE
            DebugUtil.Assert(_serverFrame == serverLatestFrame - 1, "{0}|{1}", _serverFrame, serverLatestFrame);
#endif
				if (tick.size > 2000)
					DebugUtil.LogError("map={0} serverframe={1} tick包长度异常过大:{2}", battleModel.mapRow.Name, tick.serverFrame, tick.size);
				if (_serverFrame != serverLatestFrame - 1)
					DebugUtil.LogError("逻辑帧序号不连续了:{0}=>{1}", _serverFrame, serverLatestFrame);
				DebugUtil.CUR_BATTLE_LOGIC_FRAME = _serverFrame = serverLatestFrame;

				//DebugUtil.Log("server frame=" + serverLatestFrame + "|client frame=" + Time.frameCount);
				if (recorder != null)//当前回放文件存在，则把每一个关键帧写入回放文件中
					recorder.RecordFrame(tick, _clientFrame);

				//逻辑层代码执行之前做关键数据校正
				//if (dataCorrector != null && tick.isNeedCorrect)
				//    dataCorrector.CorrectKeyData(tick);
				modelAdmin.OnTick(tick);

				//逻辑层代码执行之后做关键数据上报
				if (battleChecker != null &&
					_frameDataQueue.Count == 0 &&//未有关键帧积压才上报，不然传了也会被丢掉，没意义
					!isFastForward &&//未在快进
					serverLatestFrame > 0 &&
					serverLatestFrame % battleModel.correctRate == 0)
					dataCorrector.SendKeyData2Server();

				if (tickPool != null && tick.isCreateFromPool && isAutoBackTick2Pool)
					tickPool.BackTickToPool(tick);

				if (battleChecker != null)
					battleChecker.Update(serverFrame);

				deltaLogicTime -= DefineVars.SERVER_FRAME_TIME_FLOAT;
				if (deltaLogicTime < 0)
					deltaLogicTime = 0;
			}
		}
		*/

	}
}

