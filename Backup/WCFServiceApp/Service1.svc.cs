using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {

        public DataSet QueryProduct()
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.SQLConnection);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT [DeadId], [DealName] FROM [Deals]", cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet GetProduct(String DeadId)
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.SQLConnection);
            SqlDataAdapter sda = new SqlDataAdapter(
                String.Format("SELECT [DeadId], [DealName] FROM [Deals] WHERE [DeadId]=\'{0}\'", DeadId), cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet AddProduct(String DeadId, String DealName)
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.SQLConnection);
            cn.Open();
            SqlCommand scmd = new SqlCommand(
                String.Format("INSERT INTO [Deals] ([DeadId],[DealName]) VALUES (\'{0}\',\'{1}\')", DeadId, DealName), cn);
            scmd.CommandText = String.Format("INSERT INTO [Deals] ([DeadId],[DealName]) VALUES (\'{0}\',\'{1}\')", DeadId, DealName);
            scmd.CommandType = CommandType.Text;
           
            DataSet ds = new DataSet();
            //sda.Fill(ds);
            String result = scmd.ExecuteNonQuery().ToString();
            return ds;
        }

        public DataSet UpdateProduct(String DeadId, String DealName)
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.SQLConnection);
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand scmd = new SqlCommand(
                String.Format("UPDATE [Deals] SET [DealName] = \'{1}\' WHERE [DeadId]=\'{0}\'", DeadId, DealName), cn);
            scmd.CommandText = String.Format("UPDATE [Deals] SET [DealName] = \'{1}\' WHERE [DeadId]=\'{0}\'", DeadId, DealName);
            scmd.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            //sda.Fill(ds);
            String result = scmd.ExecuteNonQuery().ToString();
            return ds;
        }


        public DataSet RemoveProduct(String DeadId, String DealName)
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.SQLConnection);
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand scmd = new SqlCommand(
                String.Format("DELETE FROM [Deals] WHERE [DeadId]=\'{0}\'", DeadId), cn);
            scmd.CommandText = String.Format("DELETE FROM [Deals] WHERE [DeadId]=\'{0}\' AND [DealName]=\'{1}\'", DeadId, DealName);
            scmd.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            //sda.Fill(ds);
            String result = scmd.ExecuteNonQuery().ToString();
            return ds;
        }


        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
