using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Business.Commons;

namespace Business
{
    public class Contrast_WorkflowDetailModel : BaseModel<Contrast_WorkflowDetail>
    {
        public List<Contrast_WorkflowMainDetail> GetAll(int workflowMainID)
        {
            string sql = string.Format(@"SELECT  a.id AS 'wid', a.Title AS 'Title',a.Contrast_AccountID AS 'Contrast_AccountID1',a.IsSelfCheck AS 'IsSelfCheck' ,
                            ( SELECT    Name
                              FROM      Contrast_Account c
                              WHERE     a.Contrast_AccountID =c.ID
                            ) AS 'Contrast_AccountName1',
                            ( SELECT    CheckTime
                              FROM      Contrast_WorkflowDetail b
                              WHERE     b.Contrast_WorkflowMainID = {0}
                                        AND b.Contrast_workflowID = a.ID
                            ) AS 'CheckTime',
                            ( SELECT    Status
                              FROM      Contrast_WorkflowDetail b
                              WHERE     b.Contrast_WorkflowMainID = {0}
                                        AND b.Contrast_workflowID = a.ID
                            ) AS 'Status',
                            ( SELECT    Comment
                              FROM      Contrast_WorkflowDetail b
                              WHERE     b.Contrast_WorkflowMainID = {0}
                                        AND b.Contrast_workflowID = a.ID
                            ) AS 'Comment',
                            ( SELECT    ID
                              FROM      Contrast_WorkflowDetail b
                              WHERE     b.Contrast_WorkflowMainID ={0}
                                        AND b.Contrast_workflowID = a.ID
                            ) AS 'ID',
                            ( SELECT    Contrast_AccountID
                              FROM      Contrast_WorkflowDetail b
                              WHERE     b.Contrast_WorkflowMainID ={0}
                                        AND b.Contrast_workflowID = a.ID
                            ) AS 'Contrast_AccountID2',
                            ( SELECT    Name
                              FROM      Contrast_WorkflowDetail b,Contrast_Account c
                              WHERE     b.Contrast_WorkflowMainID ={0}
                                        AND b.Contrast_workflowID = a.ID
                                        AND b.Contrast_AccountID=c.ID
                            ) AS 'Contrast_AccountName2'

                            FROM    dbo.Contrast_Workflow a
                            ORDER BY a.Sort", workflowMainID);
            Common common = new Common();
            var list= common.SqlQuery<Contrast_WorkflowMainDetail>(sql).ToList();
            return list;
        }
    }
}
