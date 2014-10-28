using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;
using System.Data;
using System.Collections;
using System.Web.Script.Serialization;
using Business.Commons;

namespace CustomTab.Controllers
{
    public class CustomTabController : Controller
    {
        /// <summary>
        /// 数据展示与录入界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Menu = 1;
            ViewBag.Title = "数据展示与录入";
            CustomTable_MainModel CT_Model = new CustomTable_MainModel();
            var ct_MainList = CT_Model.List().OrderByDescending(a => a.SaveDate).ToList();
            return View(ct_MainList);
        }

        /// <summary>
        /// 展示自定义表数据
        /// </summary>
        /// <param name="CMID"></param>
        /// <returns></returns>
        public ActionResult CustomTableInfo(int CMID)
        {
            CustomTable_MainModel CT_Mmodel = new CustomTable_MainModel();
            CustomTable_ColumnModel CT_Cmodel = new CustomTable_ColumnModel();

            #region  注意：表信息表头 要与 字段信息排序一致

            //获取表信息
            var CustomTable = CT_Mmodel.GetCustomTableInfo(CMID);
            ViewBag.CustomTable = CustomTable;
            //获取字段信息
            var CustomColumn = CT_Cmodel.GetList_ByCMID(CMID);
            ViewBag.CustomColumn = CustomColumn;

            #endregion

            var CT_Main = CT_Mmodel.Get(CMID);
            ViewBag.Title = CT_Main.TableMain;
            return View(CT_Main);
        }

        /// <summary>
        /// 添加自定义表内容数据
        /// </summary>
        /// <param name="Options"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCustomTableInfo(string Options, int CMID)
        {
            CustomTable_ValuesModel CT_Vmodel = new CustomTable_ValuesModel();
            CT_Vmodel.AddCustomValInfo(CMID, Options);
            return JavaScript("window.location.href='" + Url.Action("CustomTableInfo", "CustomTab", new { CMID = CMID }) + "'");
        }

        /// <summary>
        /// 修改自定义表内容数据
        /// </summary>
        /// <param name="UpdOptions"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditCustomTableInfo(string UpdOptions, int CMID, string Identification)
        {
            CustomTable_ValuesModel CT_Vmodel = new CustomTable_ValuesModel();
            CT_Vmodel.EditCustomValInfo(CMID, UpdOptions, Identification);
            return JavaScript("window.location.href='" + Url.Action("CustomTableInfo", "CustomTab", new { CMID = CMID }) + "'");
        }

        /// <summary>
        /// 删除自定义表内容数据
        /// </summary>
        /// <param name="CMID"></param>
        /// <param name="Identification"></param>
        /// <returns></returns>
        public ActionResult DelCustomTableVal(int CMID, string Identification)
        {
            CustomTable_ValuesModel CT_Vmodel = new CustomTable_ValuesModel();
            CT_Vmodel.DelCustomVal_BYIdentification(CMID, Identification);
            return RedirectToAction("CustomTableInfo", "CustomTab", new { CMID = CMID });
        }

        //--------------------------------自定义表设置----------------------------
        /// <summary>
        /// 自定义表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SetIndex()
        {
            ViewBag.Menu = 2;
            ViewBag.Title = "自定义表";
            CustomTable_MainModel CT_Model = new CustomTable_MainModel();
            var ct_MainList = CT_Model.List().OrderByDescending(a => a.SaveDate).ToList();
            return View(ct_MainList);
        }

        /// <summary>
        /// 添加自定义表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCustomTable()
        {
            ViewBag.Menu = 2;
            ViewBag.Title = "创建自定义表";
            return View();
        }
        /// <summary>
        /// //添加自定义表功能
        /// </summary>
        /// <param name="ct_m">主表</param>
        /// <param name="Options">字段表数据</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCustomTable(CustomTable_Main ct_m, string Options)
        {
            CustomTable_MainModel CT_Model = new CustomTable_MainModel();
            var result = CT_Model.AddMain_Column(ct_m, Options);
            if (result.HasError)
            {
                return JavaScript("JMessage(" + result.Error + ")");
            }

            return JavaScript("window.location.href='" + Url.Action("SetIndex", "CustomTab") + "'");
        }


        /// <summary>
        /// 修改自定义表页面
        /// </summary>
        /// <param name="CT_MainID">主表ID</param>
        /// <param name="ISOK">是否修改成功 0失败,1成功,2无操作</param>
        /// <returns></returns>
        public ActionResult EditCustomTable(int CMID, int? ISOK)
        {
            ViewBag.Menu = 2;
            ViewBag.Title = "修改自定义表";
            CustomTable_MainModel CT_Model = new CustomTable_MainModel();
            var CT_Main = CT_Model.Get(CMID);
            if (ISOK.HasValue)
            {
                ViewBag.ISOK = ISOK.Value;
            }
            else
            {
                ViewBag.ISOK = 2;
            }
            return View(CT_Main);
        }

        /// <summary>
        /// 修改自定义表页面
        /// </summary>
        /// <param name="ct_m">主表</param>
        /// <param name="Options">字段表数据</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditCustomTable(CustomTable_Main ct_m, string Options)
        {
            CustomTable_MainModel CT_Model = new CustomTable_MainModel();
            var result = CT_Model.EditMain_Column(ct_m, Options);
            if (result.HasError)
            {
                return JavaScript("JMessage(" + result.Error + ")");
            }

            return JavaScript("window.location.href='" + Url.Action("EditCustomTable", "CustomTab", new { CMID = ct_m.ID, ISOK = 1 }) + "'");
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="CMID"></param>
        /// <returns></returns>
        public ActionResult DeleteCustomTable(int CMID)
        {
            CustomTable_MainModel CT_Model = new CustomTable_MainModel();
            var result = CT_Model.Delete_CustomMain(CMID);

            return RedirectToAction("SetIndex", "CustomTab");
        }
    }
}
