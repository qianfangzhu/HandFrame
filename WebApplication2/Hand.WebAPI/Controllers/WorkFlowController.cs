﻿using System;
using System.Web.Http;
using Hand.Business;
using Hand.Model;

namespace Hand.WebAPI.Controllers
{
    [RoutePrefix("workflow")]
    public class WorkFlowController : ApiController
    {
        public static WorkFlowInfo WorkFlowInfo = new WorkFlowInfo();

        /// <summary>
        /// 朱乾方
        /// 20170829
        /// 工作流信息
        /// </summary>
        /// <param name="empNo">用户工号</param>
        /// <returns></returns>
        [Route("getWorkFlow/{empNo}")]
        public IHttpActionResult GetWorkFlow(int? empNo)
        {
            try
            {
                var workFlowInfo = WorkFlowInfo.GetWorkFlow(empNo);
                return Ok(workFlowInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 朱乾方
        /// 20170829
        /// 添加工作流
        /// </summary>
        /// <param name="workFlow">工作流实体</param>
        /// <returns></returns>
        [Route("addWorkFlow/{empNo}")]
        public IHttpActionResult AddWorkFlow(WorkFlow workFlow)
        {
            try
            {
                var addworkFlowInfo = WorkFlowInfo.AddWorkFlow(workFlow);
                return Ok(addworkFlowInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 朱乾方
        /// 20170829
        /// 添加工作流
        /// </summary>
        /// <param name="workId">工作流Id</param>
        /// <param name="workFlow">工作流实体</param>
        /// <returns></returns>
        [Route("edit/{workId}")]
        public IHttpActionResult EditWorkFlow(int? workId, WorkFlow workFlow)
        {
            try
            {
                var editWorkFlow = WorkFlowInfo.EditWorkFlow(workId, workFlow);
                return Ok(editWorkFlow);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 朱乾方
        /// 20170829
        /// 根据工作流Id获取工作流信息
        /// </summary>
        /// <param name="workId">工作流Id</param>
        /// <returns></returns>
        [Route("getWorkFlowById/{workId}")]
        public IHttpActionResult GetWorkFlowById(int? workId)
        {
            try
            {
                var workFlowInfo = WorkFlowInfo.GetWorkFlowById(workId);
                return Ok(workFlowInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}