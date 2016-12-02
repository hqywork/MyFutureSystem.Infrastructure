/**************************************************************************************************
 * 描述：
 *      在此定义全局程序集信息。
 * 
 * 变更历史：
 *      作者：张奇  时间：2016年10月31日     新建 
 * 
 **************************************************************************************************/

using System;
using System.Reflection;

[assembly: AssemblyCompany("华奇英工作室")]
[assembly: AssemblyCopyright("Copyright © HQYSTUDIO 2002-2016")]
[assembly: AssemblyTrademark("Copyright © HQYSTUDIO")]
[assembly: AssemblyProduct("My Future")]

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif

[assembly: CLSCompliant(true)]
[assembly: System.Resources.NeutralResourcesLanguage("en-US")]