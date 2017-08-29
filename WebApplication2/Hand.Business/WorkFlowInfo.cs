using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hand.Model;
using Hand.Enum;

namespace Hand.Business
{
    public class WorkFlowInfo
    {
        public static testFrameEntities DbEntities = new testFrameEntities();

        /// <summary>
        /// 朱乾方
        /// 20170829
        /// 获取当前登陆人的工作流信息
        /// </summary>
        /// <returns></returns>
        public List<WorkFlowViewMoel> GetWorkFlow(int? empNo)
        {
            var workFlow = (from work in DbEntities.WorkFlow.ToList()
                            join dept in DbEntities.Department.ToList() on work.Work_DeptId equals dept.dept_id
                            where work.Work_EmpNo == empNo
                            select new WorkFlowViewMoel
                            {
                                WorkTitle = work.Work_Title,
                                WorkContent = work.Work_Content,
                                WorkCreateTime = Convert.ToDateTime(work.Work_CreateTime).ToString("yyyy-MM-dd"),
                                WorkStatus = EnumHelper.GetDescription((WorkStatusEnum)work.Work_Status.GetHashCode()),
                                DeptLeader = dept.dept_leader
                            }).ToList();
            return workFlow;
        }

        /// <summary>
        /// 朱乾方
        /// 20170829
        /// 添加工作流信息
        /// </summary>
        /// <param name="workFlow"></param>
        /// <returns></returns>
        public WorkFlow AddWorkFlow(WorkFlow workFlow)
        {
            var work = new WorkFlow
            {
                Work_EmpNo = workFlow.Work_EmpNo,
                Work_Title = workFlow.Work_Title,
                Work_Content = workFlow.Work_Content,
                Work_CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
                Work_DeptId = workFlow.Work_DeptId,
                Work_Status = WorkStatusEnum.Approval.GetHashCode()
            };
            DbEntities.WorkFlow.Add(work);
            DbEntities.SaveChanges();
            return work;
        }

        /// <summary>
        ///  朱乾方
        ///  20170829
        ///  根据工作流Id查询
        /// </summary>
        /// <param name="workId">工作流Id</param>
        /// <returns></returns>
        public WorkFlow GetWorkFlowById(int? workId)
        {
            var workFlow = DbEntities.WorkFlow.FirstOrDefault(w => w.Work_Id == workId);
            return workFlow;
        }

        /// <summary>
        ///  朱乾方
        ///  20170829
        ///  根据工作流Id比编辑工作流信息
        /// </summary>
        /// <param name="workId"></param>
        /// <param name="workFlow"></param>
        /// <returns></returns>
        public WorkFlow EditWorkFlow(int? workId, WorkFlow workFlow)
        {
            WorkFlow work = null;
            if (workFlow != null)
            {
                work = DbEntities.WorkFlow.FirstOrDefault(w => w.Work_Id == workId);
                if (work != null)
                {
                    work.Work_Title = workFlow.Work_Title;
                    work.Work_Content = workFlow.Work_Content;
                    work.Work_Status = workFlow.Work_Status;
                    DbEntities.Entry(work).State = EntityState.Modified;
                    DbEntities.SaveChanges();
                }
            }
            return work;
        }
    }
}
