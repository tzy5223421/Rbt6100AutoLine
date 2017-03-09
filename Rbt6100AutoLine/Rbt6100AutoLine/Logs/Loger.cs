using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using log4net;
using System.Windows.Forms;

namespace Rbt6100AutoLine.Log
{
    public static class Loger
    {
        public static void Info(string msg)
        {
            try
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                ILog log = log4net.LogManager.GetLogger(st.GetFrame(1).GetMethod().DeclaringType);
                log.Info(msg);
            }
            catch (System.Exception ex)
            {
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Fatal("日志系统错误", ex);
            }
        }
        public static void Debug(string msg)
        {
            try
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                ILog log = log4net.LogManager.GetLogger(st.GetFrame(1).GetMethod().DeclaringType);
                log.Debug(msg);
            }
            catch (System.Exception ex)
            {
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Fatal("日志系统错误", ex);
            }

        }
        public static void Warn(string msg)
        {
            try
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                ILog log = log4net.LogManager.GetLogger(st.GetFrame(1).GetMethod().DeclaringType);
                log.Warn(msg);
            }
            catch (System.Exception ex)
            {
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Fatal("日志系统错误", ex);
            }

        }
        public static void Error(string msg)
        {
            try
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                ILog log = log4net.LogManager.GetLogger(st.GetFrame(1).GetMethod().DeclaringType);
                log.Error(msg);
            }
            catch (System.Exception ex)
            {
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Fatal("日志系统错误", ex);
            }
        }

        public static void Error(string msg, Exception ex)
        {
            try
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                ILog log = log4net.LogManager.GetLogger(st.GetFrame(1).GetMethod().DeclaringType);
                log.Error(msg, ex);
            }
            catch (System.Exception exx)
            {
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Fatal("日志系统错误", exx);
            }
        }

        public static void Fatal(string msg)
        {
            try
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                ILog log = log4net.LogManager.GetLogger(st.GetFrame(1).GetMethod().DeclaringType);
                log.Fatal(msg);
            }
            catch (System.Exception ex)
            {
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Fatal("日志系统错误", ex);
            }

        }
        public static void Fatal(string msg, Exception ex)
        {
            try
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                ILog log = log4net.LogManager.GetLogger(st.GetFrame(1).GetMethod().DeclaringType);
                log.Fatal(msg, ex);
            }
            catch (System.Exception exx)
            {
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Fatal("日志系统错误", exx);
            }

        }
    }
}
