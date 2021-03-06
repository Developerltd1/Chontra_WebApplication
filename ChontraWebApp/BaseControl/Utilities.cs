﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyCode
{
    public static class Utilities { 
   

    public static class MyExtensions
    {
        public class DropDownModal
            {
                public int Value { get; set; }
                public string ValueIfDistinct { get; set; }
                public string Text { get; set; }
            }

            


            public static List<DropDownModal> ToSelectList(System.Data.DataTable table, string valueField, string textField)
            {
                List<DropDownModal> list = new List<DropDownModal>();

                foreach (System.Data.DataRow row in table.Rows)
                {
                    list.Add(new DropDownModal
                    {
                        Value = Convert.ToInt32(row[valueField]),
                        Text = Convert.ToString(row[textField])
                    });
                }
                return list;
            }
            public static List<DropDownModal> ToSelectListIfDistinct(System.Data.DataTable table, string valueField, string textField)
            {
                List<DropDownModal> list = new List<DropDownModal>();

                foreach (System.Data.DataRow row in table.Rows)
                {
                    list.Add(new DropDownModal
                    {
                        ValueIfDistinct = Convert.ToString(row[valueField]),
                        Text = Convert.ToString(row[textField])
                    });
                }
                return list;
            }


            public static string Encrypt(string strPlainText)
        {
            TripleDESCryptoServiceProvider crp = new TripleDESCryptoServiceProvider();
            UnicodeEncoding uEncode = new UnicodeEncoding();
            ASCIIEncoding aEncode = new ASCIIEncoding();
            byte[] bytPlainText = uEncode.GetBytes(strPlainText.Trim());
            MemoryStream stmCipherText = new MemoryStream();
            byte[] slt = new byte[0];
            PasswordDeriveBytes pdb = new PasswordDeriveBytes("159874269852056921753491", slt);
            byte[] bytDerivedKey = pdb.GetBytes(24);
            crp.Key = bytDerivedKey;
            crp.IV = pdb.GetBytes(8);
            CryptoStream csEncrypted = new CryptoStream(stmCipherText, crp.CreateEncryptor(), CryptoStreamMode.Write);
            csEncrypted.Write(bytPlainText, 0, bytPlainText.Length);
            csEncrypted.FlushFinalBlock();
            return Convert.ToBase64String(stmCipherText.ToArray());
        }
        public static string Decrypt(string strCipherText)
        {
            TripleDESCryptoServiceProvider crp = new TripleDESCryptoServiceProvider();
            UnicodeEncoding uEncode = new UnicodeEncoding();
            ASCIIEncoding aEncode = new ASCIIEncoding();
            byte[] bytCipherText = Convert.FromBase64String(strCipherText.Trim());
            MemoryStream stmPlainText = new MemoryStream();
            MemoryStream stmCipherText = new MemoryStream(bytCipherText);
            byte[] slt = new byte[0];
            PasswordDeriveBytes pdb = new PasswordDeriveBytes("159874269852056921753491", slt);
            byte[] bytDerivedKey = pdb.GetBytes(24);
            crp.Key = bytDerivedKey;
            crp.IV = pdb.GetBytes(8);
            CryptoStream csDecrypted = new CryptoStream(stmCipherText, crp.CreateDecryptor(), CryptoStreamMode.Read);
            StreamWriter sw = new StreamWriter(stmPlainText);
            StreamReader sr = new StreamReader(csDecrypted);
            sw.Write(sr.ReadToEnd());
            sw.Flush();
            csDecrypted.Clear();
            crp.Clear();
            return uEncode.GetString(stmPlainText.ToArray());
        }
        public static string EncryptURL(string strData)
        {
            try
            {
                if (!String.IsNullOrEmpty(strData))
                {
                    SHA1Managed shaM = new SHA1Managed();
                    Convert.ToBase64String(shaM.ComputeHash(Encoding.ASCII.GetBytes(strData)));
                    Byte[] encByteData;
                    encByteData = ASCIIEncoding.ASCII.GetBytes(strData);
                    String encStrData = Convert.ToBase64String(encByteData);
                    return encStrData;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception) { return ""; }

        }
        public static string DecryptURL(string strData) 
            {
            try
            {
                if (!string.IsNullOrEmpty(strData))
                {
                    Byte[] decByteData;
                    decByteData = Convert.FromBase64String("OA==");
                    String decStrData = ASCIIEncoding.ASCII.GetString(decByteData);

                    return decStrData = "1";
                }
                else
                {
                    return "";
                }

            }
            catch (Exception) { return ""; }
        }


          //public DataTable TableHeadingNamePicture()
          //{
              //DataTable HeadingName = new DataTable();
              //HeadingName.Columns.Add(new DataColumn("dtSelectPage", typeof(string)));
              //return HeadingName;
          //}
        }


    public static class dbConnection
    {
        public static string _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
        }

    }
 }

    public static class Conversion
    {
        public static char ToChar(this object obj)
        {
            return Convert.ToChar(obj);
        }
        public static Int16 ToShortInt(this object obj)
        {
            return Convert.ToInt16(obj);
        }
        public static string ToString2(this object obj)
        {
            return Convert.ToString(obj);
        }
        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }
        public static byte ToByte(this object obj)
        {
            return Convert.ToByte(obj);
        }
        public static Int64 ToInt64(this object obj)
        {
            return Convert.ToInt64(obj);
        }
        public static decimal ToDecimal(this object obj)
        {
            return Convert.ToDecimal(obj);
        }
        public static Double ToDouble(this object obj)
        {
            return Convert.ToDouble(obj);
        }
        public static string ToPkNum(this string number)
        {
            switch (number.Length)
            {
                case 11:
                    {

                        return "+92" + number.Substring(1);

                    }


                case 10:
                    {
                        return "+92" + number;
                    }

                case 12:
                    {
                        return "+" + number;
                    }

                case 14:
                    {
                        return "+" + number.Substring(2);
                    }

            }
            throw new Exception("Invalid String");
        }
        public static DateTime ToDate(this object obj)
        {
            return Convert.ToDateTime(obj);
        }
        public static bool ToBool(this object obj)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch
            {
                return false;
            }
        }


        #region ConvertDataTableToList
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        #endregion
        public static DataTable ConvertListToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        
    }

   

    public enum MessageTitle
    {
        Information = 0,
        Saved = 1,
        Updated = 2,
        Error = 3,
        Warning = 4,
        Deleted = 5
    }
    public enum MessageBox
    {
        Success = 1,
        Error = 2,
        Warning = 3,
        Info = 4
    }
}

